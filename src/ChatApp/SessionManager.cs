#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * SessionManager.cs - Manages the Jabber Session and provides a couple of
 * useful functions for other objects to use.
 * 
 * This file is modified from the Coversant SampleApplication 
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
#endregion //License Information, Copyright (c) 2006 Coversant

using System;
using System.Windows.Forms;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.IQ;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.IQ.Time;
using Coversant.SoapBox.Core.IQ.Version;
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.MultiUserChat.Message;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    /// <summary>
    /// Summary description for SessionManager.
    /// </summary>
    public class SessionManager : IDisposable
    {
        private Session _session;

        /// <summary>
        /// Holds the currently logged in user after they are authenticated on the LoginRegisterForm
        /// </summary>
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

        //public event AppController.IncomingMessageDelegate IncomingMessage;
        //public event IncomingAsynchronousExceptionDelegate IncomingAsynchronousException;

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
                Packet p = (Packet) new UnavailableRequest();
                BeginSend(p);
            }
            catch
            {
            }

            Session.Dispose();

            Application.Exit();
        }

        /// <summary>
        /// Holds the currently logged in user.
        /// </summary>
        public JabberID LocalUser
        {
            get { return _session.ClientJID; }
        }

        public Session Session
        {
            get { return _session; }
        }

        #endregion

        //Intializes the event handlers for all the packet types
        //we want to deal with.
        private void InitHandlersForSession()
        {
            // this._session.AddHandler(null, typeof(AbstractMessagePacket), new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingMessage), true);
            _session.AddHandler(typeof (ChatMessagePacket),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingMessage));
            _session.AddHandler(typeof (RosterChange),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingRosterChange));
            _session.AddHandler(typeof (AvailableRequest),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (UnavailableRequest),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (ProbeRequest),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (SubscribeRequest),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (SubscribedResponse),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (UnsubscribeRequest),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (UnsubscribedResponse),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (ErrorResponse),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingPresence));
            _session.AddHandler(typeof (IQErrorResponse),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingIQError));
            _session.AddHandler(typeof (IQResultResponse),
                                new PacketFactory.PacketReceivedDelegate(AppController.Instance.OnIncomingIQResult));

            _session.AddHandler(typeof (VersionRequest),
                                new PacketFactory.PacketReceivedDelegate(HandleIncomingVersionRequest));
            _session.AddHandler(typeof (TimeRequest),
                                new PacketFactory.PacketReceivedDelegate(HandleIncomingTimeRequest));
            //this._session.AddHandler(typeof(InvitationMessage), new PacketFactory.PacketReceivedDelegate(HandleIncomingChatInvitation));
            _session.AddHandler(typeof (DeclineInvitationMessage),
                                new PacketFactory.PacketReceivedDelegate(HandleIncomingDeclineChatInvitation));
        }

        private void HandleIncomingVersionRequest(Packet p)
        {
            VersionRequest req = WConvert.ToVersionRequest(p);
            VersionResponse resp =
                new VersionResponse(req, "SoapBox Sample Client", GetType().Assembly.GetName().Version.ToString(),
                                    Environment.OSVersion.ToString());
            Session.SendAndForget(resp);
        }

        private void HandleIncomingTimeRequest(Packet p)
        {
            TimeRequest req = WConvert.ToTimeRequest(p);
            TimeResponse resp = new TimeResponse(req);
            Session.SendAndForget(resp);
        }

        private void HandleIncomingDeclineChatInvitation(Packet p)
        {
            DeclineInvitationMessage decline = WConvert.ToDeclineInvitationMessage(p);
            MessageBox.Show(
                String.Format("The user {0} has declined your invitation request to {1}", decline.DeclineFrom.ToString(),
                              decline.From.ToString()));
        }

        public void CloseStream()
        {
            _session.CloseStream();
        }


        //Relays exceptions from the SoapBox Framework to subscribing objects
        //protected void AsynchronousException(Exception ex, long socketID) { if (IncomingAsynchronousException != null) IncomingAsynchronousException(ex); }

        public IAsyncResult BeginSend(Packet p)
        {
            return _session.BeginSend(p);
        }

        public IAsyncResult BeginSend(Packet p, AsyncCallback callback)
        {
            return _session.BeginSend(p, callback);
        }

        public Packet EndSend(IAsyncResult ar)
        {
            return _session.EndSend(ar);
        }


        public IAsyncResult BeginSend(Packet p, int timeout, AsyncCallback callback, object state)
        {
            return _session.BeginSend(p, timeout, callback, state);
        }

        public Packet Send(Packet p)
        {
            return _session.Send(p);
        }

        public Packet Send(Packet p, int maxMSWaitTime)
        {
            try
            {
                return _session.Send(p, maxMSWaitTime);
            }
            catch
            {
                return null;
            }
        }

        public void SendAndForget(Packet p)
        {
            Session.SendAndForget(p);
        }
    }
}