#region License Information, Copyright (c) 2006 Coversant
//Copyright (c) 2006 Coversant, Inc.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of 
//this software and associated documentation files (the "Software"), to deal in 
//the Software without restriction, including without limitation the rights to 
//use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of 
//the Software, and to permit persons to whom the Software is furnished to do so, 
//subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all 
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
//FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
//IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
//CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

//Manages the Jabber Session and provides a couple of 
//useful functions for other objects to use.
//This also loads the Winfessor Trace GUI for enhanced debugging
//and exploration.

using System;

using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.IQ.Register;
using Coversant.SoapBox.Core.IQ;
using Coversant.SoapBox.Core.IQ.Version;
using Coversant.SoapBox.Core.IQ.Time;
using Coversant.SoapBox.Core.MultiUserChat.Message;

using System.Windows.Forms;
using System.Collections;

namespace Coversant.SoapBox.SampleClient
{
    /// <summary>
    /// Summary description for SessionManager.
    /// </summary>
    public class SessionManager : IDisposable
    {
        public void Dispose()
        {
            _session.Dispose();
        }

        private Coversant.SoapBox.Core.Session _session;

        public SessionManager(Session s, LoginRegisterForm LoginForm)
        {
            _session = s;
            InitHandlersForSession();
        }

        //Holds the currently logged in user after
        //they are authenticated on the LoginRegisterForm
        JabberID _localUser;

        //Holds a reference to the ContactListForm
        //This is used mostly for shutting down the application
        ContactListForm _contactListForm;

        //Holds a reference to the ContactListForm
        //This is used mostly for shutting down the application
        MultiUserChatForm _multiUserChat;

        //A delegate to perform simple GUI operations on the main thread
        public delegate void DoGUIWork();

        //Events used by the Various forms in this project
        //to receive packets from the lower level components.
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

        //This is used when an exception occurs in the library on something
        //that is on a background thread.  Generally these would be parsing errors
        //or an error in the PacketFactory.  Exceptions should not really be received here
        //unless something is wrong.  If one occurs it may warrant a bug report.
        public delegate void IncomingAsynchronousExceptionDelegate(Exception ReceivedException);
        public event IncomingAsynchronousExceptionDelegate IncomingAsynchronousException;

        AvailableRequest _currentPresence;
        MessageWindows _messageWindows;

        public MultiUserChatForm ChatRooms
        {
            get { return _multiUserChat; }
            set { _multiUserChat = value; }
        }


        public MessageWindows MessageWindows
        {
            get
            {
                if (_messageWindows == null)
                    _messageWindows = new MessageWindows(this);
                return _messageWindows;
            }
        }

        public ContactListForm ContactList
        {
            get { return _contactListForm; }
            set { _contactListForm = value; }
        }

        public AvailableRequest CurrentPresence
        {
            get { return _currentPresence; }
            set
            {
                _currentPresence = value;

                if (_multiUserChat != null)
                    _multiUserChat.SendUpdatedPresence(_currentPresence);
            }
        }

        //Sends the current presence information to the server
        public void SendCurrentPresence()
        {
            Packet p;
            if (_currentPresence == null)
            {
                p = new UnavailableRequest();
                this._session.BeginSend(p);
            }
            else
            {
                p = (Packet)_currentPresence.Clone();
                this._session.BeginSend(p);
            }
        }

        //Sends the current presence information to the specified JabberID
        public void SendCurrentPresence(JabberID ToUser)
        {
            Packet p;
            if (_currentPresence == null)
            {
                p = new UnavailableRequest();
                this.BeginSend(p);
            }
            else
            {
                AvailableRequest userSpecificPresence = (AvailableRequest)_currentPresence.Clone();
                userSpecificPresence.To = ToUser;
                userSpecificPresence.From = this.LocalUser;
                p = (Packet)userSpecificPresence;
                this.BeginSend(p);
            }
        }

        //Loads the trace GUI
        private void LoadTrace() { }

        //Disposes of all the underlying objects
        //This should allow the app to shutdown
        public void Shutdown()
        {
            //let the world know we're offline
            try
            {
                Packet p = (Packet)new UnavailableRequest();
                this.BeginSend(p);
            }
            catch { }

            this.Session.Dispose();

            Application.Exit();
        }

        //Holds the currently logged in user.
        public JabberID LocalUser
        {
            get { return _localUser; }
            set { _localUser = value; }
        }

        public Session Session
        {
            get { return _session; }
        }

        //Loads a ContactList form
        public ContactListForm LoadContactList()
        {
            ContactListForm cl = new ContactListForm(this);

            cl.pbNoSSL.Visible = !this.Session.IsSecureConnection;
            cl.pbSSL.Visible = this.Session.IsSecureConnection;

            cl.Show();
            cl.Initialize();

            _contactListForm = cl;

            return _contactListForm;
        }

        public void LoadChatRooms()
        {
            if (_multiUserChat == null)
            {
                _multiUserChat = new MultiUserChatForm(this);
                _multiUserChat.Show();
            }
            else
                if (!_multiUserChat.Visible)
                {
                    _multiUserChat = new MultiUserChatForm(this);
                    _multiUserChat.Show();
                }

            _multiUserChat.Focus();
        }

        //Intializes the event handlers for all the packet types
        //we want to deal with.
        private void InitHandlersForSession()
        {

            //this._session.AddHandler(null, typeof(AbstractMessagePacket), new PacketFactory.PacketReceivedDelegate(OnIncomingMessage), true);
            this._session.AddHandler(typeof(ChatMessagePacket), new PacketFactory.PacketReceivedDelegate(OnIncomingMessage));            
            this._session.AddHandler(typeof(RosterChange), new PacketFactory.PacketReceivedDelegate(OnIncomingRosterChange));
            this._session.AddHandler(typeof(AvailableRequest), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(UnavailableRequest), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(ProbeRequest), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(SubscribeRequest), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(SubscribedResponse), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(UnsubscribeRequest), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(UnsubscribedResponse), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(ErrorResponse), new PacketFactory.PacketReceivedDelegate(OnIncomingPresence));
            this._session.AddHandler(typeof(IQErrorResponse), new PacketFactory.PacketReceivedDelegate(OnIncomingIQError));
            this._session.AddHandler(typeof(IQResultResponse), new PacketFactory.PacketReceivedDelegate(OnIncomingIQResult));

            this._session.AddHandler(typeof(VersionRequest), new PacketFactory.PacketReceivedDelegate(HandleIncomingVersionRequest));
            this._session.AddHandler(typeof(TimeRequest), new PacketFactory.PacketReceivedDelegate(HandleIncomingTimeRequest));
            this._session.AddHandler(typeof(InvitationMessage), new PacketFactory.PacketReceivedDelegate(HandleIncomingChatInvitation));
            this._session.AddHandler(typeof(DeclineInvitationMessage), new PacketFactory.PacketReceivedDelegate(HandleIncomingDeclineChatInvitation));
        }

        private void HandleIncomingVersionRequest(Packet p)
        {
            VersionRequest req = WConvert.ToVersionRequest(p);
            VersionResponse resp = new VersionResponse(req, "SoapBox Sample Client", this.GetType().Assembly.GetName().Version.ToString(), System.Environment.OSVersion.ToString());
            this.Session.SendAndForget(resp);
        }

        private void HandleIncomingTimeRequest(Packet p)
        {
            TimeRequest req = WConvert.ToTimeRequest(p);
            TimeResponse resp = new TimeResponse(req);
            this.Session.SendAndForget(resp);
        }

        private void HandleIncomingChatInvitation(Packet p)
        {
            InvitationMessage invite = WConvert.ToInvitationMessage(p);

            switch (MessageBox.Show(String.Format("The user {0} has invited you to the room {1}.  Would you like to join?", invite.InvitationFrom.ToString(), invite.From.ToString()), "Join Room?", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    {
                        _contactListForm.Invoke(new MethodInvoker(LoadChatRooms));

                        JabberID myOccupantJID = new JabberID(invite.From.ToString(), _localUser.UserName);
                        _multiUserChat.JoinRoomThreadSafe(myOccupantJID);
                        break;
                    }
                case DialogResult.No:
                    {
                        DeclineInvitationMessage decline = new DeclineInvitationMessage(invite.From, invite.InvitationFrom, "No, thank you.");
                        this.Session.SendAndForget(decline);
                        break;
                    }
            }

        }

        private void HandleIncomingDeclineChatInvitation(Packet p)
        {
            DeclineInvitationMessage decline = WConvert.ToDeclineInvitationMessage(p);

            MessageBox.Show(String.Format("The user {0} has declined your invitation request to {1}", decline.DeclineFrom.ToString(), decline.From.ToString()));
        }

        public void CloseStream()
        {
            _session.CloseStream();
        }

        //Relays incoming message packets to subscribing objects
        private void OnIncomingMessage(Packet p) { if (IncomingMessage != null) IncomingMessage((AbstractMessagePacket)p); }

        //Relays incoming presence packets to subscribing objects
        private void OnIncomingPresence(Packet p) { if (IncomingPresence != null)IncomingPresence((PresencePacket)p); }

        private void OnIncomingRosterChange(Packet p) { if (IncomingRosterChange != null)IncomingRosterChange((RosterChange)p); }

        //Relays incoming IQError to subscribing objects
        private void OnIncomingIQError(Packet p) { if (IncomingIQError != null)IncomingIQError((IQErrorResponse)p); }

        //Relays incoming IQResult to subscribing objects
        private void OnIncomingIQResult(Packet p) { if (IncomingIQResult != null) IncomingIQResult((IQResultResponse)p); }

        //Relays exceptions from the SoapBox Framework to subscribing objects
        //protected void AsynchronousException(Exception ex, long socketID) { if (IncomingAsynchronousException != null) IncomingAsynchronousException(ex); }

        public IAsyncResult BeginSend(Packet p)
        {
            return this._session.BeginSend(p);
        }

        public IAsyncResult BeginSend(Packet p, AsyncCallback callback)
        {
            return this._session.BeginSend(p, callback);
        }

        public Packet EndSend(IAsyncResult ar)
        {
            return this._session.EndSend(ar);
        }


        public IAsyncResult BeginSend(Packet p, int timeout, AsyncCallback callback, object state)
        {
            return this._session.BeginSend(p, timeout, callback, state);
        }

        public Packet Send(Packet p)
        {
            return this._session.Send(p);
        }

        public Packet Send(Packet p, int maxMSWaitTime)
        {
            return this._session.Send(p, maxMSWaitTime);
        }

        public void SendAndForget(Packet p)
        {
            this.Session.SendAndForget(p);
        }
    }

    public class MessageWindows : Hashtable
    {
        SessionManager _sessionManager;

        public MessageWindows(SessionManager sessionMgr) : base() { _sessionManager = sessionMgr; }

        public MessageForm Add(JabberID RemoteUserJID, MessageForm msgWindow)
        {
            base.Add(RemoteUserJID.ToString().ToLower(), msgWindow);
            return msgWindow;
        }

        public MessageForm Show(JabberID RemoteUserJID) { return GetMessageWindow(RemoteUserJID); }
        public MessageForm Show(JabberID RemoteUserJID, MessagePacket initialMessage)
        {
            return GetMessageWindow(RemoteUserJID, initialMessage);
        }

        public MessageForm Show(MessagePacket initialMessage) { return GetMessageWindow(initialMessage.From, initialMessage); }

        public void Remove(JabberID jid)
        {
            try { base.Remove(jid.ToString().ToLower()); }
            catch { }
        }

        public MessageForm Item(JabberID jid) { return (MessageForm)base[jid.ToString().ToLower()]; }

        public bool Contains(JabberID jid) { return base.Contains(jid.ToString().ToLower()); }

        //Grabs a message window matching the JID from the collection
        //If a window doesn't exist one is created.
        //If an InitialMessage is provided the window is populated
        //with the message.
        private MessageForm GetMessageWindow(JabberID JID) { return GetMessageWindow(JID, null); }
        private MessageForm GetMessageWindow(JabberID JID, MessagePacket InitialMessage)
        {
            if (this.Contains(JID))
            {
                try
                {
                    MessageForm msgWindow = (MessageForm)this.Item(JID);
                    msgWindow.Show();
                    return msgWindow;
                }
                catch
                {
                    this.Remove(JID);
                    return CreateNewWindow(JID, InitialMessage);
                }
            }
            else
            {
                foreach (string key in this.Keys)
                {
                    JabberID keyJID = JabberID.Parse(key);
                    if (keyJID.Equals(JID, JabberID.JabberIDCompareEnum.JabberIDCompareNoResource))
                    {
                        MessageForm msgWindow = this.Item(keyJID);

                        //'*** Add a key to the hashtable that has the full jid (user@server/resource) in it
                        this.Add(JID, msgWindow);

                        //'*** Remove the old user@server jid
                        this.Remove(keyJID);
                        msgWindow.Show();
                        return msgWindow;
                    }
                }

            }
            return CreateNewWindow(JID, InitialMessage);
        }

        private MessageForm CreateNewWindow(JabberID JID, MessagePacket initialMessage)
        {
            //Populate the window with the initial message if it
            //was provided.
            MessageForm newWindow;

            if (initialMessage == null)
            {
                MessageForm m = new MessageForm(_sessionManager, JID);
                m.MessageThreadID = System.Guid.NewGuid().ToString();
                m.Show();
                newWindow = m;
            }
            else
            {
                MessageForm m = new MessageForm(_sessionManager, _sessionManager.LocalUser, initialMessage.From);
                m.Show();                
                m.MessageThreadID = initialMessage.Thread;
                m.PostMessage(initialMessage);
                newWindow = m;
            }
            this.Add(JID, newWindow);

            newWindow.BringToFront();
            return newWindow;
        }
    }
}
