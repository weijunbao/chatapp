#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * AppController.cs - Application Controller
 *
 * Copyright (C) 2007  George Chiramattel
 * http://george.chiramattel.com
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

#endregion //GNU-GPL

using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.IQ;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.Presence;
// For playing sounds

namespace ChatApp
{
    public class AppController : ApplicationContext
    {
        public delegate void IncomingMessageDelegate(AbstractMessagePacket IncomingMessagePacket);

        public delegate void IncomingPresenceDelegate(PresencePacket IncomingPresencePacket);

        public delegate void IncomingRosterChangeDelegate(RosterChange IncomingRosterChangePacket);

        public delegate void IncomingIQErrorDelegate(IQErrorResponse IncomingIQErrorPacket);

        public delegate void IncomingIQResultDelegate(IQResultResponse IncomingIQResultPacket);

        #region Static Data

        public static List<string> CapabilityExtension = new List<string>();

        private const string STR_VoiceCapability = "voice-v1";
        private const string STR_SharevCapability = "share-v1";
        public static readonly string CapabilityNode = @"http://www.google.com/xmpp/client/caps";
        public static readonly string CapabilityVersion = "1.0.0.66";
        public static readonly string Resource = Settings.Default.Resource;
        public static readonly int Port = Settings.Default.Port;
        private static AppController m_Controller = null;

        #endregion //Static Data

        #region private Fields

        private HiddenWindow m_hiddenWnd = null;
        private SessionManager m_sessionMgr;
        private JabberID m_currentUser = null;
        private MainWindow m_mainWindow = null;
        private AvailableRequest m_currentPresence;
        private ContactList m_contacts;
        private Hashtable m_ActiveChatUsers = null;
        private KryptonForm CurrentActiveWindow = null;
        private bool HiddenMode = false;

        static AppController()
        {
            CapabilityExtension.Add(STR_VoiceCapability);
            CapabilityExtension.Add(STR_SharevCapability);
        }

        /// <summary>
        /// To make this class a singleton
        /// </summary>
        public AppController()
        {
            m_hiddenWnd = new HiddenWindow();
            m_hiddenWnd.Visible = false;
            MainForm = m_hiddenWnd;

            m_hiddenWnd.Load += new EventHandler(HiddenWnd_load);
            m_contacts = new ContactList();
            m_ActiveChatUsers = new Hashtable();
        }

        #region Event Handlers

        private void HiddenWnd_load(Object sender, EventArgs e)
        {
            StartApplication();
        }

        private void loginWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginWindow wnd = sender as LoginWindow;
            if (wnd != null && wnd.LoginSuccessful == true)
            {
                Application.DoEvents();
                Start();
            }
            else
            {
                if (e.CloseReason != CloseReason.ApplicationExitCall)
                {
                    ExitApplication();
                }
            }
        }

        #endregion

        #endregion

        #region Event Declaration

        //Events used by the MainWindow, ChatWindow to receive packets from the lower level components.
        public event IncomingMessageDelegate IncomingMessage;
        public event IncomingPresenceDelegate IncomingPresence;
        public event IncomingRosterChangeDelegate IncomingRosterChange;
        public event IncomingIQErrorDelegate IncomingIQError;
        public event IncomingIQResultDelegate IncomingIQResult;

        #endregion

        #region Fire Events

        //Relays incoming message packets to subscribing objects
        public void OnIncomingMessage(Packet packet)
        {
            if (IncomingMessage != null)
            {
                IncomingMessage((AbstractMessagePacket) packet);
            }
        }

        /// <summary>
        /// Relays incoming presence packets to subscribing objects
        /// </summary>
        /// <param name="packet"></param>
        public void OnIncomingPresence(Packet packet)
        {
            HandlePresenceRequest(packet);
            if (IncomingPresence != null)
            {
                IncomingPresence((PresencePacket) packet);
            }
        }

        private void HandlePresenceRequest(Packet packet)
        {
            PresencePacket IncomingPresencePacket = packet as PresencePacket;

            if (IncomingPresencePacket is ProbeRequest)
            {
                //A Probe means we should send our presence to the probing entity
                //Maybe we should get some user input here.  Not really sure if theyd want to know, though.
                SendCurrentPresence(IncomingPresencePacket.From);
            }
            else if (IncomingPresencePacket is SubscribeRequest)
            {
                string displayString =
                    String.Format("Allow User '{0}; to subscribe to your presence?",
                                  IncomingPresencePacket.From.JabberIDNoResource);
                if (
                    MessageBox.Show(displayString, "Subscription Request", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SubscribedResponse resp = new SubscribedResponse(IncomingPresencePacket.From);
                    SessionManager.Send(resp);

                    SubscribeRequest subscribe =
                        new SubscribeRequest(new JabberID(IncomingPresencePacket.From.JabberIDNoResource));
                    SessionManager.Send(subscribe);
                }
                else
                {
                    UnsubscribedResponse resp = new UnsubscribedResponse();
                    resp.To = IncomingPresencePacket.From;
                    SessionManager.Send(resp);
                }
            }
            else if (IncomingPresencePacket is SubscribedResponse)
            {
                //Let the user know when someone accepts our subscription request
                string displayString =
                    String.Format("User '{0}' has accepted your presence subscription request.",
                                  IncomingPresencePacket.From.JabberIDNoResource);
                MessageBox.Show(displayString, "Subscription Accept", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IncomingPresencePacket is UnsubscribedResponse)
            {
                //Let the user know when someone revoked our presence subscription
                string displayString =
                    String.Format("User '{0}' rejected your reqeust.", IncomingPresencePacket.From.JabberIDNoResource);
                MessageBox.Show(displayString, "Subscription Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IncomingPresencePacket is AvailableRequest)
            {
                AvailableRequest availableReq = WConvert.ToAvailableRequest(IncomingPresencePacket);
                LoginState state = LoginState.Offline;

                if (availableReq.From.Server.Contains(".com"))
                {
                    state = (LoginState) availableReq.Show;
                }
                else
                {
                    state = (LoginState) Enum.Parse(typeof (LoginState), availableReq.Status);
                }

                string userName = availableReq.From.UserName;

                Contact contact = Instance.Contacts[userName];
                if (contact != null)
                {
                    contact.UserStatus = state;
                    if (availableReq.HasVCardAvatarUpdateHash)
                    {
                        if (availableReq.HasJabberXAvatarHash)
                        {
                            contact.AvatatType = Contact.AvatarType.JabberXAvatar;
                        }
                        /*else - we prefere VCardAvatar*/
                        if (availableReq.HasVCardAvatarUpdateHash)
                        {
                            contact.AvatatType = Contact.AvatarType.VCardAvatar;
                        }
                        contact.AvatarHash = availableReq.VCardAvatarUpdateHash;
                    }
                }
            }
            else if (IncomingPresencePacket is UnavailableRequest)
            {
                UnavailableRequest avail = WConvert.ToUnavailableRequest(IncomingPresencePacket);
                string userName = avail.From.UserName;
                Contact contact = Instance.Contacts[userName];
                contact.UserStatus = LoginState.Offline;
            }
        }

        public void OnIncomingRosterChange(Packet packet)
        {
            if (IncomingRosterChange != null)
            {
                IncomingRosterChange((RosterChange) packet);
            }
        }

        //Relays incoming IQError to subscribing objects
        public void OnIncomingIQError(Packet packet)
        {
            if (IncomingIQError != null)
            {
                IncomingIQError((IQErrorResponse) packet);
            }
        }

        //Relays incoming IQResult to subscribing objects
        public void OnIncomingIQResult(Packet packet)
        {
            if (IncomingIQResult != null)
            {
                IncomingIQResult((IQResultResponse) packet);
            }
        }

        #endregion // Fire Events

        #region Properties

        public MessageStoreController MessageStoreController
        {
            get { throw new NotImplementedException(); }
        }

        public ConfigStoreController ConfigStoreController
        {
            get { throw new NotImplementedException(); }
        }

        public MainWindow MainWindow
        {
            get
            {
                if (m_mainWindow == null)
                    m_mainWindow = new MainWindow();
                return m_mainWindow;
            }
        }

        public LoginState LoginSate
        {
            get { throw new NotImplementedException(); }
        }

        public ContactList Contacts
        {
            get { return m_contacts; }
        }

        public SessionManager SessionManager
        {
            get { return m_sessionMgr; }
        }

        public JabberID CurrentUser
        {
            get { return m_currentUser; }
            set { m_currentUser = value; }
        }

        public static AppController Instance
        {
            get
            {
                if (m_Controller == null)
                {
                    m_Controller = new AppController();
                }
                return m_Controller;
            }
        }

        public HiddenWindow HiddenWindow
        {
            get { return m_hiddenWnd; }
        }

        #endregion //Properties

        private void StartApplication()
        {
            ShowLoginWindow();
        }

        private void ShowLoginWindow()
        {
            LoginWindow loginWnd = new LoginWindow();
            loginWnd.FormClosed += new FormClosedEventHandler(loginWnd_FormClosed);
            loginWnd.Show();
        }

        internal bool Login(string UserName, string Password, string ServerName)
        {
            InitializeSessionManager(UserName, Password, ServerName);
            if (m_sessionMgr != null)
            {
                m_currentUser = m_sessionMgr.LocalUser;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Start()
        {
            LoadContactList();
            MainWindow.Show();
        }

        public void SendAvailableRequest()
        {
            m_currentPresence = new AvailableRequest();
            m_currentPresence.EntityCapabilitiesVersion = CapabilityVersion;
            m_currentPresence.EntityCapabilitiesNode = CapabilityNode;
            m_currentPresence.EntityCapabilitiesExtensions = CapabilityExtension;
            m_currentPresence.Status = LoginState.Online.ToString();
            m_sessionMgr.Send(m_currentPresence);
        }

        public void LoadContactList()
        {
            // Get the Roster response synchronously
            RosterResponse roster = (RosterResponse) m_sessionMgr.Send(new RosterRequest());

            foreach (RosterItem rsItem in roster.Items)
            {
                Contact contact = new Contact(rsItem.JID,
                                              rsItem.Group.ToString(),
                                              LoginState.Offline);

                m_contacts.Add(contact);
            }
        }

        internal void Activate()
        {
            if (CurrentActiveWindow != null && HiddenMode == true)
            {
                CurrentActiveWindow.Visible = true;
                CurrentActiveWindow.Activate();
            }
        }

        internal void ExitApplication()
        {
            if (
                MessageBox.Show("Do you want to exit the application", "Chat App", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        internal void SetHiddenMode(MainWindow Window)
        {
            CurrentActiveWindow = Window;
            HiddenMode = true;
        }

        private void InitializeSessionManager(String userName, String password, String serverName)
        {
            try
            {
                JabberID jd = new JabberID(userName);

                // Create a session using user credentials
                ConnectionOptions opts = new ConnectionOptions(serverName, jd.Server);
                //Session session = Session.Login(userName, password, Resource, serverName, Thread.CurrentThread.CurrentCulture);
                Session session = Session.Login(jd.UserName, password, Resource, true, opts);
                m_sessionMgr = new SessionManager(session);
            }
            catch (PacketException ex)
            {
                MessageBox.Show(string.Concat("Unable to Login :", ex.Message), "Login Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (StreamException ex)
            {
                MessageBox.Show(string.Concat("Unable to Login :", ex.Message), "Login Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Login failed. Please check the username and password and try again.", "Login Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetSession();
            }
        }

        private void ResetSession()
        {
            m_currentUser = null;
            CurrentActiveWindow = null;
            Contacts.Clear();
            m_ActiveChatUsers.Clear();

            if (null != m_mainWindow)
            {
                m_mainWindow.Dispose();
                m_mainWindow = null;
            }
            if (m_sessionMgr != null)
            {
                m_sessionMgr.Dispose();
                m_sessionMgr = null;
            }
        }

        public MessagingWindow GetMessagingWindow(JabberID jabberId)
        {
            MessagingWindow msgWindow = null;
            string strJabberId = jabberId.JabberIDNoResource;
            if (m_ActiveChatUsers.ContainsKey(strJabberId))
            {
                msgWindow = (MessagingWindow) m_ActiveChatUsers[strJabberId];
                msgWindow.Activate();
            }
            else
            {
                msgWindow = new MessagingWindow();
                msgWindow.RemoteUserJabberId = jabberId;
                msgWindow.Show();
                m_ActiveChatUsers.Add(strJabberId, msgWindow);
            }
            return msgWindow;
        }

        public void RemoveWindowForUser(string strJabberId)
        {
            m_ActiveChatUsers.Remove(strJabberId);
        }

        //private void IncomingRosterCallback(IAsyncResult ar)
        //{
        //    RosterResponse roster = m_sessionMgr.EndSend(ar) as RosterResponse;
        //    OnIncomingRoster(roster);
        //}

        /// <summary>
        /// Event received from the SessionManager when a RosterResponse is received.
        /// When a RosterReponse is received we need to update the tree
        /// Since we're creating new GUI objects, all of that work must
        /// be done on the main thread.  We'll go ahead and build the collection
        /// of groups in this background thread and then marshall back over.
        /// </summary>
        /// <param name="incomingRosterPacket"></param>
        //private void OnIncomingRoster(RosterResponse incomingRosterPacket)
        //{
        //    //work performed in here should be done on the main GUI thread
        //    //since it will be updating the treeview
        //    m_mainWindow.Invoke(new Session.PacketReceivedDelegate(IncomingRosterThreadSafe), new object[] { incomingRosterPacket });
        //}
        /// <summary>
        /// Updates the TreeView based on the Groups of RosterItems
        /// </summary>
        /// <param name="p"></param>
        //private void IncomingRosterThreadSafe(Packet p)
        //{
        //    RosterResponse IncomingRosterPacket = p as RosterResponse;
        //    try
        //    {
        //        m_mainWindow.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        //        foreach (RosterItem rsItem in IncomingRosterPacket.Items)
        //        {
        //            string groupName = rsItem.Group.ToString();
        //            TreeNode groupNode = new TreeNode(groupName);
        //            bool bAddGroup = true;
        //            foreach (TreeNode node in m_mainWindow.tvContacts.Nodes)
        //            {
        //                if (node.Text.Equals(groupName, StringComparison.OrdinalIgnoreCase))
        //                {
        //                    groupNode = node;
        //                    bAddGroup = false;
        //                    break;
        //                }
        //            }
        //            groupNode.Nodes.Add(rsItem.Name);
        //            if (bAddGroup)
        //            {
        //                m_mainWindow.tvContacts.Nodes.Add(groupNode);
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        m_mainWindow.Cursor = System.Windows.Forms.Cursors.Default;
        //    }
        //}
        public void SendCurrentPresence(AvailableRequest availableRequest)
        {
            Packet packet;
            m_currentPresence = availableRequest;
            if (m_currentPresence == null || m_currentPresence.Status == "Offline")
            {
                packet = new UnavailableRequest();
                m_sessionMgr.BeginSend(packet);
            }
            else
            {
                packet = (Packet) m_currentPresence.Clone();
                m_sessionMgr.BeginSend(packet);
            }
        }

        /// <summary>
        /// Sends the current presence information to the server
        /// </summary>
        public void SendCurrentPresence(LoginState loginState)
        {
            if (m_currentPresence == null)
            {
                m_currentPresence = new AvailableRequest();
            }
            m_currentPresence.Status = loginState.ToString();
            SendCurrentPresence(m_currentPresence);
        }

        /// <summary>
        /// Sends the current presence information to the specified JabberID
        /// </summary>
        /// <param name="ToUser"></param>
        public void SendCurrentPresence(JabberID ToUser)
        {
            Packet p;
            if (m_currentPresence == null)
            {
                p = new UnavailableRequest();
                m_sessionMgr.BeginSend(p);
            }
            else
            {
                AvailableRequest userSpecificPresence = (AvailableRequest) m_currentPresence.Clone();
                userSpecificPresence.To = ToUser;
                userSpecificPresence.From = m_sessionMgr.LocalUser;
                p = (Packet) userSpecificPresence;
                m_sessionMgr.BeginSend(p);
            }
        }

        public void BeginSend(Packet msgPacket)
        {
            m_sessionMgr.BeginSend(msgPacket);
        }

        public IAsyncResult BeginSend(Packet msgPacket, AsyncCallback callBack)
        {
            return m_sessionMgr.BeginSend(msgPacket, callBack);
        }

        public Packet EndSend(IAsyncResult asyncResult)
        {
            return m_sessionMgr.EndSend(asyncResult);
        }

        internal void LogOff()
        {
            SendCurrentPresence(LoginState.Offline);
            ResetSession();
            ShowLoginWindow();
        }

        internal void OPlaySound()
        {
            if (Settings.Default.FriendOnlinePlaySound == true)
            {
                SoundPlayer player = new SoundPlayer();
                player.LoadTimeout = 10000;
                player.Stream = Resources.ding;
                player.Play();
            }
        }

        public Packet SendPacket(Packet p)
        {
            return m_sessionMgr.Send(p);
        }

        public Packet SendPacket(Packet p, int maxMSWaitTime)
        {
            return m_sessionMgr.Send(p, maxMSWaitTime);
        }

        internal void chPlaySound()
        {
            if (Settings.Default.IncomingMessagePlaySound == true)
            {
                SoundPlayer player = new SoundPlayer();
                player.LoadTimeout = 10000;
                player.Stream = Resources.message;
                player.Play();
            }
        }
    }
}