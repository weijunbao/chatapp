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
                newNode.ContextMenuStrip = this.contactsContextMenuStrip;
                GroupNode.Nodes.Add(newNode);
            }
            tvContacts.ExpandAll();
            tvContacts.EndUpdate();
        }

        private TreeNode GetGroupNodeFor(string GroupName)
        {
            TreeNode treeNode = null;
            if (GroupName.Length == 0)
            {
                GroupName = "No Group";
            }
            if (tvContacts.Nodes.ContainsKey(GroupName))
            {
                treeNode = tvContacts.Nodes[GroupName];
            }
            else
            {
                TreeNode GroupNode = new TreeNode(GroupName, GroupImageIndex, GroupImageIndex);
                GroupNode.Name = GroupName;
                tvContacts.Nodes.Add(GroupNode);
                treeNode = GroupNode;
            }
            treeNode.ContextMenuStrip = this.contactsContextMenuStrip;
            return treeNode;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            AppController.Instance.SendAvailableRequest();
            if (AppController.Instance.CurrentUser.UserName.Length >= 0)
            {
                lblWelcome.Text = AppController.Instance.CurrentUser.UserName;
            }
            UpdateContactList();
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
            if (null == control)
                return;
            Point scrnPoint = new Point(0, control.Size.Height);
            statusContextMenuStrip.Show(control, scrnPoint);
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
            MessagingWindow msgWindow = AppController.Instance.GetMessagingWindow((string)e.Node.Tag);
            msgWindow.MessageThreadID = System.Guid.NewGuid().ToString();
            msgWindow.Show();
        }

        private void OnIncomingPresence(PresencePacket incomingPresencePacket)
        {
            this.Invoke(new Session.PacketReceivedDelegate(IncomingAsycPresenceThreadSafe), new object[] { incomingPresencePacket });
        }

        private void IncomingAsycPresenceThreadSafe(Packet incomingPresencePacket)
        {
            PresencePacket IncomingPresencePacket = incomingPresencePacket as PresencePacket;

            if (IncomingPresencePacket is AvailableRequest || IncomingPresencePacket is UnavailableRequest) 
            {
                AppController.Instance.PlaySound();
                UpdateContactList();
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

        private void IncomingAsyncMessage(Packet packet)
        {
            MessagePacket IncomingMessage = packet as MessagePacket;

            // Iterate through the list of jabber ids and check whether it is already added
            MessagingWindow msgWindow = AppController.Instance.GetMessagingWindow(packet.From.JabberIDNoResource);
            if (string.Empty == msgWindow.MessageThreadID)
            {
                msgWindow.MessageThreadID = IncomingMessage.Thread;
            }
            msgWindow.AddMessageToHistory(IncomingMessage);
        }

        private void AddContactMenuItem_Click(object sender, EventArgs e)
        {
            AddContact AddContactWnd = new AddContact();
            AddContactWnd.ShowDialog(this);
            AddContactWnd.Dispose();
            AddContactWnd = null;
        }

        private void DeleteContactMenuItem_Click(object sender, EventArgs e)
        {
            DelContact DelContactWnd = new DelContact();
            DelContactWnd.ShowDialog(this);
            DelContactWnd.Dispose();
            DelContactWnd = null;
        }

        private void EditGroupMenuItem_Click(object sender, EventArgs e)
        {
            EditGroup EditGroupWnd = new EditGroup();
            EditGroupWnd.ShowDialog(this);
            EditGroupWnd.Dispose();
            EditGroupWnd = null;
        }

        private void EditContactMenuItem_Click(object sender, EventArgs e)
        {
            EditContact EditContactWnd = new EditContact();
            EditContactWnd.ShowDialog(this);
            EditContactWnd.Dispose();
            EditContactWnd = null;
        }

        private void DeleteGroupMenuItem_Click(object sender, EventArgs e)
        {
            DeleteGroup DeleteGroupWnd = new DeleteGroup();
            DeleteGroupWnd.ShowDialog(this);
            DeleteGroupWnd.Dispose();
            DeleteGroupWnd = null;
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
            UpdateContactList();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Show the contacts types on the serach box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Searchcontact(tbSearch.Text);
        }

        private void Searchcontact(string contact)
        {
            foreach (TreeNode node in tvContacts.Nodes)
            {
                if (node.Name.StartsWith(contact))
                {
                    tvContacts.SelectedNode = node;
                }
            }
        }

        /// <summary>
        /// Start A Chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartChatMenuItem_Click(object sender, EventArgs e)
        {
            if (null == tvContacts.SelectedNode)
            {
                MessageBox.Show("Select a contact", "Contact not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string jabberIdWithNoResource = (string)tvContacts.SelectedNode.Tag;
            AppController.Instance.GetMessagingWindow(jabberIdWithNoResource);
        }

        private void StatusMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            LoginState state = (LoginState)menuItem.Tag;
            AppController.Instance.SendCurrentPresence(state);

            lblStatus.Values.Image = StatusImageList.Images[(int)state];
            lblStatus.Values.Text = state.ToString();
        }

        private void ExitStripMenuItem_Click(object sender, EventArgs e)
        {
            AppController.Instance.ExitApplication();
        }
    }
}
