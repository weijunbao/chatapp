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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core.IQ.Disco;
using Coversant.SoapBox.Core.IQ.Browse;
using Coversant.SoapBox.Core.IQ.Agents;
using Coversant.SoapBox.Core.IQ.Agent;
using Coversant.SoapBox.Core.MultiUserChat;

namespace Coversant.SoapBox.SampleClient
{
	/// <summary>
	/// Summary description for MultiUserChatForm.
	/// </summary>
	public class MultiUserChatForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MenuItem mnuLeaveRoom;
		internal System.Windows.Forms.MenuItem mnuChangeSubject;
		internal System.Windows.Forms.MenuItem mnuChangeNickName;
		internal System.Windows.Forms.MenuItem mnuJoinRoom;
		internal System.Windows.Forms.MenuItem mnuRefreshList;
		internal System.Windows.Forms.MenuItem MenuItem4;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.GroupBox grpMessageComposition;
		internal System.Windows.Forms.TextBox txtOutgoingMessage;
		internal System.Windows.Forms.GroupBox grpChatRoom;
		internal System.Windows.Forms.ListBox lstUsers;
		internal System.Windows.Forms.TextBox txtHistory;
		internal System.Windows.Forms.ContextMenu mnuUserContext;
		internal System.Windows.Forms.MenuItem mnuSendPrivateMessage;
		internal System.Windows.Forms.MenuItem mnuRequestTime;
		internal System.Windows.Forms.MenuItem mnuRequestVersion;
		internal System.Windows.Forms.MenuItem mnuInvite;
		internal System.Windows.Forms.MenuItem mnuHelp;
		internal System.Windows.Forms.TabControl tabRooms;
		internal System.Windows.Forms.MainMenu mnuMain;
		internal System.Windows.Forms.MenuItem MenuItem1;
		internal System.Windows.Forms.MenuItem mnuExit;
		internal System.Windows.Forms.MenuItem MenuItem3;
		internal System.Windows.Forms.Label lblNotInRoom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		private SessionManager _sm = null;
		private Hashtable _rooms = new Hashtable();

		public MultiUserChatForm( SessionManager sm )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_sm = sm;
			_sm.ChatRooms = this;
			base.Closed += new EventHandler(MultiUserChatForm_Closed);
			base.GotFocus += new EventHandler(MultiUserChatForm_GotFocus);
			base.Load += new EventHandler(MultiUserChatForm_Load);
			base.KeyDown += new KeyEventHandler(MultiUserChatForm_KeyDown);
			tabRooms.SelectedIndexChanged += new EventHandler(tabRooms_SelectedIndexChanged);
			lstUsers.DoubleClick += new EventHandler(lstUsers_DoubleClick);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MultiUserChatForm));
			this.mnuLeaveRoom = new System.Windows.Forms.MenuItem();
			this.mnuChangeSubject = new System.Windows.Forms.MenuItem();
			this.mnuChangeNickName = new System.Windows.Forms.MenuItem();
			this.mnuJoinRoom = new System.Windows.Forms.MenuItem();
			this.mnuRefreshList = new System.Windows.Forms.MenuItem();
			this.MenuItem4 = new System.Windows.Forms.MenuItem();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.grpMessageComposition = new System.Windows.Forms.GroupBox();
			this.txtOutgoingMessage = new System.Windows.Forms.TextBox();
			this.grpChatRoom = new System.Windows.Forms.GroupBox();
			this.lstUsers = new System.Windows.Forms.ListBox();
			this.mnuUserContext = new System.Windows.Forms.ContextMenu();
			this.mnuSendPrivateMessage = new System.Windows.Forms.MenuItem();
			this.mnuRequestTime = new System.Windows.Forms.MenuItem();
			this.mnuRequestVersion = new System.Windows.Forms.MenuItem();
			this.txtHistory = new System.Windows.Forms.TextBox();
			this.mnuInvite = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.tabRooms = new System.Windows.Forms.TabControl();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.MenuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.MenuItem3 = new System.Windows.Forms.MenuItem();
			this.lblNotInRoom = new System.Windows.Forms.Label();
			this.Panel1.SuspendLayout();
			this.grpMessageComposition.SuspendLayout();
			this.grpChatRoom.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuLeaveRoom
			// 
			this.mnuLeaveRoom.Index = 1;
			this.mnuLeaveRoom.Text = "&Leave Room";
			this.mnuLeaveRoom.Click += new System.EventHandler(this.mnuLeaveRoom_Click);
			// 
			// mnuChangeSubject
			// 
			this.mnuChangeSubject.Index = 2;
			this.mnuChangeSubject.Text = "Change &Subject";
			this.mnuChangeSubject.Click += new System.EventHandler(this.mnuChangeSubject_Click);
			// 
			// mnuChangeNickName
			// 
			this.mnuChangeNickName.Index = 3;
			this.mnuChangeNickName.Text = "Change &Nick Name";
			this.mnuChangeNickName.Click += new System.EventHandler(this.mnuChangeNickName_Click);
			// 
			// mnuJoinRoom
			// 
			this.mnuJoinRoom.Index = 0;
			this.mnuJoinRoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuRefreshList,
																						this.MenuItem4});
			this.mnuJoinRoom.Text = "&Join Room";
			this.mnuJoinRoom.Click += new System.EventHandler(this.mnuJoinRoom_Click);
			// 
			// mnuRefreshList
			// 
			this.mnuRefreshList.Index = 0;
			this.mnuRefreshList.Text = "&Refresh  List";
			this.mnuRefreshList.Click += new System.EventHandler(this.mnuRefreshList_Click);
			// 
			// MenuItem4
			// 
			this.MenuItem4.Index = 1;
			this.MenuItem4.Text = "-";
			// 
			// Panel1
			// 
			this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Panel1.Controls.Add(this.grpMessageComposition);
			this.Panel1.Controls.Add(this.grpChatRoom);
			this.Panel1.Location = new System.Drawing.Point(8, 32);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(600, 376);
			this.Panel1.TabIndex = 4;
			// 
			// grpMessageComposition
			// 
			this.grpMessageComposition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpMessageComposition.Controls.Add(this.txtOutgoingMessage);
			this.grpMessageComposition.Location = new System.Drawing.Point(4, 336);
			this.grpMessageComposition.Name = "grpMessageComposition";
			this.grpMessageComposition.Size = new System.Drawing.Size(592, 40);
			this.grpMessageComposition.TabIndex = 9;
			this.grpMessageComposition.TabStop = false;
			this.grpMessageComposition.Text = "Message Composition And Commands (User Enter To Send.  Type /help for commands li" +
				"st.)";
			// 
			// txtOutgoingMessage
			// 
			this.txtOutgoingMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutgoingMessage.Location = new System.Drawing.Point(3, 16);
			this.txtOutgoingMessage.Name = "txtOutgoingMessage";
			this.txtOutgoingMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutgoingMessage.Size = new System.Drawing.Size(586, 20);
			this.txtOutgoingMessage.TabIndex = 5;
			this.txtOutgoingMessage.Text = "";
			// 
			// grpChatRoom
			// 
			this.grpChatRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpChatRoom.Controls.Add(this.lstUsers);
			this.grpChatRoom.Controls.Add(this.txtHistory);
			this.grpChatRoom.Location = new System.Drawing.Point(4, 0);
			this.grpChatRoom.Name = "grpChatRoom";
			this.grpChatRoom.Size = new System.Drawing.Size(592, 328);
			this.grpChatRoom.TabIndex = 8;
			this.grpChatRoom.TabStop = false;
			// 
			// lstUsers
			// 
			this.lstUsers.ContextMenu = this.mnuUserContext;
			this.lstUsers.Dock = System.Windows.Forms.DockStyle.Right;
			this.lstUsers.HorizontalScrollbar = true;
			this.lstUsers.Location = new System.Drawing.Point(477, 16);
			this.lstUsers.Name = "lstUsers";
			this.lstUsers.Size = new System.Drawing.Size(112, 303);
			this.lstUsers.Sorted = true;
			this.lstUsers.TabIndex = 6;
			// 
			// mnuUserContext
			// 
			this.mnuUserContext.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.mnuSendPrivateMessage,
																						   this.mnuRequestTime,
																						   this.mnuRequestVersion});
			// 
			// mnuSendPrivateMessage
			// 
			this.mnuSendPrivateMessage.Index = 0;
			this.mnuSendPrivateMessage.Text = "Send Private &Message";
			this.mnuSendPrivateMessage.Click += new System.EventHandler(this.mnuSendPrivateMessage_Click);
			// 
			// mnuRequestTime
			// 
			this.mnuRequestTime.Index = 1;
			this.mnuRequestTime.Text = "Request &Time";
			this.mnuRequestTime.Click += new System.EventHandler(this.mnuRequestTime_Click);
			// 
			// mnuRequestVersion
			// 
			this.mnuRequestVersion.Index = 2;
			this.mnuRequestVersion.Text = "Request &Version";
			this.mnuRequestVersion.Click += new System.EventHandler(this.mnuRequestVersion_Click);
			// 
			// txtHistory
			// 
			this.txtHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHistory.Location = new System.Drawing.Point(8, 16);
			this.txtHistory.Multiline = true;
			this.txtHistory.Name = "txtHistory";
			this.txtHistory.ReadOnly = true;
			this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHistory.Size = new System.Drawing.Size(464, 309);
			this.txtHistory.TabIndex = 4;
			this.txtHistory.Text = "";
			// 
			// mnuInvite
			// 
			this.mnuInvite.Index = 4;
			this.mnuInvite.Text = "&Invite User To Room";
			this.mnuInvite.Click += new System.EventHandler(this.mnuInvite_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.Text = "&Help";
			this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
			// 
			// tabRooms
			// 
			this.tabRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabRooms.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabRooms.Location = new System.Drawing.Point(8, 2);
			this.tabRooms.Name = "tabRooms";
			this.tabRooms.SelectedIndex = 0;
			this.tabRooms.Size = new System.Drawing.Size(600, 16);
			this.tabRooms.TabIndex = 3;
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.MenuItem1,
																					this.MenuItem3,
																					this.mnuHelp});
			// 
			// MenuItem1
			// 
			this.MenuItem1.Index = 0;
			this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuExit});
			this.MenuItem1.Text = "&File";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 0;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// MenuItem3
			// 
			this.MenuItem3.Index = 1;
			this.MenuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuJoinRoom,
																					  this.mnuLeaveRoom,
																					  this.mnuChangeSubject,
																					  this.mnuChangeNickName,
																					  this.mnuInvite});
			this.MenuItem3.Text = "&Tools";
			// 
			// lblNotInRoom
			// 
			this.lblNotInRoom.BackColor = System.Drawing.SystemColors.Control;
			this.lblNotInRoom.Location = new System.Drawing.Point(16, 2);
			this.lblNotInRoom.Name = "lblNotInRoom";
			this.lblNotInRoom.Size = new System.Drawing.Size(216, 16);
			this.lblNotInRoom.TabIndex = 5;
			this.lblNotInRoom.Text = "You are not currenty in a room";
			// 
			// MultiUserChatForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 417);
			this.Controls.Add(this.lblNotInRoom);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.tabRooms);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Menu = this.mnuMain;
			this.Name = "MultiUserChatForm";
			this.Text = "Multi User Chats";
			this.Panel1.ResumeLayout(false);
			this.grpMessageComposition.ResumeLayout(false);
			this.grpChatRoom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void JoinRoomThreadSafe ( JabberID occupantJID )
		{
			this.BeginInvoke(new JoinRoomDelegate(JoinRoom), new object[] {occupantJID});
		}

		private delegate void JoinRoomDelegate(JabberID occupantJID);
		public void JoinRoom( JabberID occupantJID)
		{
			if ( _rooms.Contains(occupantJID.ToString().ToLower()) )
			{
				ChatRoomTabPage t = (ChatRoomTabPage)_rooms[occupantJID.ToString().ToLower()];
				tabRooms.SelectedTab = t;
			}
			else
			{
				ChatRoomTabPage t = new ChatRoomTabPage(occupantJID, this, _sm);
				tabRooms.TabPages.Add(t);
				_rooms.Add(occupantJID.ToString().ToLower(), t);

				lblNotInRoom.Visible = false;

				t.LeftRoom += new ChatRoomTabPage.LeftRoomDelegate(t_LeftRoom);
				t.ChangedNickName += new ChatRoomTabPage.ChangedNickNameDelegate(t_ChangedNickName);
				t.JoinRoom();
			}
		}

		public void LeaveRoom(JabberID occupantJID)
		{
			if ( _rooms.Count == 0 ) return;

			ChatRoomTabPage t = (ChatRoomTabPage)_rooms[occupantJID.ToString().ToLower()];
			t.LeaveRoom();
		}

		private void t_LeftRoom(ChatRoomTabPage sender, EventArgs e)
		{
			_rooms.Remove(sender.Occupant.ToString().ToLower());
			tabRooms.TabPages.Remove(sender);
			sender.LeftRoom -= new ChatRoomTabPage.LeftRoomDelegate(t_LeftRoom);

			if (tabRooms.TabCount == 0)
			{
				txtHistory.Clear();
				txtOutgoingMessage.Clear();
				lstUsers.DataSource = null;
				lstUsers.Items.Clear();
				lblNotInRoom.Visible = true;
				grpChatRoom.Text = string.Empty;
			}
			else
				tabRooms.TabIndex = 0;
		}

		private void t_ChangedNickName(ChatRoomTabPage sender, ChangeNickNameEventArgs e)
		{
			_rooms.Remove(e.OldOccupant.ToString().ToLower());
			_rooms.Add(e.NewOccupant.ToString().ToLower(), sender);
		}

		public JabberID CurrentRoom
		{
			get 
			{
				if (CurrentTab == null) return null;
				return CurrentTab.Room;
			}
		}

		public ChatRoomTabPage CurrentTab
		{
			get
			{
				if (tabRooms.SelectedTab == null)
				{
					if (_rooms.Count > 0) 
						tabRooms.SelectedIndex = 0;
					else
						return null;
				}

				return (ChatRoomTabPage)tabRooms.SelectedTab;
			}
		}

		public void SendUpdatedPresence(AvailableRequest p)
		{
			if (_rooms.Count == 0) return;

			AvailableRequest myPresence = WConvert.ToAvailableRequest(p.Clone());
			foreach(ChatRoomTabPage chat in _rooms.Values)
			{
				myPresence.To = chat.Occupant;
				_sm.SendAndForget(myPresence);
			}
		}

		public void SetupJoinRoomCommand(JabberID server)
		{
			string room = null;

			if (server.IsBareJID())
			{
				int resourceLoc = RoomCommands.Join.Length + server.ToString().Length + 1;

				room = string.Concat(server.ToString(), "/", _sm.LocalUser.UserName);
				txtOutgoingMessage.Text = string.Concat(RoomCommands.Join, room);
				txtOutgoingMessage.Select(resourceLoc, _sm.LocalUser.UserName.Length);
			}
			else if (server.IsServerJID())
			{
				room = string.Concat("@", server.ToString(), "/", _sm.LocalUser.UserName);
				txtOutgoingMessage.Text = string.Concat(RoomCommands.Join, room);
				txtOutgoingMessage.Select(RoomCommands.Join.Length, 0);
			}
			else if (server.IsFullJID())
			{
				room = server.ToString();
				int resourceLoc = room.LastIndexOf("/") + 1;

				txtOutgoingMessage.Text = string.Concat(RoomCommands.Join, room);
				txtOutgoingMessage.Select(resourceLoc, server.Resource.Length);
			}

			txtOutgoingMessage.Focus();
		}

		private void MultiUserChatForm_Closed(object sender, EventArgs e)
		{
			while ( _rooms.Count > 0)
			{
				ChatRoomTabPage chat = this.CurrentTab;
				chat.LeaveRoom();
			}
		}

		private void tabRooms_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_rooms.Count == 0) return;

			this.CurrentTab.PopulateControls();
			txtOutgoingMessage.Focus();
		}

		private void lstUsers_DoubleClick(object sender, EventArgs e)
		{
			if (_rooms.Count == 0 && lstUsers.SelectedIndex != -1) return;

			RoomOccupant roomItm = (RoomOccupant)lstUsers.SelectedItem;
			roomItm.SendPrivateMessage();
		}

		private void MultiUserChatForm_GotFocus(object sender, EventArgs e)
		{
			txtOutgoingMessage.Focus();
		}

	#region Menus
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuJoinRoom_Click(object sender, System.EventArgs e)
		{
			SetupJoinRoomCommand(JabberID.Parse("conference.xmpp.winfessor.com"));
		}

		private void mnuLeaveRoom_Click(object sender, System.EventArgs e)
		{
			if (_rooms.Count == 0) return;

			CurrentTab.LeaveRoom();
		}

		private void mnuChangeSubject_Click(object sender, System.EventArgs e)
		{
			if (_rooms.Count == 0) return;
		
			const string SUBJECT = "New SUBJECT";

			txtOutgoingMessage.Text = string.Concat(RoomCommands.Subject, SUBJECT);
			txtOutgoingMessage.Select(RoomCommands.Subject.Length, SUBJECT.Length);
			txtOutgoingMessage.Focus();
		}

		private void mnuChangeNickName_Click(object sender, System.EventArgs e)
		{
			if (_rooms.Count == 0) return;
		
			string nick = CurrentTab.Occupant.Resource;

			txtOutgoingMessage.Text = string.Concat(RoomCommands.Nick, nick);
			txtOutgoingMessage.Select(RoomCommands.Nick.Length, nick.Length);
			txtOutgoingMessage.Focus();
		}

		private void mnuInvite_Click(object sender, System.EventArgs e)
		{
			if (_rooms.Count == 0) return;
		
			const string defaultUser = "user@server";

			txtOutgoingMessage.Text = string.Concat(RoomCommands.Invite, defaultUser);
			txtOutgoingMessage.Select(RoomCommands.Invite.Length, defaultUser.Length);
			txtOutgoingMessage.Focus();
		}

		private void mnuHelp_Click(object sender, System.EventArgs e)
		{
			RoomCommands.ProcessGlobalMessage(RoomCommands.Help, this);
		}

		private void mnuRefreshList_Click(object sender, System.EventArgs e)
		{
			RefreshChatRoomsList();
		}
		#endregion

	#region Discovery Of Chat Room Services On Local Server
		private void MultiUserChatForm_Load(object sender, EventArgs e)
		{
			RefreshChatRoomsList();
		}

		public void RefreshChatRoomsList()
		{
            //clear all the menus
            while ( mnuJoinRoom.MenuItems.Count > 2 )
                mnuJoinRoom.MenuItems.RemoveAt(2);
            

            //start the disco request
            DiscoveryItemsRequest req = new DiscoveryItemsRequest(_sm.LocalUser.ServerJID);
            _sm.BeginSend(req.ToPacket, new AsyncCallback(DiscoCompleteCallback));
		}

		private void DiscoCompleteCallback( IAsyncResult ar )
		{
			try
			{
                Packet p = _sm.Session.EndSend(ar);

				if ( p == null || ! (p is DiscoveryItemsResponse) )
					//this server probably doesn't support disco, try browse
					BrowseForChatServers();
				else
				{
                    DiscoveryItemsResponse resp = WConvert.ToDiscoItemsResponse(p);

                    //request info for each of the items returned by the server
                    //the info will tell is whether or not it is a chat server
					foreach (DiscoveryItem itm in resp.Items)
					{
                        //chat servers usually don't use node, only request items with no node value
						if (itm.Node.Equals(string.Empty))
						{
                            DiscoveryInfoRequest req = new DiscoveryInfoRequest(itm.JID);
                            _sm.BeginSend(req.ToPacket, new AsyncCallback(ServiceInfoCallback));
						}
					}
				}
			}
			catch
			{
                //this server probably doesn't support disco, try browse
                BrowseForChatServers();
			}
		}

		private void ServiceInfoCallback( IAsyncResult ar )
		{
			try
			{
                Packet p = _sm.Session.EndSend(ar);

                if ((p != null) && (p is DiscoveryInfoResponse))
                    //throw this request back up to the gui thread for parsing using invoke.
                    //this has the nice side effect of doing thread synchronization for us using the window message queue.
                    this.BeginInvoke(new ParseDiscoInfoResultsDelegate(ParseDiscoInfoResults), new Object[] {WConvert.ToDiscoInfoResponse(p)});
			}
			catch
			{
				//ignore any errors here.  it could be that the server doesn't support info for the jid we requested
			}
		}
		
		private delegate void ParseDiscoInfoResultsDelegate(DiscoveryInfoResponse result);
		private void ParseDiscoInfoResults(DiscoveryInfoResponse result)
		{
            this.Cursor = Cursors.WaitCursor;

			string MUCNS = RegisteredJabberNamespaces.MultiUserChat;
			string GCNS = MUCDiscoFeatures.GroupChat;
			if (result.Features.Contains(MUCNS) || result.Features.Contains(GCNS))
			{
                const int RoomItemsTimeout = 30000;

                //this is a service supporting chat rooms.  add it to the join room drop down.
                ChatServerMenuItem itm = AddChatServerMenuItem(result.From);

                //look for chat rooms on this service
                DiscoveryItemsRequest req = new DiscoveryItemsRequest(result.From);
                _sm.BeginSend(req.ToPacket, RoomItemsTimeout, new AsyncCallback(ChatServiceItemsCallback), itm);
			}
			
            this.Cursor = Cursors.Default;
		}

		private void ChatServiceItemsCallback( IAsyncResult ar )
		{
			try
			{
				Packet p = _sm.Session.EndSend(ar);
				if ((p != null) && (p is DiscoveryItemsResponse))
				{
                    DiscoveryItemsResponse resp = WConvert.ToDiscoItemsResponse(p);

                    if (resp.Items.Count > 0)
                        //warning: this should be smarter as a service with many rooms will generate A LOT of traffic
						foreach ( DiscoveryItem itm in resp.Items )
						{
                            const int RoomItemsTimeout = 30000;

                            DiscoveryInfoRequest req = new DiscoveryInfoRequest(itm.JID, itm.Node);
                            _sm.BeginSend(req.ToPacket, RoomItemsTimeout, new AsyncCallback(RoomInfoCallback), ar.AsyncState);
						}
				}
			}
			catch {}
		}

		private void RoomInfoCallback( IAsyncResult ar )
		{
			try
			{
				Packet p = _sm.Session.EndSend(ar);
				if ((p != null) && (p is DiscoveryInfoResponse))
				{
					DiscoveryInfoResponse resp = WConvert.ToDiscoInfoResponse(p);

                    //determine if this is a chat room based on its features
					string MUCNS = RegisteredJabberNamespaces.MultiUserChat;
					string GCNS = MUCDiscoFeatures.GroupChat;
					if (resp.Features.Contains(MUCNS) || resp.Features.Contains(GCNS))
                        this.BeginInvoke(new ParseChatRoomInfoDelegate(ParseChatRoomInfo), new Object[] {resp, ar.AsyncState});
				}
			}
			catch {}
		}

		private delegate void ParseChatRoomInfoDelegate(DiscoveryInfoResponse resp, ChatServerMenuItem parentMenu);
		private void ParseChatRoomInfo(DiscoveryInfoResponse resp, ChatServerMenuItem parentMenu)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				AddChatServerMenuItem(resp.From, parentMenu);
				this.Cursor = Cursors.Default;
			}
			catch {}
		}

		private void BrowseForChatServers()
		{
            BrowseRequest req = new BrowseRequest(_sm.LocalUser.ServerJID);
            _sm.BeginSend(req.ToPacket, new AsyncCallback(BrowseCompleteCallback));
		}

		private void BrowseCompleteCallback( IAsyncResult ar )
		{
			try
			{
                Packet p = _sm.Session.EndSend(ar);
				if ((p == null) || ! (p is BrowseResponse))
					//this server probably doesn't support browse, try agents
					RequestAgentsForChatServers();
				else
				{
                    BrowseResponse resp = WConvert.ToBrowseResponse(p);
                    if ((resp.RootItem != null) && (resp.RootItem.Items.Count > 0))
                        this.BeginInvoke(new ParseBrowseResponseDelegate(ParseBrowseResponse), new Object[] {resp});
				}
			}
			catch 
			{
				//this server probably doesn't support browse, try agents
				RequestAgentsForChatServers();
			}
		}

		private delegate void ParseBrowseResponseDelegate(BrowseResponse resp);
		private void ParseBrowseResponse(BrowseResponse resp)
		{
            foreach (BrowseItem itm in resp.RootItem.Items)
                foreach (string ns in itm.Namespaces)
					if (ns.Equals(RegisteredJabberNamespaces.MultiUserChat) || ns.Equals(MUCDiscoFeatures.GroupChat))
					{
						//todo: dig into this item to search for rooms
						AddChatServerMenuItem(itm.JabberID);
						break;
					}
		}

		private void RequestAgentsForChatServers()
		{

            AgentsRequest req = new AgentsRequest(_sm.LocalUser.ServerJID);
            _sm.BeginSend(req.ToPacket, new AsyncCallback(AgentsCompleteCallback));
		}

		private void AgentsCompleteCallback( IAsyncResult ar )
		{
			try
			{
                Packet p = _sm.Session.EndSend(ar);
				if ((p != null) && (p is AgentsResponse))
				{
                    AgentsResponse resp = (AgentsResponse)p;
                    this.BeginInvoke(new ParseAgentsResponseDelegate(ParseAgentsResponse), new Object[] {resp});
				}
			}
			catch
			{
                //if we're getting an error on agents then there is no hope to figuring out if the server supports chat rooms
			}

		}

		private delegate void ParseAgentsResponseDelegate(AgentsResponse resp);
		private void ParseAgentsResponse(AgentsResponse resp)
		{
			foreach (Agent itm in resp.Agents)
			{
				if (itm.SupportsGroupChat)
					//todo: dig into this item to search for rooms
                    AddChatServerMenuItem(itm.JabberID);

			}
		}

		private ChatServerMenuItem AddChatServerMenuItem(JabberID jid)
		{
			return AddChatServerMenuItem(jid, null);
		}
		
		private ChatServerMenuItem AddChatServerMenuItem(JabberID jid, ChatServerMenuItem parent)
		{
            ChatServerMenuItem itm = new ChatServerMenuItem(jid, this);
			if (parent == null)
				mnuJoinRoom.MenuItems.Add(itm);
			else
			{
                //make sure we can still output the template for the service
				if (parent.MenuItems.Count == 0)
				{
                    parent.MenuItems.Add(new ChatServerMenuItem(jid.ServerJID, this));
                    parent.MenuItems.Add("-");
				}

                //add this room as a subitem
                parent.MenuItems.Add(itm);
			}

            return itm;
		}
	#endregion

	#region Handle KeyPreview Events
		private void MultiUserChatForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Return:
				{
					if (this.ActiveControl.Handle.Equals(txtOutgoingMessage.Handle))
					{
						string msg = txtOutgoingMessage.Text;

                        bool handled = false;

						if (RoomCommands.ContainsGlobalCommand(msg))
							handled = RoomCommands.ProcessGlobalMessage(msg, this);
						else if (RoomCommands.ContainsRoomCommand(msg))
							handled = RoomCommands.ProcessRoomMessage(msg, this.CurrentTab);
						else
						{
							if (_rooms.Count > 0)
							{
								this.CurrentTab.NewOutgoingMessage(msg);
								handled = true;
							}
						}

                        if (handled)
                            txtOutgoingMessage.Text = string.Empty;

						e.Handled = true;
                        txtOutgoingMessage.Focus();
					}

					break;
				}
				case Keys.F1:
					RoomCommands.ProcessGlobalMessage(RoomCommands.Help, this);
					break;
			}
		}
	#endregion


	#region User Context Menu
		private void mnuSendPrivateMessage_Click(object sender, System.EventArgs e)
		{
            if (_rooms.Count == 0 && lstUsers.SelectedIndex != -1) return;

            RoomOccupant roomItm = (RoomOccupant)lstUsers.SelectedItem;
            roomItm.SendPrivateMessage();
		}

		private void mnuRequestTime_Click(object sender, System.EventArgs e)
		{
			if (_rooms.Count == 0 && lstUsers.SelectedIndex != -1) return;
		
			RoomOccupant roomItm = (RoomOccupant)lstUsers.SelectedItem;
			roomItm.RequestTime();
		}

		private void mnuRequestVersion_Click(object sender, System.EventArgs e)
		{
			if (_rooms.Count == 0 && lstUsers.SelectedIndex != -1) return;
		
			RoomOccupant roomItm = (RoomOccupant)lstUsers.SelectedItem;
			roomItm.RequestVersion();
		}
	#endregion

	}
}
