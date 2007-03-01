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

namespace ChatApp
{
    /// <summary>
    /// Summary description for SessionManager.
    /// </summary>
    public class SessionManager : IDisposable
    {
        private Coversant.SoapBox.Core.Session _session;

        /// <summary>
        /// Holds the currently logged in user after they are authenticated on the LoginRegisterForm
        /// </summary>
        JabberID _localUser;

        public SessionManager(Session s)
        {
            _session = s;
            InitHandlersForSession();
        }


        public void Dispose()
        {
            _session.Dispose();
        }

        #region Delegates
        /// <summary>
        /// A delegate to perform simple GUI operations on the main thread
        /// </summary>
        public delegate void DoGUIWork();

        /// <summary>
        /// This is used when an exception occurs in the library on something
        /// that is on a background thread.  Generally these would be parsing errors
        /// or an error in the PacketFactory.  Exceptions should not really be received here
        /// unless something is wrong.  If one occurs it may warrant a bug report.
        /// </summary>
        /// <param name="ReceivedException"></param>
        public delegate void IncomingAsynchronousExceptionDelegate(Exception ReceivedException);
        #endregion

        public event AppController.IncomingMessageDelegate IncomingMessage;
        public event IncomingAsynchronousExceptionDelegate IncomingAsynchronousException;

        //Loads the trace GUI
        private void LoadTrace() 
        { 
        
        }

        #region Properties
        /// <summary>
        /// Disposes of all the underlying objects
        /// This should allow the app to shutdown
        /// </summary>
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

        /// <summary>
        /// Holds the currently logged in user.
        /// </summary>
        public JabberID LocalUser
        {
            get { return _localUser; }
            set { _localUser = value; }
        }

        public Session Session
        {
            get
            {
                return _session;
            }
        } 
        #endregion


        //Intializes the event handlers for all the packet types
        //we want to deal with.
        private void InitHandlersForSession()
        {
            // this._session.AddHandler(null, typeof(AbstractMessagePacket), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingMessage), true);
            this._session.AddHandler(typeof(ChatMessagePacket), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingMessage));
            this._session.AddHandler(typeof(RosterChange), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingRosterChange));
            this._session.AddHandler(typeof(AvailableRequest), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(UnavailableRequest), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(ProbeRequest), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(SubscribeRequest), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(SubscribedResponse), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(UnsubscribeRequest), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(UnsubscribedResponse), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(ErrorResponse), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            this._session.AddHandler(typeof(IQErrorResponse), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingIQError));
            this._session.AddHandler(typeof(IQResultResponse), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingIQResult));

            this._session.AddHandler(typeof(VersionRequest), new PacketFactory.PacketReceivedDelegate(HandleIncomingVersionRequest));
            this._session.AddHandler(typeof(TimeRequest), new PacketFactory.PacketReceivedDelegate(HandleIncomingTimeRequest));
            //          this._session.AddHandler(typeof(InvitationMessage), new PacketFactory.PacketReceivedDelegate(HandleIncomingChatInvitation));
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

        private void HandleIncomingDeclineChatInvitation(Packet p)
        {
            DeclineInvitationMessage decline = WConvert.ToDeclineInvitationMessage(p);
            MessageBox.Show(String.Format("The user {0} has declined your invitation request to {1}", decline.DeclineFrom.ToString(), decline.From.ToString()));
        }

        public void CloseStream()
        {
            _session.CloseStream();
        }


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
}
