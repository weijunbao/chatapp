
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

namespace ChatApp
{
    public class AppController:ApplicationContext
    {
        #region Static Data
        public static readonly string Resource = Settings.Default.Resource;
        public static readonly int Port = Settings.Default.Port;
        #endregion //Static Data

        private HiddenWindow MainWnd = null;
        private SessionManager m_sessionMgr;
        private static AppController m_Controller = null;
        private JabberID m_currentUser = null;
        private MainWindow m_mainWindow = null;
        private LoginWindow m_loginWnd = null;
        AvailableRequest m_currentPresence;
        private ContactList m_contacts;
        //private SessionManager m_sessioMgr;
        private Hashtable m_ActiveChatUsers = null;
        private ComponentFactory.Krypton.Toolkit.KryptonForm CurrentActiveWindow = null;
        private bool HiddenMode = false;


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
	
        /// <summary>
        /// To make this class a singleton
        /// </summary>
        public AppController()
        {
            MainWnd = new HiddenWindow();
            MainWnd.Visible = false;
            this.MainForm = MainWnd;

            MainWnd.Load += new EventHandler(MainWnd_load);
            m_contacts = new ContactList();
            m_ActiveChatUsers = new Hashtable();
        }

        void MainWnd_load(Object sender, EventArgs e)
        {
            StartApplication();
        }

        public void StartApplication()
        {
            ShowLoginWindow();
        }

        private void ShowLoginWindow()
        {
            LoginWindow loginWnd = new LoginWindow();
            loginWnd.FormClosed += new FormClosedEventHandler(loginWnd_FormClosed);
            loginWnd.Show();
        }
        
        void loginWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginWindow wnd = sender as LoginWindow;
            if (wnd != null && wnd.LoginSuccessful == true)
            {
                Start();
            }
            else
            {
                ExitApplication();
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
                // Create a session using user credentials
                Session session = Session.Login(userName, password, Resource, serverName, Thread.CurrentThread.CurrentCulture);
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
            catch (Exception ex)
            {
                MessageBox.Show("Login failed. Please check the username and password and try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetSession();
            }
        }

        private void ResetSession()
        {
            if (m_sessionMgr != null)
            {
                m_sessionMgr.Dispose();
                m_sessionMgr = null;
            }
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
            get { return MainWnd; }
        }



        public MessagingWindow GetMessagingWindow(string strJabberId)
        {
            MessagingWindow msgWindow = null;
            if (m_ActiveChatUsers.ContainsKey(strJabberId))
            {
                msgWindow = (MessagingWindow)m_ActiveChatUsers[strJabberId];
            }
            else
            {
                msgWindow = new MessagingWindow();
                msgWindow.CurrentUserJabberId = strJabberId;
                msgWindow.Show();
                m_ActiveChatUsers.Add(strJabberId, msgWindow);
            }
            return msgWindow;
        }

        public void RemoveWindowForUser(string strJabberId)
        {
            m_ActiveChatUsers.Remove(strJabberId);
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

       

        public MessageStoreController MessageStoreController
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        public LoginState LoginSate
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ConfigStoreController ConfigStoreController
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal bool Login(string UserName, string Password, string ServerName)
        {
            InitializeSessionManager(UserName, Password, ServerName);
            if (m_sessionMgr != null)
            {
                this.m_currentUser = new JabberID(UserName, ServerName, Resource);
                this.m_sessionMgr.Send(new AvailableRequest());
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void OnLoginWindowClosed(object sender, FormClosedEventArgs e)
        {
            LoginWindow loginWindow = sender as LoginWindow;
            if (loginWindow.LoginSuccessful)
            {
                AppController.Instance.Start();
            }
            else
            {
                Application.Exit();
            }
        }

        internal void Start()
        {
            MainWindow.Show();
            LoadContactList();
        }

        public void LoadContactList()
        {
            bool showallcontacts = true;
            
            // Get the Roster response synchronously
            RosterResponse roster = (RosterResponse)m_sessionMgr.Send(new RosterRequest());
            Contact contact;

            foreach (RosterItem rsItem in roster.Items)
            {
                contact = new Contact(rsItem.Name.ToString(),
                                        rsItem.Name.ToString(), 
                                        Properties.Settings.Default.Resource, 
                                        rsItem.JID.Server.ToString(), 
                                        rsItem.Group.ToString(), 
                                        LoginState.Offline);
                m_contacts.AddContact(contact);
            }
            m_mainWindow.UpdateContactList(showallcontacts);
        }

        private void IncomingRosterCallback(IAsyncResult ar)
        {
            RosterResponse roster = m_sessionMgr.EndSend(ar) as RosterResponse;
            OnIncomingRoster(roster);
        }

        //Event received from the SessionManager when a RosterResponse is received.
        //When a RosterReponse is received we need to update the tree
        //Since we're creating new GUI objects, all of that work must
        //be done on the main thread.  We'll go ahead and build the collection
        //of groups in this background thread and then marshall back over.
        private void OnIncomingRoster(RosterResponse incomingRosterPacket)
        {
            //work performed in here should be done on the main GUI thread
            //since it will be updating the treeview
            m_mainWindow.Invoke(new Session.PacketReceivedDelegate(IncomingRosterThreadSafe), new object[] { incomingRosterPacket });
        }

        //Updates the TreeView based on the Groups of RosterItems
        private void IncomingRosterThreadSafe(Packet p)
        {
            RosterResponse IncomingRosterPacket = p as RosterResponse;
            try
            {
                m_mainWindow.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                foreach (RosterItem rsItem in IncomingRosterPacket.Items)
                {
                    string groupName = rsItem.Group.ToString();
                    TreeNode groupNode = new TreeNode(groupName);

                    bool bAddGroup = true;
                    foreach (TreeNode node in m_mainWindow.tvContacts.Nodes)
                    {
                        if (node.Text.Equals(groupName, StringComparison.OrdinalIgnoreCase))
                        {
                            groupNode = node;
                            bAddGroup = false;
                            break;
                        }
                    }
                    groupNode.Nodes.Add(rsItem.Name);
                    if (bAddGroup)
                    {
                        m_mainWindow.tvContacts.Nodes.Add(groupNode);
                    }
                }
            }
            finally
            {
                m_mainWindow.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        //------------------------------------
        public void SendCurrentPresence(AvailableRequest pre)
        {
            Packet p;
            m_currentPresence = pre;
            if (m_currentPresence == null || m_currentPresence.Status == "Offline")
            {
                p = new UnavailableRequest();
                this.m_sessionMgr.BeginSend(p);
            }
            else
            {
                p = (Packet)m_currentPresence.Clone();
                this.m_sessionMgr.BeginSend(p);
            }
        }


        //--------------------------------------

        //Sends the current presence information to the server
        public void SendCurrentPresence()
        {
            Packet p;
            if (m_currentPresence == null)
            {
                p = new UnavailableRequest();
                this.m_sessionMgr.BeginSend(p);
            }
            else
            {
                p = (Packet)m_currentPresence.Clone();
                this.m_sessionMgr.BeginSend(p);
            }
        }

        //Sends the current presence information to the specified JabberID
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

        //Relays incoming message packets to subscribing objects
        public void OnIncomingMessage(Packet p)
        {
            if (IncomingMessage != null)
            {
                IncomingMessage((AbstractMessagePacket)p);
            }
        }


       


        //Relays incoming presence packets to subscribing objects
        public void OnIncomingPresence(Packet p)
        {
            if (IncomingPresence != null)
            {
                IncomingPresence((PresencePacket)p);
            }
        }

        public void OnIncomingRosterChange(Packet p) { if (IncomingRosterChange != null)IncomingRosterChange((RosterChange)p); }

        //Relays incoming IQError to subscribing objects
        public void OnIncomingIQError(Packet p) { if (IncomingIQError != null)IncomingIQError((IQErrorResponse)p); }

        //Relays incoming IQResult to subscribing objects
        public void OnIncomingIQResult(Packet p) { if (IncomingIQResult != null) IncomingIQResult((IQResultResponse)p); }

        public void BeginSend(Packet msgPacket)
        {
            m_sessionMgr.BeginSend(msgPacket);
        }

        internal void LogOff()
        {
            ResetSession();
            ShowLoginWindow();
        }
    }
}
