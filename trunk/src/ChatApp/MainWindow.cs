using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.Message;
using ComponentFactory.Krypton;
using System.Media;

namespace ChatApp
{
    public partial class MainWindow : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private readonly int GroupImageIndex = 4;

        public MainWindow()
        {
            InitializeComponent();

            AppController.Instance.IncomingMessage += new AppController.IncomingMessageDelegate(OnIncomingMessage);
            AppController.Instance.IncomingPresence += new AppController.IncomingPresenceDelegate(OnIncomingPresence);
        }

        public void UpdateContactList()
        {
            tvContacts.BeginUpdate();

            tvContacts.Nodes.Clear();

            foreach (Contact contact in AppController.Instance.Contacts)
            {
                TreeNode GroupNode = GetGroupNodeFor(contact.GroupName);
                TreeNode newNode = new TreeNode(contact.UserName, (int)contact.UserStatus, (int)contact.UserStatus);
                newNode.Tag = contact.JabberId.JabberIDNoResource;
                GroupNode.Nodes.Add(newNode);
            }
            tvContacts.ExpandAll();

            tvContacts.EndUpdate();

            /*
            Contact contact = null;
            ContactList m_contacts = AppController.Instance.Contacts;
            for (int index = 0; index < m_contacts.Count; ++index)
            {
                contact = m_contacts[index];
                string groupName = contact.GroupName;

                TreeNode groupNode = new TreeNode(groupName);

                bool bAddGroup = true;
                foreach (TreeNode node in tvContacts.Nodes)
                {
                    // If the tree already contain this group, do not add it
                    if (node.Text.Equals(groupName, StringComparison.OrdinalIgnoreCase))
                    {
                        groupNode = node;
                        bAddGroup = false;
                        break;
                    }
                }
                bool bAddContact = true;
                if (showallcontacts == false)
                {
                    if (contact.UserStatus == LoginState.Offline)
                    {
                        bAddContact = false;
                    }
                }
                if (bAddContact)
                {
                    TreeNode node = groupNode.Nodes.Add(contact.UserName);
                    node.Tag = contact.JabberId.JabberIDNoResource;
                }

                if (bAddGroup)
                {
                    groupNode.ImageIndex = 4;
                    groupNode.SelectedImageIndex = 4;
                    tvContacts.Nodes.Add(groupNode);
                }
            }
            if (showallcontacts)
            {
                tvContacts.ExpandAll();
            }
            */
        }

        private TreeNode GetGroupNodeFor(string GroupName)
        {
            if (tvContacts.Nodes.ContainsKey(GroupName))
            {
                return tvContacts.Nodes[GroupName];
            }
            else
            {
                TreeNode GroupNode = new TreeNode(GroupName, GroupImageIndex, GroupImageIndex);
                GroupNode.Name = GroupName;
                tvContacts.Nodes.Add(GroupNode);
                return GroupNode;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (AppController.Instance.CurrentUser.UserName.Length >= 0)
            {
                lblWelcome.Text = AppController.Instance.CurrentUser.UserName;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                this.Visible = false;
                e.Cancel = true;
                AppController.Instance.SetHiddenMode(this);
            }
        }

        private void lblStatus_LinkClicked(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Point scrnPoint = new Point(0, control.Size.Height);
            statusContextMenuStrip.Show(control, scrnPoint);
        }

        private void CbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //CbStatus.Visible = false;
            //lblStatus.Text = CbStatus.SelectedItem.ToString();
            //AvailableRequest presence = new AvailableRequest();
            //presence.Status = lblStatus.Text;
            //if (presence.Status.Equals("Invisible"))
            //{
            //    presence.Status = "Offline";
            //}
            //AppController.Instance.SendCurrentPresence(presence);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
                AppController.Instance.LogOff();
            }
        }

        private void tvContacts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessagingWindow msgWindow = new MessagingWindow();
            msgWindow.Show();
        }

        public void UpdateUserStatusIcon()
        {
            Contact contact = null;
            ContactList m_contacts = AppController.Instance.Contacts;

            foreach (TreeNode node in tvContacts.Nodes)
            {
                contact = m_contacts[node.Text.ToString()];
                if (contact != null)
                    SetStatusIcon(node, contact.UserStatus);
                else
                {
                    foreach (TreeNode userNode in node.Nodes)
                    {
                        contact = m_contacts[userNode.Text.ToString()];
                        if (contact != null)
                        {
                            SetStatusIcon(userNode, contact.UserStatus);
                        }
                    }
                }
            }
        }

        private void SetStatusIcon(TreeNode node, LoginState state)
        {
            switch (state)
            {
                case LoginState.Online:
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    break;
                case LoginState.Away:
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    break;
                case LoginState.Busy:
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    break;
                case LoginState.Offline:
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    break;
                default:
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    break;
            }
        }

        private void OnIncomingPresence(PresencePacket incomingPresencePacket)
        {
            this.Invoke(new Session.PacketReceivedDelegate(IncomingAsycPresenceThreadSafe), new object[] { incomingPresencePacket });

        }

        private void IncomingAsycPresenceThreadSafe(Packet incomingPresencePacket)
        {
            PresencePacket IncomingPresencePacket = incomingPresencePacket as PresencePacket;

            if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.ProbeRequest)
            {
                //A Probe means we should send our presence to the probing entity
                //Maybe we should get some user input here.  Not really sure if theyd want to know, though.
                AppController.Instance.SendCurrentPresence(IncomingPresencePacket.From);
            }
            /*else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.SubscribeRequest)
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
            }*/
            else
                if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.AvailableRequest)
                {
                    AvailableRequest availableReq = WConvert.ToAvailableRequest(IncomingPresencePacket);

                    LoginState state = LoginState.Offline;
                    string userName = availableReq.From.UserName;

                    SoundPlayer player = new SoundPlayer();
                    player.LoadTimeout = 10000;
                    player.SoundLocation = "C:\\WINDOWS\\Media\\notify.wav";
                    player.Play();


                    if (availableReq.Status.Equals("online", StringComparison.OrdinalIgnoreCase))
                    {
                        state = LoginState.Online;
                    }
                    else if (availableReq.Status.Equals("busy", StringComparison.OrdinalIgnoreCase))
                    {
                        state = LoginState.Busy;
                    }

                    else if (availableReq.Status.Equals("Away", StringComparison.OrdinalIgnoreCase))
                    {
                        state = LoginState.Away;
                    }

                    else if (availableReq.Status.Equals("Do not Disturb", StringComparison.OrdinalIgnoreCase))
                    {
                        state = LoginState.Busy;
                    }
                    else if (availableReq.Status.Equals("On Phone", StringComparison.OrdinalIgnoreCase))
                    {
                        state = LoginState.Busy;
                    }
                    else if (availableReq.Status.Equals("Free To Chat", StringComparison.OrdinalIgnoreCase))
                    {
                        state = LoginState.Online;
                    }
                    else
                    {
                        state = LoginState.Away;
                    }


                    Contact contact = AppController.Instance.Contacts[userName];
                    if (contact != null)
                        contact.UserStatus = state;
                    UpdateUserStatusIcon();
                }
                else if (IncomingPresencePacket is Coversant.SoapBox.Core.Presence.UnavailableRequest)
                {

                    UnavailableRequest avail = WConvert.ToUnavailableRequest(IncomingPresencePacket);
                    string userName = avail.From.UserName;
                    Contact contact = AppController.Instance.Contacts[userName];
                    contact.UserStatus = LoginState.Offline;

                    UpdateUserStatusIcon();
                }

        }

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

        private void IncomingAsyncMessage(Packet p)
        {
            MessagePacket IncomingMessage = p as MessagePacket;
            // Iterate through the list of jabber ids and check whether it is already added

            MessagingWindow msgWindow = AppController.Instance.GetMessagingWindow(p.From.JabberIDNoResource);
            msgWindow.AddMessageToHistory(IncomingMessage);
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact addWnd = new AddContact();
            addWnd.Show();
        }

        private void deleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelContact delWnd = new DelContact();
            delWnd.Show();
        }

        private void editGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGroup editWnd = new EditGroup();
            editWnd.Show();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact editWnd = new EditContact();
            editWnd.Show();
        }

        private void deleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteGroup delgWnd = new DeleteGroup();
            delgWnd.Show();
        }


        /// <summary>
        /// Update the tree view acoording to the names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact contact = null;
            TreeNode namelistnode = new TreeNode();
            ContactList m_contacts = AppController.Instance.Contacts;
            //MainWindow msgwnd = new MainWindow(); 
            tvContacts.Nodes.Clear();
            for (int i = 0; i < m_contacts.Count; ++i)
            {

                contact = m_contacts[i];
                namelistnode = tvContacts.Nodes.Add(contact.UserName);
                //SetStatusIcon(namelistnode, contact.UserStatus);
            }
            tvContacts.Show();
            tvContacts.ExpandAll();
            UpdateUserStatusIcon();
        }

        /// <summary>
        /// update tree view by group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortByGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactList m_contacts = AppController.Instance.Contacts;
            Contact contact;
            tvContacts.Nodes.Clear();

            for (int i = 0; i < m_contacts.Count; ++i)
            {
                contact = m_contacts[i];
                string groupName = contact.GroupName;

                TreeNode groupNode = new TreeNode(groupName);

                bool bAddGroup = true;
                foreach (TreeNode node in tvContacts.Nodes)
                {
                    //--------- If the tree already contain this group, do not add it
                    if (node.Text.Equals(groupName, StringComparison.OrdinalIgnoreCase))
                    {
                        groupNode = node;
                        bAddGroup = false;
                        break;
                    }
                }

                groupNode.Nodes.Add(contact.UserName);
                if (bAddGroup)
                {
                    groupNode.ImageIndex = 4;
                    groupNode.SelectedImageIndex = 4;
                    tvContacts.Nodes.Add(groupNode);
                }
            }
            tvContacts.ExpandAll();
            UpdateUserStatusIcon();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainWindow m_mainWindow = AppController.Instance.MainWindow;
            m_mainWindow.Show();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void chatAppToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Show the contacts types on the serach box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string searchtxt = null;
            MainWindow m_mainWindow = AppController.Instance.MainWindow;
            searchtxt = tbSearch.Text.ToString();
            m_mainWindow.Searchcontact(searchtxt);
        }

        private void Searchcontact(string cntact)
        {
            MainWindow m_mainWindow = AppController.Instance.MainWindow;
            Contact contact = null;
            ContactList m_contacts = AppController.Instance.Contacts;
            tvContacts.Nodes.Clear();

            if (cntact == "")
            {
                UpdateContactList();
            }
            else
            {
                for (int i = 0; i < m_contacts.Count; ++i)
                {
                    contact = m_contacts[i];
                    string contactgot = contact.UserName.ToString();
                    if (contactgot.StartsWith(cntact))
                    {
                        tvContacts.Nodes.Add(contact.UserName);
                    }
                }
            }
            tvContacts.ExpandAll();
            UpdateUserStatusIcon();
        }

        /// <summary>
        /// Start A Chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvContacts.Enabled)
                {
                    currentUser = tvContacts.SelectedNode.Text.ToString();
                    string jabberIdWithNoResource = (string)tvContacts.SelectedNode.Tag;
                    AppController.Instance.GetMessagingWindow(jabberIdWithNoResource);
                }
            }
            catch
            {
                MessageBox.Show("Select a contact", "Contact not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
