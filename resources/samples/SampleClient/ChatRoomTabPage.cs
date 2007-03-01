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

using System;
using System.Windows.Forms;
using System.Collections;

using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core.MultiUserChat;
using Coversant.SoapBox.Core.MultiUserChat.IQ;
using Coversant.SoapBox.Core.MultiUserChat.Message;
using Coversant.SoapBox.Core.MultiUserChat.Presence;

namespace Coversant.SoapBox.SampleClient
{
	public class ChatRoomTabPage: TabPage
	{
		private JabberID _occupant = null;
		private string _messageHistory = string.Empty;
		private MultiUserChatForm _form = null;
		private SessionManager _sm = null;
		private Hashtable _users = new Hashtable();
		private string _subject = string.Empty;

		public delegate void JoinedRoomDelegate( ChatRoomTabPage sender, EventArgs e );
		public event JoinedRoomDelegate JoinedRoom;

		public delegate void LeftRoomDelegate( ChatRoomTabPage sender, EventArgs e );
		public event LeftRoomDelegate LeftRoom;

		public delegate void ChangedNickNameDelegate( ChatRoomTabPage sender, ChangeNickNameEventArgs e );
		public event ChangedNickNameDelegate ChangedNickName;

		public ChatRoomTabPage(JabberID occupantJID, MultiUserChatForm form, SessionManager sm): base(occupantJID.BareJID.ToString())
		{
            _occupant = occupantJID;
            _form = form;
            _sm = sm;

			_sm.Session.AddHandler(typeof(MessageErrorPacket), new Session.PacketReceivedDelegate(IncomingMessage));
			_sm.Session.AddHandler(typeof(GroupChatMessage), new Session.PacketReceivedDelegate(IncomingMessage));
			_sm.Session.AddHandler(typeof(ChangeSubjectMessage), new Session.PacketReceivedDelegate(IncomingMessage));
			_sm.Session.AddHandler(typeof(AvailableRequest), new Session.PacketReceivedDelegate(IncomingPresence));
			_sm.Session.AddHandler(typeof(ErrorResponse), new Session.PacketReceivedDelegate(IncomingPresence));
			_sm.Session.AddHandler(typeof(OccupantAvailableResponse), new Session.PacketReceivedDelegate(IncomingPresence));
			_sm.Session.AddHandler(typeof(OccupantUnavailableResponse), new Session.PacketReceivedDelegate(IncomingPresence));
		}

		private delegate void AddMessageDelegate( AbstractMessagePacket msg );
		public void AddMessage( AbstractMessagePacket msg )
		{
			if (msg is MessageErrorPacket)
			{
				MessageErrorPacket er = WConvert.ToMessageErrorPacket(msg);
				HandleMessageError(er);
			}
			else if (msg is GroupChatMessage)
			{
				GroupChatMessage gc = WConvert.ToGroupChatMessage(msg);
				AddMessageHistory(msg.From, gc.Body);
			}
			else if (msg is ChangeSubjectMessage)
			{
                ChangeSubjectMessage cs = WConvert.ToChangeSubjectMessage(msg);
                AddSubjectChange(cs);
			}
		}

		private delegate void HandlePresenceDelegate( PresencePacket p );
		public void HandlePresence( PresencePacket p )
		{
            if ( p is OccupantAvailableResponse )
				HandleMUCPresence(WConvert.ToOccupantAvailableResponse(p));
			else if ( p is OccupantUnavailableResponse )
				HandleMUCUnavailable(WConvert.ToOccupantUnavailableResponse(p));
			else if ( p is UnavailableRequest )
				HandleUserLeftRoom(p.From);
			else if ( p is AvailableRequest )
				HandleGCPresence(WConvert.ToAvailableRequest(p));
			else if ( p is ErrorResponse )
				HandlePresenceError(WConvert.ToPresenceErrorResponsePacket(p));
		}

		public void PopulateControls()
		{
            _form.txtHistory.Clear();
            TruncateText();
            _form.txtHistory.Text = _messageHistory;
            _form.txtHistory.ScrollToCaret();

            BindList();
            _form.grpChatRoom.Text = _subject;
		}

		private void BindList()
		{
			_form.lstUsers.DataSource = null;
            _form.lstUsers.DisplayMember = "NickName";
            _form.lstUsers.ValueMember = "OccupantJID";
            _form.lstUsers.DataSource = new ArrayList(_users.Values);
		}

		public void JoinRoom()
		{
            _form.tabRooms.SelectedTab = this;

            JoinRoomRequest j = new JoinRoomRequest(_occupant);
            _sm.SendAndForget(j);
		}

		public void SendPrivateMessage( string nickName, string msg) 
		{
            string userKey = string.Concat(this.Room.ToString().ToLower(), "/", nickName.ToLower());

            if (! _users.Contains(userKey))
                throw new ArgumentException("The specified user is not an occupant of this room");

            ((RoomOccupant)_users[userKey]).SendPrivateMessage(msg);
		}

		public void ClearMessageHistory()
		{
            _messageHistory = string.Empty;
            PopulateControls();
		}

		public void LeaveRoom()
		{
			try
			{
                _sm.Session.RemoveHandler(typeof(MessageErrorPacket), new Session.PacketReceivedDelegate(IncomingMessage));
                _sm.Session.RemoveHandler(typeof(GroupChatMessage), new Session.PacketReceivedDelegate(IncomingMessage));
                _sm.Session.RemoveHandler(typeof(ChangeSubjectMessage), new Session.PacketReceivedDelegate(IncomingMessage));
                _sm.Session.RemoveHandler(typeof(AvailableRequest), new Session.PacketReceivedDelegate(IncomingPresence));
                _sm.Session.RemoveHandler(typeof(ErrorResponse), new Session.PacketReceivedDelegate(IncomingPresence));
                _sm.Session.RemoveHandler(typeof(OccupantAvailableResponse), new Session.PacketReceivedDelegate(IncomingPresence));
                _sm.Session.RemoveHandler(typeof(OccupantUnavailableResponse), new Session.PacketReceivedDelegate(IncomingPresence));

                LeaveRoomRequest l = new LeaveRoomRequest(_occupant);
                _sm.SendAndForget(l);

                if (this.LeftRoom != null) 
					this.LeftRoom(this, new EventArgs());
			}
			catch{}
		}

		public JabberID Room
		{
			get { return _occupant.BareJID; }
		}

		public JabberID Occupant
		{
			get { return _occupant; }
		}

		public bool IsSelected()
		{
			return ((TabControl)this.Parent).SelectedTab.Equals(this);
		}

		public void NewIncomingMessage( string msg ) 
		{
            _sm.SendAndForget(new GroupChatMessage(this.Room, msg));
		}

		public void NewOutgoingMessage( string msg )
		{
            GroupChatMessage m = new GroupChatMessage(this.Room, msg);
            _sm.SendAndForget(m);
		}

		public void ChangeSubject( string newSubject )
		{
            _sm.SendAndForget(new ChangeSubjectMessage(this.Room, newSubject));
		}

		public void ChangeNickName( JabberID newNick )
		{
			_sm.SendAndForget(new ChangeNickNameRequest(newNick));
		}

		public void Invite( JabberID user )
		{
            _sm.SendAndForget(new InvitationMessage(this.Room, user, string.Concat("Come join me in ", this.Room.ToString())));
		}

		private void HandlePresenceError( ErrorResponse p )
		{
			string errText = null;
			if (p.UnderlyingException == null)
				errText = p.UnderlyingException.Message;
			else
				errText = p.ErrorText;

			AddMessageError(errText);		
		}

		private void HandleMessageError( MessageErrorPacket p )
		{
			string errText = null;
			if (p.UnderlyingException == null)
				errText = p.UnderlyingException.Message;
			else
				errText = p.ErrorText;

			AddMessageError(errText);		
		}

		private void HandleMUCUnavailable( OccupantUnavailableResponse u )
		{
            if ( u.StatusCode == MUCStatusEnum.OccupantNewNickName )
			{
				if ( u.From.Equals(_occupant) )
				{
                    _occupant.Resource = u.NickName;
                    if ( this.ChangedNickName != null) 
						this.ChangedNickName(this, new ChangeNickNameEventArgs(_occupant, u.From));
				}

                string changeMessage = string.Format("User {0} is changing their nick name to {1}", u.From.Resource, u.NickName);
				AddMessageHistory(this.Room, changeMessage);
			}
            HandleUserLeftRoom(u.From);
		}

		private void HandleUnavailable( UnavailableRequest u )
		{
			HandleUserLeftRoom ( u.From );
		}

		private void HandleUserLeftRoom( JabberID user )
		{
            string leftMessage = string.Format("User {0} has left the room", user.Resource);

            _users.Remove(user.ToString().ToLower());
            BindList();

            AddMessageHistory(this.Room, leftMessage);
		}

		private void HandleMUCPresence( OccupantAvailableResponse p )
		{
            OccupantAvailableResponse avail = WConvert.ToOccupantAvailableResponse(p);

			if ( avail.StatusCode == MUCStatusEnum.RoomCreated )
			{
                CreateInstantRoomRequest createReq = new CreateInstantRoomRequest(this.Room);
                _sm.BeginSend(createReq.ToPacket, new AsyncCallback(RoomCreatedCallback));
			}

            HandleGCPresence(p);
		}

		private delegate void LeaveRoomDelegate();
		private void RoomCreatedCallback( IAsyncResult ar )
		{
			try
			{
				Packet resp = _sm.Session.EndSend(ar);

				if (resp == null)
				{
					MessageBox.Show("Room creation failed.");
					this.BeginInvoke(new LeaveRoomDelegate(LeaveRoom));
				}
			}
			catch (PacketException ex)
			{
                MessageBox.Show(string.Format("Room creation failed: ", ex.Message));
                this.BeginInvoke(new LeaveRoomDelegate(LeaveRoom));
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Room creation failed: ", ex.Message));
				this.BeginInvoke(new LeaveRoomDelegate(LeaveRoom));
			}
		}

		private void HandleGCPresence( AvailableRequest p ) 
		{
			if (! _users.Contains(p.From.ToString().ToLower()) )
			{
                _users.Add(p.From.ToString().ToLower(), new RoomOccupant(p.From, _sm));
                BindList();
			}

            string presencemessage = string.Format("The user {0} is now {1}", p.From.Resource, p.Show.ToString());
            AddMessageHistory(this.Room, presencemessage);
		}

		private void AddMessageError( string errorText )
		{
            string errorMsg = string.Format("ERROR: {0}", errorText);

            AddMessageHistory(_occupant.BareJID, errorMsg);
		}

		private void AddSubjectChange( ChangeSubjectMessage changeSubject)
		{
            string subjectMsg = string.Format("Subject changed by {0}: {1}", changeSubject.From.Resource, changeSubject.Subject);

            _subject = changeSubject.Subject;
            _form.grpChatRoom.Text = _subject;
            AddMessageHistory(changeSubject.From.BareJID, subjectMsg);
		}

		private string FormatMessage( JabberID fromJID, string message ) 
		{
            if (fromJID.IsBareJID() || fromJID.IsServerJID())
                return string.Format("**{0}**", message);
            else
                return string.Format("<{0}> {1}", fromJID.Resource, message);
		}

		private void AddMessageHistory( JabberID fromJID, string message ) 
		{
            string newMsgLine = FormatMessage(fromJID, message);

			if (_messageHistory.Equals(string.Empty))
				_messageHistory = newMsgLine;
			else
			{
                newMsgLine = string.Concat(Environment.NewLine, newMsgLine);
                _messageHistory = string.Concat(_messageHistory, newMsgLine);
			}

			if (this.IsSelected())
			{
				TruncateText();
				_form.txtHistory.AppendText(newMsgLine);
				_form.txtHistory.ScrollToCaret();
			}
		}

		private void TruncateText()
		{
			if ( _messageHistory.Length > _form.txtHistory.MaxLength )
			{
				int overSize = _form.txtHistory.MaxLength - _messageHistory.Length;
				_messageHistory = _messageHistory.Remove(0, overSize);
				_form.txtHistory.Text.Remove(0, overSize);
			}
		}

		private void IncomingMessage( Packet p )
		{
            if (! IsPacketForMe(p)) return;

            this.BeginInvoke(new AddMessageDelegate(AddMessage), new Object[] {WConvert.ToAbstractMessagePacket(p)});
		}

		private void IncomingPresence ( Packet p )
		{
			if (! IsPacketForMe(p)) return;
			
			this.BeginInvoke(new HandlePresenceDelegate(HandlePresence), new  Object[] {WConvert.ToPresencePacket(p)});
		}

		private bool IsPacketForMe( Packet p )
		{
			return p.From.BareJID.Equals(_occupant.BareJID);
		}
	}
}
