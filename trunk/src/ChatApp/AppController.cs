
using System;
using System.Collections.Generic;
using System.Text;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Base;
using System.Threading;
using ChatApp.Properties;
using System.Windows.Forms;
using System.Collections;

using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.IQ.Register;
using Coversant.SoapBox.Core.IQ;

using System.Media;                         // For playing sounds

using ComponentFactory.Krypton.Toolkit;
using System.Drawing;
using System.IO;
using Coversant.SoapBox.Core.IQ.Avatar;
using Coversant.SoapBox.Core.IQ.vCard;     

namespace ChatApp
{
    public class AppController:ApplicationContext
    {
        #region Static Data
        public static List<string> CapabilityExtension = new List<string>();
        
        public static readonly string CapabilityNode = @"http://www.google.com/xmpp/client/caps";
        public static readonly string CapabilityVersion = "1.0.0.66";
        public static readonly string Resource = Settings.Default.Resource;
        public static readonly int Port = Settings.Default.Port;
        #endregion //Static Data

        #region private Fields
        private HiddenWindow m_hiddenWnd = null;
        private SessionManager m_sessionMgr;
        private static AppController m_Controller = null;
        private JabberID m_currentUser = null;
        private MainWindow m_mainWindow = null;
        private AvailableRequest m_currentPresence;
        private ContactList m_contacts;
        private Hashtable m_ActiveChatUsers = null;
        private KryptonForm CurrentActiveWindow = null;
        private bool HiddenMode = false; 
        #endregion

        #region Event Declaration
        //Events used by the MainWindow, ChatWindow to receive packets from the lower level components.
        public delegate void IncomingMessageDelegate(AbstractMessagePacket IncomingMessagePacket);
        public event IncomingMessageDelegate IncomingMessage;
        public delegate void IncomingPresenceDelegate(PresencePacket IncomingPresencePacket);
        public event IncomingPresenceDelegate IncomingPresence;
        public delegate void IncomingRosterChangeDelegate(RosterChange IncomingRosterChangePacket);
        public event IncomingRosterChangeDelegate IncomingRosterChange;
        public delegate void IncomingIQErrorDelegate(IQErrorResponse IncomingIQErrorPacket);
        public event IncomingIQErrorDelegate IncomingIQError;
        public delegate void IncomingIQResultDelegate(IQResultResponse IncomingIQResultPacket);
        public event IncomingIQResultDelegate IncomingIQResult; 
        #endregion

        #region Fire Events
        //Relays incoming message packets to subscribing objects
        public void OnIncomingMessage(Packet packet)
        {
            if (IncomingMessage != null)
            {
                IncomingMessage((AbstractMessagePacket)packet);
            }
        }

        /// <summary>
        /// Relays incoming presence packets to subscribing objects
        /// </summary>
        /// <param name="p"></param>
        public void OnIncomingPresence(Packet packet)
        {
            HandlePresenceRequest(packet);
            if (IncomingPresence != null)
            {
                IncomingPresence((PresencePacket)packet);
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
                string displayString = String.Format("Allow User '{0}; to subscribe to your presence?", IncomingPresencePacket.From.JabberIDNoResource);
                if (MessageBox.Show(displayString, "Subscription Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SubscribedResponse resp = new SubscribedResponse(IncomingPresencePacket.From);
                    SessionManager.Send(resp);

                    SubscribeRequest subscribe = new SubscribeRequest(new JabberID(IncomingPresencePacket.From.JabberIDNoResource));
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
                string displayString = String.Format("User '{0}' has accepted your presence subscription request.", IncomingPresencePacket.From.JabberIDNoResource);
                MessageBox.Show(displayString, "Subscription Accept", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IncomingPresencePacket is UnsubscribedResponse)
            {
                //Let the user know when someone revoked our presence subscription
                string displayString = String.Format("User '{0}' rejected your reqeust.", IncomingPresencePacket.From.JabberIDNoResource);
                MessageBox.Show(displayString, "Subscription Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IncomingPresencePacket is AvailableRequest)
            {
                AvailableRequest availableReq = WConvert.ToAvailableRequest(IncomingPresencePacket);
                LoginState state = (LoginState)availableReq.Show;
                string userName = availableReq.From.UserName;

                Contact contact = AppController.Instance.Contacts[userName];
                if (contact != null)
                {
                    contact.UserStatus = state;
                }

                
            }
            else if (IncomingPresencePacket is UnavailableRequest)
            {
                UnavailableRequest avail = WConvert.ToUnavailableRequest(IncomingPresencePacket);
                string userName = avail.From.UserName;
                Contact contact = AppController.Instance.Contacts[userName];
                contact.UserStatus = LoginState.Offline;
            }
        }

        public void OnIncomingRosterChange(Packet packet)
        {
            if (IncomingRosterChange != null)
            {
                IncomingRosterChange((RosterChange)packet);
            }
        }

        //Relays incoming IQError to subscribing objects
        public void OnIncomingIQError(Packet packet)
        {
            if (IncomingIQError != null)
            {
                IncomingIQError((IQErrorResponse)packet);
            }
        }

        //Relays incoming IQResult to subscribing objects
        public void OnIncomingIQResult(Packet packet)
        {
            if (IncomingIQResult != null)
            {
                IncomingIQResult((IQResultResponse)packet);
            }
        } 
        #endregion // Fire Events

        #region Properties
        public MessageStoreController MessageStoreController
        {
            get { throw new System.NotImplementedException(); }
        }

        public ConfigStoreController ConfigStoreController
        {
            get { throw new System.NotImplementedException(); }
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
            get { throw new System.NotImplementedException(); }
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

        #endregion //Properties

        static AppController()
        {
            CapabilityExtension.Add("voice-v1");
            CapabilityExtension.Add("share-v1");
        }

        /// <summary>
        /// To make this class a singleton
        /// </summary>
        public AppController()
        {
            m_hiddenWnd = new HiddenWindow();
            m_hiddenWnd.Visible = false;
            this.MainForm = m_hiddenWnd;

            m_hiddenWnd.Load += new EventHandler(HiddenWnd_load);
            m_contacts = new ContactList();
            m_ActiveChatUsers = new Hashtable();
        }

        public HiddenWindow HiddenWindow
        {
            get 
            {
                return m_hiddenWnd;
            }
        }

        private void HiddenWnd_load(Object sender, EventArgs e)
        {
            StartApplication();
        }

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
                this.m_currentUser = m_sessionMgr.LocalUser;
                return true;
            }
            else
            {
                return false;
            }
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
            RosterResponse roster = (RosterResponse)m_sessionMgr.Send(new RosterRequest());

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
            if (MessageBox.Show("Do you want to exit the application", "Chat App", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Contacts.Dispose();
                Application.Exit();
            }
        }

        internal void SetHiddenMode(MainWindow m_mainWindow)
        {
            CurrentActiveWindow = m_mainWindow;
            this.HiddenMode = true;
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
                MessageBox.Show(string.Concat("Unable to Login :", ex.Message), "Login Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (StreamException ex)
            {
                MessageBox.Show(string.Concat("Unable to Login :", ex.Message), "Login Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch 
            {
                MessageBox.Show("Login failed. Please check the username and password and try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetSession();
            }
        }

        private void ResetSession()
        {
            this.m_currentUser = null;
            this.CurrentActiveWindow = null;
            this.Contacts.Clear();
            this.m_ActiveChatUsers.Clear();

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
                msgWindow = (MessagingWindow)m_ActiveChatUsers[strJabberId];
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
                this.m_sessionMgr.BeginSend(packet);
            }
            else
            {
                packet = (Packet)m_currentPresence.Clone();
                this.m_sessionMgr.BeginSend(packet);
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
                this.m_sessionMgr.BeginSend(p);
            }
            else
            {
                AvailableRequest userSpecificPresence = (AvailableRequest)m_currentPresence.Clone();
                userSpecificPresence.To = ToUser;
                userSpecificPresence.From = this.m_sessionMgr.LocalUser;
                p = (Packet)userSpecificPresence;
                this.m_sessionMgr.BeginSend(p);
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
            if (ChatApp.Properties.Settings.Default.FriendOnlinePlaySound == true)
            {
                SoundPlayer player = new SoundPlayer();
                player.LoadTimeout = 10000;
                player.Stream = ChatApp.Properties.Resources.ding;
                player.Play();
            }
        }

        public Packet SendPacket(Packet p)
        {
            return this.m_sessionMgr.Send(p);
        }

        public Packet SendPacket(Packet p, int maxMSWaitTime)
        {
            return this.m_sessionMgr.Send(p, maxMSWaitTime);
        }

        internal void chPlaySound()
        {
            if (ChatApp.Properties.Settings.Default.IncomingMessagePlaySound == true)
            {
                SoundPlayer player = new SoundPlayer();
                player.LoadTimeout = 10000;
                player.Stream = ChatApp.Properties.Resources.message;
                player.Play();
            }

        }


        

    }
}

