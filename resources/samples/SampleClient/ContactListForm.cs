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
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.IQ;
using Coversant.SoapBox.Core.IQ.Auth;
using Coversant.SoapBox.Core.IQ.Register;
using Coversant.SoapBox.Core.IQ.Roster;

using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.Presence;


namespace Coversant.SoapBox.SampleClient
{
    /// <summary>
    /// Summary description for ContactListForm.
    /// </summary>
    public class ContactListForm : System.Windows.Forms.Form
    {

        //Holds a reference to this sesion's session manager
        //The SessionManager provides us with events when
        //packets of interest are received.
        private SessionManager _SessionManager;

        //For Contacts that arrive as a RosterItem without a Group
        //value, this is the Group name that is used for display
        public const string DEFAULT_GROUP = "Contacts";
        internal System.Windows.Forms.Button AddButton;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox PresenceTypeComboBox;
        internal System.Windows.Forms.TextBox CurrentPresenceTextBox;
        internal System.Windows.Forms.Button EditButton;
        internal System.Windows.Forms.Button RemoveButton;
        internal System.Windows.Forms.Button SendMessageButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ImageList TreeImages;
        private System.ComponentModel.IContainer components;
        internal System.Windows.Forms.PictureBox pbNoSSL;
        internal System.Windows.Forms.PictureBox pbSSL;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvRoster;
        internal System.Windows.Forms.ContextMenu ContextMenu1;
        internal System.Windows.Forms.MenuItem mnuShowDebug;
        internal System.Windows.Forms.Button ShowChatRoomsButton;
        private MenuItem mnuTraceShow;
        internal System.Windows.Forms.Button LogoutButton;

        //Delegate used to do any simple GUI operation that needs to be on the main thread
        private delegate void DoGUIWork();

        private ContactListForm()
        {
            InitializeComponent();
        }

        public ContactListForm(SessionManager mySession)
            : this()
        {
            _SessionManager = mySession;
            _SessionManager.IncomingMessage += new SessionManager.IncomingMessageDelegate(OnIncomingMessage);
            _SessionManager.IncomingPresence += new SessionManager.IncomingPresenceDelegate(OnIncomingPresence);
            _SessionManager.IncomingRosterChange += new SessionManager.IncomingRosterChangeDelegate(OnIncomingRosterChange);

            Rectangle screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(Convert.ToInt32((screen.Width - this.Width) / 2),
                Convert.ToInt32((screen.Height - this.Height) / 2));

            this.Text = string.Format("{0}  -  {1}", this.Text, _SessionManager.LocalUser.ToString());
        }

        public void Initialize()
        {
            // By kicking off the roster request here, our callback will be called when
            // the response comes in. It's important to not keep the user waiting during that
            // time period, so be sure to do this async. 

            _SessionManager.BeginSend(new RosterRequest(), IncomingRosterCallback);
            _SessionManager.Send(new AvailableRequest());
            PresenceTypeComboBox.SelectedIndex = 4;
        }

        private void IncomingRosterCallback(IAsyncResult ar)
        {
            RosterResponse roster = _SessionManager.EndSend(ar) as RosterResponse;
            OnIncomingRoster(roster);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactListForm));
            this.AddButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.PresenceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CurrentPresenceTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.pbNoSSL = new System.Windows.Forms.PictureBox();
            this.pbSSL = new System.Windows.Forms.PictureBox();
            this.lvRoster = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mnuShowDebug = new System.Windows.Forms.MenuItem();
            this.ShowChatRoomsButton = new System.Windows.Forms.Button();
            this.mnuTraceShow = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoSSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSSL)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddButton.Location = new System.Drawing.Point(7, 331);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(60, 20);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(10, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 18);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Presence";
            // 
            // PresenceTypeComboBox
            // 
            this.PresenceTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PresenceTypeComboBox.Items.AddRange(new object[] {
            "Do Not Disturb",
            "Away",
            "Chat",
            "Extended Away",
            "Normal"});
            this.PresenceTypeComboBox.Location = new System.Drawing.Point(73, 7);
            this.PresenceTypeComboBox.Name = "PresenceTypeComboBox";
            this.PresenceTypeComboBox.Size = new System.Drawing.Size(335, 21);
            this.PresenceTypeComboBox.TabIndex = 0;
            this.PresenceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.PresenceTypeComboBox_SelectedIndexChanged);
            // 
            // CurrentPresenceTextBox
            // 
            this.CurrentPresenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentPresenceTextBox.Location = new System.Drawing.Point(73, 31);
            this.CurrentPresenceTextBox.Name = "CurrentPresenceTextBox";
            this.CurrentPresenceTextBox.Size = new System.Drawing.Size(335, 20);
            this.CurrentPresenceTextBox.TabIndex = 1;
            this.CurrentPresenceTextBox.Text = "Available";
            this.CurrentPresenceTextBox.LostFocus += new System.EventHandler(this.CurrentPresenceTextBox_Leave);
            this.CurrentPresenceTextBox.TextChanged += new System.EventHandler(this.CurrentPresenceTextBox_TextChanged);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(80, 331);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(60, 20);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(344, 326);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(60, 20);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendMessageButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SendMessageButton.Location = new System.Drawing.Point(304, 365);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(100, 21);
            this.SendMessageButton.TabIndex = 7;
            this.SendMessageButton.Text = "Send Message";
            this.SendMessageButton.UseVisualStyleBackColor = false;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(10, 35);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 17);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Status";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoutButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LogoutButton.Location = new System.Drawing.Point(7, 365);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(100, 21);
            this.LogoutButton.TabIndex = 8;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "");
            this.TreeImages.Images.SetKeyName(1, "");
            this.TreeImages.Images.SetKeyName(2, "");
            this.TreeImages.Images.SetKeyName(3, "");
            this.TreeImages.Images.SetKeyName(4, "");
            // 
            // pbNoSSL
            // 
            this.pbNoSSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbNoSSL.Image = ((System.Drawing.Image)(resources.GetObject("pbNoSSL.Image")));
            this.pbNoSSL.Location = new System.Drawing.Point(201, 330);
            this.pbNoSSL.Name = "pbNoSSL";
            this.pbNoSSL.Size = new System.Drawing.Size(24, 24);
            this.pbNoSSL.TabIndex = 13;
            this.pbNoSSL.TabStop = false;
            this.pbNoSSL.Visible = false;
            // 
            // pbSSL
            // 
            this.pbSSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSSL.Image = ((System.Drawing.Image)(resources.GetObject("pbSSL.Image")));
            this.pbSSL.Location = new System.Drawing.Point(201, 330);
            this.pbSSL.Name = "pbSSL";
            this.pbSSL.Size = new System.Drawing.Size(24, 24);
            this.pbSSL.TabIndex = 14;
            this.pbSSL.TabStop = false;
            this.pbSSL.Visible = false;
            this.pbSSL.Click += new System.EventHandler(this.pbSSL_Click);
            // 
            // lvRoster
            // 
            this.lvRoster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRoster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvRoster.FullRowSelect = true;
            this.lvRoster.Location = new System.Drawing.Point(8, 56);
            this.lvRoster.Name = "lvRoster";
            this.lvRoster.Size = new System.Drawing.Size(400, 264);
            this.lvRoster.TabIndex = 15;
            this.lvRoster.UseCompatibleStateImageBehavior = false;
            this.lvRoster.View = System.Windows.Forms.View.Details;
            this.lvRoster.SelectedIndexChanged += new System.EventHandler(this.lvRoster_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Presence";
            this.columnHeader2.Width = 116;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Detail";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 71;
            // 
            // ContextMenu1
            // 
            this.ContextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuShowDebug,
            this.mnuTraceShow});
            // 
            // mnuShowDebug
            // 
            this.mnuShowDebug.Index = 0;
            this.mnuShowDebug.Text = "Show Debug Window";
            this.mnuShowDebug.Click += new System.EventHandler(this.mnuShowDebug_Click);
            // 
            // ShowChatRoomsButton
            // 
            this.ShowChatRoomsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowChatRoomsButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ShowChatRoomsButton.Location = new System.Drawing.Point(156, 365);
            this.ShowChatRoomsButton.Name = "ShowChatRoomsButton";
            this.ShowChatRoomsButton.Size = new System.Drawing.Size(100, 21);
            this.ShowChatRoomsButton.TabIndex = 16;
            this.ShowChatRoomsButton.Text = "Chat Rooms";
            this.ShowChatRoomsButton.UseVisualStyleBackColor = false;
            this.ShowChatRoomsButton.Click += new System.EventHandler(this.ShowChatRoomsButton_Click);
            // 
            // mnuTraceShow
            // 
            this.mnuTraceShow.Index = 1;
            this.mnuTraceShow.Text = "Show Trace Window";
            this.mnuTraceShow.Click += new System.EventHandler(this.mnuTraceShow_Click);
            // 
            // ContactListForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(416, 398);
            this.ContextMenu = this.ContextMenu1;
            this.Controls.Add(this.ShowChatRoomsButton);
            this.Controls.Add(this.lvRoster);
            this.Controls.Add(this.pbSSL);
            this.Controls.Add(this.pbNoSSL);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.PresenceTypeComboBox);
            this.Controls.Add(this.CurrentPresenceTextBox);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContactListForm";
            this.Text = "SoapBox Sample";
            this.Closed += new System.EventHandler(this.ContactListForm_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.pbNoSSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSSL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        /// <summary>
        /// Event received from the SessionManager when a message packet is received.
        /// This is either a MessagePacket or a MessageErrorPacket.
        /// The packet is processed and a new message window is created if applicable.
        /// If a message window already exists it will have received the event as well
        /// and we can ignore the packet.
        /// </summary>
        /// <param name="IncomingMessagePacket">The Message packet that was just received.</param>
        private void OnIncomingMessage(AbstractMessagePacket IncomingMessagePacket)
        {
            //Determine the type of packet.
            //If MessageErrorPacket
            //	 Show the MessageErrorPacket in a MessageBox.
            //If MessagePacket
            //   Grab the message window for this user.
            //Determine the type of packet.
            if (IncomingMessagePacket is MessageErrorPacket)
            {
                MessageErrorPacket msgError = (MessageErrorPacket)IncomingMessagePacket;
                MessageBox.Show(string.Format("The following message error packet was received:\n\nCode: {0}\nText: {1}.", msgError.ErrorCode, msgError.ErrorText), "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (IncomingMessagePacket is MessagePacket)
            {
                MessagePacket msgPacket = (MessagePacket)IncomingMessagePacket;
                this.Invoke(new Session.PacketReceivedDelegate(IncomingAsyncMessage), new object[] { msgPacket });
            }
            else
            {
                // It's some other type, just ignore it.
            }
        }

        /// <summary>
        /// Lets the session manager handle maintaining the list of
        /// message windows.  This is invoked on the GUI thread
        /// so it's OK to delegate to the sessionmanager.
        /// </summary>
        /// <param name="FromJID"></param>
        /// <param name="InitialPacket"></param>
        private void IncomingAsyncMessage(Packet p)
        {
            MessagePacket InitialPacket = p as MessagePacket;
            _SessionManager.MessageWindows.Show(InitialPacket.From, InitialPacket);
        }
        
        private void IncomingAsycPresenceThreadSafe(Packet p)
        {
            PresencePacket IncomingPresencePacket = p as PresencePacket;
            if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.ProbeRequest)
            {

                //A Probe means we should send ouur presence to the probing entity
                //Maybe we should get some user input here.  Not really sure if theyd want to know, though.
                _SessionManager.SendCurrentPresence(IncomingPresencePacket.From);
            }
            else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.SubscribeRequest)
            {
                string displayString = String.Format("Allow User '{0}; to subscribe to your presence?", IncomingPresencePacket.From.JabberIDNoResource);
                if (MessageBox.Show(displayString, "Subscription Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SubscribedResponse resp = new SubscribedResponse(IncomingPresencePacket.From);
                    _SessionManager.Send(resp);

                    SubscribeRequest subscribe = new SubscribeRequest(new JabberID(IncomingPresencePacket.From.JabberIDNoResource));
                    _SessionManager.Send(subscribe);
                }
                else
                {
                    UnsubscribedResponse resp = new UnsubscribedResponse();
                    resp.To = IncomingPresencePacket.From;
                    _SessionManager.Send(resp);
                }
            }
            else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.SubscribedResponse)
            {
                //Let the user know when someone accepts our subscription request
                string displayString = String.Format("User '{0}' has accepted your presence subscription request.", IncomingPresencePacket.From.JabberIDNoResource);
                MessageBox.Show(displayString, "Subscription Accept", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.UnsubscribedResponse)
            {
                //Let the user know when someone revoked our presence subscription

                string displayString = String.Format("User '{0}' rejected your reqeust.", IncomingPresencePacket.From.JabberIDNoResource);
                MessageBox.Show(displayString, "Subscription Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.ErrorResponse)
            {
                //Let the user know of any presence errors that are received
                //Dim PresenceError As SoapBox.Core.Presence.ErrorResponse = CType(IncomingPresencePacket, SoapBox.Core.Presence.ErrorResponse)
                //MsgBox("The following presence error was received:" & vbCrLf & vbCrLf & "Code: " & PresenceError.ErrorCode & vbCrLf & "Text: " & PresenceError.ErrorText, MsgBoxStyle.Exclamation, "Presence Error")
            }
            else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.AvailableRequest)
            {
                AvailableRequest avail = WConvert.ToAvailableRequest(IncomingPresencePacket);
                ListViewRosterItem lvri = this.GetListViewRosterItem(avail.From);
                if (lvri != null)
                    lvri.Presence = avail;
            }
            else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.UnavailableRequest)
            {
                UnavailableRequest avail = WConvert.ToUnavailableRequest(IncomingPresencePacket);
                ListViewRosterItem lvri = this.GetListViewRosterItem(avail.From);
                if (lvri != null)
                    lvri.Presence = avail;
            }
        }

        //Event received from the SessionManager when a presence packet is received.
        //This could be a wide range of presence packet types.
        //Depending on the type a different action is performed.
        //The style of an item on the ContactList could be modified.
        //The user could be soliciting to subscribe to presence and a decision needs to be made by the user.
        //We may need to send off the current presence of the logged in user to a specific user.
        private void OnIncomingPresence(PresencePacket incomingPresencePacket) //Handles _SessionManager.IncomingPresence
        {
            //work performed in here should be done on the main GUI thread
            //since it will be updating the treeview            
            this.Invoke(new Session.PacketReceivedDelegate(IncomingAsycPresenceThreadSafe), new object[] { incomingPresencePacket });
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
            this.Invoke(new Session.PacketReceivedDelegate(IncomingRosterThreadSafe), new object[] { incomingRosterPacket });
        }

        private void OnIncomingRosterChange(RosterChange incomingRosterChange) //Handles _SessionManager.IncomingRoster
        {
            //work performed in here should be done on the main GUI thread
            //since it will be updating the treeview
            this.BeginInvoke(new Session.PacketReceivedDelegate(IncomingRosterChangeThreadSafe), new object[] { incomingRosterChange });
            
        }


        //Delegate used by OnIncomingRoster to marshall to the main thread
        //to do the Roster Update

        //Updates the TreeView based on the Groups of RosterItems
        private void IncomingRosterChangeThreadSafe(Packet p)
        {
            RosterChange IncomingRosterDelta = p as RosterChange;
            lvRoster.BeginUpdate();
            try
            {
                foreach (RosterItem ri in IncomingRosterDelta.Items)
                {
                    switch (ri.Subscription.ToLower())
                    {
                        case "remove":
                            {
                                ListViewRosterItem lvri = GetListViewRosterItem(ri.JID);
                                if (!object.Equals(lvri, null))
                                {
                                    lvRoster.Items.Remove(lvri);
                                }
                                break;
                            }
                        case "to":
                            {
                                ListViewRosterItem lvri = GetListViewRosterItem(ri.JID);
                                if (!object.Equals(lvri, null))
                                {
                                    lvri.RosterItem = ri;
                                }
                                else
                                {
                                    lvri = new ListViewRosterItem(ri);
                                    lvRoster.Items.Add(lvri);
                                }
                                break;
                            }
                        case "from":
                            {
                                ListViewRosterItem lvri = GetListViewRosterItem(ri.JID);
                                if (!object.Equals(lvri, null))
                                {
                                    lvri.RosterItem = ri;
                                }
                                else
                                {
                                    lvri = new ListViewRosterItem(ri);
                                    lvRoster.Items.Add(lvri);
                                }
                                break;
                            }
                        case "both":
                            {
                                ListViewRosterItem lvri = GetListViewRosterItem(ri.JID);
                                if (!object.Equals(lvri, null))
                                {
                                    lvri.RosterItem = ri;
                                }
                                else
                                {
                                    lvri = new ListViewRosterItem(ri);
                                    lvRoster.Items.Add(lvri);
                                }
                                break;
                            }
                        case "none":
                            {
                                ListViewRosterItem lvri = GetListViewRosterItem(ri.JID);
                                if (!object.Equals(lvri, null))
                                {
                                    lvri.RosterItem = ri;
                                }
                                else
                                {
                                    lvri = new ListViewRosterItem(ri);
                                    lvRoster.Items.Add(lvri);
                                }
                                break;
                            }
                    }
                }
            }
            finally
            {
                lvRoster.EndUpdate();
            }
        }

        //Updates the TreeView based on the Groups of RosterItems
        private void IncomingRosterThreadSafe(Packet p)
        {
            RosterResponse IncomingRosterPacket = p as RosterResponse;
            lvRoster.BeginUpdate();
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                lvRoster.Items.Clear();

                foreach (RosterItem ri in IncomingRosterPacket.Items)
                {
                    lvRoster.Items.Add(new ListViewRosterItem(ri));
                }
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                lvRoster.EndUpdate();
            }
        }

        private ListViewRosterItem GetListViewRosterItem(JabberID jid)
        {
            foreach (ListViewRosterItem lvri in lvRoster.Items)
            {
                if (lvri.RosterItem.JID.Equals(jid, JabberID.JabberIDCompareEnum.JabberIDCompareNoResource))
                {
                    return lvri;
                }
            }
            return null;
        }

        private void UpdateSessionPresence()
        {
            AvailableRequest ar = new AvailableRequest();
            ar.Status = CurrentPresenceTextBox.Text;

            switch (PresenceTypeComboBox.Text.ToLower())
            {
                case "do not disturb":
                    ar.Show = AvailableRequest.ShowValuesEnum.DoNotDisturb;
                    break;
                case "away":
                    ar.Show = AvailableRequest.ShowValuesEnum.Away;
                    break;
                case "chat":
                    ar.Show = AvailableRequest.ShowValuesEnum.Chat;
                    break;
                case "extended away":
                    ar.Show = AvailableRequest.ShowValuesEnum.ExtendedAway;
                    break;
                case "normal":
                    ar.Show = AvailableRequest.ShowValuesEnum.Normal;
                    break;
                default:
                    ar.Show = AvailableRequest.ShowValuesEnum.Normal;
                    break;
            }

            _SessionManager.CurrentPresence = ar;
        }

        //Update the current presence with the Status in the text box
        private void CurrentPresenceTextBox_TextChanged(object sender, System.EventArgs e) //Handles CurrentPresenceTextBox.TextChanged
        {
            if (_SessionManager != null)
                UpdateSessionPresence();
        }

        //Update the current presence with the value from the dropdown.
        //Send the updated state to the server.
        private void PresenceTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e) //Handles PresenceTypeComboBox.SelectedIndexChanged
        {
            if (_SessionManager != null)
            {
                UpdateSessionPresence();
                _SessionManager.SendCurrentPresence();
            }
        }

        //Send the server our current presence after we're done editing the textbox
        private void CurrentPresenceTextBox_Leave(object sender, System.EventArgs e) //Handles CurrentPresenceTextBox.LostFocus
        {
            _SessionManager.SendCurrentPresence();
        }

        //This window has been closed
        //Shutdown the SessionManager
        private void ContactListForm_Closed(object sender, System.EventArgs e) //Handles MyBase.Closed
        {
            _SessionManager.Shutdown();
        }

        //The user wants to send a message to a user on their roster.
        //Prompt for the information.
        //Submit the new roster item and presence subscription request.
        //Refresh the local copy of the Roster from the server.
        //Send the server the current presence,
        private void SendMessageButton_Click(object sender, System.EventArgs e) //Handles SendMessageButton.Click
        {
            try
            {
                SendMessageToSelectedNode();
            }
            catch (Exception ex)
            {
                string display = String.Format("Unable to Send Message: {0}", ex.Message);
                MessageBox.Show(display, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendMessageToSelectedNode()
        {
            // In case we got here by mistake, just exit out gracefully.
            if (lvRoster.SelectedItems.Count == 0)
                return;

            ListViewRosterItem lvri = (ListViewRosterItem)lvRoster.SelectedItems[0];
            _SessionManager.MessageWindows.Show(lvri.RosterItem.JID);
        }

        //The user wants to add a new user to their Roster
        //Prompt for the information.
        //Submit the new roster item and presence subscription request.
        //Refresh the local copy of the Roster from the server.
        //Send the server the current presence,
        private void AddButton_Click(object sender, System.EventArgs e) //Handles AddButton.Click
        {
            ContactListUserAddForm addForm = new ContactListUserAddForm();
            if (addForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            JabberID jid = new JabberID(addForm.JabberIDTextBox.Text.Trim());
            SubscribeRequest p = new SubscribeRequest(jid);
            _SessionManager.Send(p);
        }

        //The user wants to edit an item on their Roster
        //Prompt for the information.
        //Remove/Add the roster item to update its information.
        //Refresh the local copy of the Roster from the server.
        //Send the server the current presence,
        private void EditButton_Click(object sender, System.EventArgs e) //Handles EditButton.Click
        {
            // Get the selected item off the list
            // Bring up an input box to edit the friendly name
            // Update the roster on the server with the new info
            if (!(lvRoster.SelectedItems[0] is ListViewRosterItem))
            {
                return;
            }

            ListViewRosterItem lvri = (ListViewRosterItem)lvRoster.SelectedItems[0];

            // show the add/edit form and populate all the fields with the existing roster item data
            ContactEditForm editForm = new ContactEditForm();
            editForm.FriendlyNameTextBox.Text = lvri.RosterItem.Name;
            editForm.JabberIDTextBox.Text = lvri.RosterItem.JID.ToString();
            editForm.GroupNameTextBox.Text = lvri.RosterItem.Group;

            //'if the user clicked "OK" we should update the roster item and then
            //'submit it to the server for editing
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RosterItem ri = WConvert.ToRosterItem(lvri.RosterItem.Clone());
                ri.Group = editForm.GroupNameTextBox.Text;
                ri.Name = editForm.FriendlyNameTextBox.Text;

                //'*** Re-Adding an Existing contact is the how Edit's are accomplished. 
                _SessionManager.BeginSend(new RosterAdd(ri));
            }
        }

        //The user wants to remove a user from their Roster
        private void RemoveButton_Click(object sender, System.EventArgs e) //Handles RemoveButton.Click
        {
            try
            {
                ListViewItem lvi = lvRoster.SelectedItems[0];
                if (!(lvi is ListViewRosterItem))
                {
                    MessageBox.Show("The Selected Item is invalid", "Sample client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ListViewRosterItem lvri = (ListViewRosterItem)lvi;
                RosterItem ri = lvri.RosterItem;

                string displayString = String.Format("Remove {0} from your roster", ri.Name);
                if (MessageBox.Show(displayString, "Remove Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    RosterRemove remove = new RosterRemove(ri);
                    Packet p = (Packet)remove;
                    _SessionManager.BeginSend(p);
                }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Unable to Remove Roster Item: ", ex.Message));
            }
        }

        private void LogoutButton_Click(object sender, System.EventArgs e) //Handles LogoutButton.Click
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to logout?", "Logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                _SessionManager.Dispose();
                LoginRegisterForm login = new LoginRegisterForm();
                this.Hide();
                login.Show();
            }
        }

        private void mnuShowDebug_Click(object sender, System.EventArgs e)
        {
            DebugOutput x = new DebugOutput();
            x.Show();
        }

        private void lvRoster_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvRoster.SelectedItems.Count > 0)
            {
                if (lvRoster.SelectedItems[0] is ListViewRosterItem)
                {
                    RemoveButton.Enabled = true;
                    SendMessageButton.Enabled = true;
                    EditButton.Enabled = true;
                }
                else
                {
                    RemoveButton.Enabled = false;
                    SendMessageButton.Enabled = false;
                    EditButton.Enabled = false;
                }
            }
            else
            {
                RemoveButton.Enabled = false;
                SendMessageButton.Enabled = false;
                EditButton.Enabled = false;
            }
        }

        private void ShowChatRoomsButton_Click(object sender, System.EventArgs e)
        {
            _SessionManager.LoadChatRooms();
        }

        private void mnuTraceShow_Click(object sender, EventArgs e)
        {
            Coversant.Trace.WTraceDisplay w = new Coversant.Trace.WTraceDisplay();
            w.Show();
        }

        private void pbSSL_Click(object sender, EventArgs e)
        {
            // If the user clicked on the lock, we want to display the SSL Certificate. 
            if (_SessionManager.Session.IsConnected)
            {
                if (_SessionManager.Session.ClientConnection.NetworkStream.SecureProtocol != Coversant.Net.Security.SupportedSecureProtocol.None)
                {
                    System.Net.Security.SslStream s = _SessionManager.Session.ClientConnection.NetworkStream.InnerStream as System.Net.Security.SslStream;
                    if (s != null)
                    {
                        X509Certificate2 c = new X509Certificate2(s.RemoteCertificate);
                        if (c != null)
                            X509Certificate2UI.DisplayCertificate(c);
                    }
                }
            }
        }
    }
}
