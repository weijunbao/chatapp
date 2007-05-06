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
using Coversant.SoapBox.Core.IQ.vCard;
using System.IO;

namespace ChatApp
{
    public partial class MainWindow : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Brush lvBackgroundBrush;

        public MainWindow()
        {
            InitializeComponent();

            AppController.Instance.IncomingMessage += new AppController.IncomingMessageDelegate(OnIncomingMessage);
            AppController.Instance.IncomingPresence += new AppController.IncomingPresenceDelegate(OnIncomingPresence);

            lvBackgroundBrush = new SolidBrush(Color.FromArgb(214, 219, 231));
            lvContacts.Padding = new Padding(0);
        }

        public void UpdateContactList()
        {
            lvContacts.BeginUpdate();
            lvContacts.Items.Clear();

            foreach (Contact contact in AppController.Instance.Contacts)
            {
                ListViewGroup lvGroup = GetGroupNodeFor(contact.GroupName);
                ListViewItem newItem = new ListViewItem(contact.UserName, (int)contact.UserStatus, lvGroup);
                //newItem.SubItems.Add(new ListViewItem.ListViewSubItem(newItem, contact.UserStatus.ToString()));
                newItem.Tag = contact.JabberId;
                lvContacts.Items.Add(newItem);
            }
            lvContacts.EndUpdate();
        }

        private ListViewGroup GetGroupNodeFor(string GroupName)
        {
            ListViewGroup lvGroup = null;
            if (GroupName.Length == 0)
            {
                GroupName = "No Group";
            }
            if (lvContacts.Groups[GroupName] != null)
            {
                lvGroup = lvContacts.Groups[GroupName];
            }
            else
            {
                ListViewGroup NewGroup = new ListViewGroup(GroupName, GroupName);
                lvContacts.Groups.Add(NewGroup);
                lvGroup = NewGroup;
            }
            return lvGroup;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            AppController.Instance.SendAvailableRequest();
            if (AppController.Instance.CurrentUser.UserName.Length >= 0)
            {
                lblWelcome.Text = AppController.Instance.CurrentUser.UserName;
            }
            UpdateContactList();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork +=new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateContactList();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Contact self = new Contact(AppController.Instance.CurrentUser,
                string.Empty, (LoginState)Enum.Parse(typeof(LoginState), lblStatus.Values.Text));

            AppController.Instance.Contacts.Self = self;
            GetAvatarFor(self);
            if (File.Exists(AppController.Instance.Contacts.Self.AvatarImagePath))
            {
                this.userPictureBox.Image = AppController.Instance.Contacts.Self.AvatarImage;
            }

            foreach (Contact contact in AppController.Instance.Contacts)
            {
                GetAvatarFor(contact);
            }
            
        }

        private void GetAvatarFor(Contact contact)
        {
            vCardResponse response = (vCardResponse)AppController.Instance.SendPacket(new vCardRequest(contact.JabberId), 5000);
            if (response != null)
            {
                contact.FormattedName = response.VCard.FormattedName == null ? null : response.VCard.FormattedName;
                if (response.VCard.Photo != null)
                {
                    Image avatharImage = Image.FromStream(new MemoryStream(response.VCard.Photo.EncodedImage));
                    if (avatharImage != null)
                    {
                        contact.AvatarImage = avatharImage;
                    }
                }
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
            if (null == control)
                return;
            Point scrnPoint = new Point(0, control.Size.Height);
            statusContextMenuStrip.Show(control, scrnPoint);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                AppController.Instance.Contacts.Dispose();
                this.Close();
                AppController.Instance.LogOff();
            }
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
                AppController.Instance.OPlaySound();
                Notify(incomingPresencePacket);
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
                AppController.Instance.chPlaySound();
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
            MessagingWindow msgWindow = AppController.Instance.GetMessagingWindow(packet.From);
            msgWindow.Show();
            if (string.Empty == msgWindow.MessageThreadID)
            {
                msgWindow.MessageThreadID = IncomingMessage.Thread;
            }

            string msg = IncomingMessage.Body;
            msgWindow.Text = string.Format("From {0} to {1}", packet.To.UserName, packet.From.UserName); 
            if (msgWindow.ContainsFocus == false)
            {
                Notify(msg);
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
            JabberID contactID = this.GetSelectedContact();
            EditContactWnd.SelectContact(contactID);
            EditContactWnd.ShowDialog(this);
            EditContactWnd.Dispose();
            EditContactWnd = null;
        }

        private JabberID GetSelectedContact()
        {
            if (lvContacts.SelectedItems.Count == 0)
                return null;
            return lvContacts.SelectedItems[0].Tag as JabberID;
        }

        private void DeleteGroupMenuItem_Click(object sender, EventArgs e)
        {
            DeleteGroup DeleteGroupWnd = new DeleteGroup();
            DeleteGroupWnd.ShowDialog(this);
            DeleteGroupWnd.Dispose();
            DeleteGroupWnd = null;
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
            SearchContact(tbSearch.Text);
        }

        private void SearchContact(string s_contact)
        {
            lvContacts.Items.Clear();
            if (s_contact == "")
            {
                UpdateContactList();
            }
            else
            {
                foreach (Contact contact in AppController.Instance.Contacts)
                {
                    if (contact.UserName.StartsWith(s_contact))
                    {
                        ListViewItem newItem = lvContacts.Items.Add(contact.UserName.ToString());
                        newItem.Tag = contact.JabberId;
                    }
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
            JabberID jabberID = GetSelectedContact();
            if (jabberID == null)
            {
                MessageBox.Show("Select a contact", "Contact not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppController.Instance.GetMessagingWindow(jabberID);
            MessagingWindow.ActiveForm.Text = string.Format("From {0} to {1}", AppController.Instance.CurrentUser.UserName, jabberID.UserName); 

        }

        private void StatusMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            LoginState state = (LoginState)menuItem.Tag;
            AppController.Instance.SendCurrentPresence(state);

            lblStatus.Values.Image = StatusImageList.Images[(int)state];
            lblStatus.Values.Text = state.ToString();
        }


        private void lvContacts_Resize(object sender, EventArgs e)
        {
            int newWidth = this.lvContacts.ClientSize.Width;
            if (newWidth < 36)
                newWidth = 36;
            this.lvContacts.TileSize = new Size(newWidth, 36);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutWind = new About();
            aboutWind.ShowDialog(this);
            aboutWind.Dispose();
            aboutWind = null;
        }

        private void preferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preference preWind = new preference();
            preWind.ShowDialog(this);
            preWind.Dispose();
            preWind = null;
        }

        private void Notify(Packet incomingPresencePacket)
        {
            string userName = incomingPresencePacket.From.UserName;

            // If the presence packet is from a user other than the current user
            //  and if Show Notification preference is set, then show notification

            if ( (userName != AppController.Instance.CurrentUser.UserName)
                && (ChatApp.Properties.Settings.Default.FriendOnlineShowNotification == true) )
            {
                string message = null;
                string userStatus = "offline";

                if (incomingPresencePacket is AvailableRequest)
                {
                    AvailableRequest availableReq = WConvert.ToAvailableRequest(incomingPresencePacket);
                    userStatus = availableReq.Status;
                }

                message = string.Format("{0} is now {1}", userName, userStatus.ToString());
                AppController.Instance.HiddenWindow.ShowBalloonToolTip(message);
            }
            
        }

        private void Notify(string msg)
        {
            if (ChatApp.Properties.Settings.Default.IncomingMessageShowNotification == true)
            {
                AppController.Instance.HiddenWindow.ShowBalloonToolTip(msg);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppController.Instance.ExitApplication();
        }

        private void lvContacts_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Rectangle ImageRect = e.Bounds;
            ImageRect.Inflate(-2, -2);
            ImageRect.Width = 32;
            
            Rectangle TextRect = e.Bounds;
            TextRect.X = ImageRect.Right + 2;
            TextRect.Width = e.Bounds.Width - TextRect.X;

            Rectangle IconRect = TextRect;
            IconRect.Inflate(-1, 0);
            IconRect.Y = ImageRect.Bottom - 16;
            IconRect.Width = 16;
            IconRect.Height = 16;

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(lvBackgroundBrush, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                // Draw the background for an unselected item.
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            // Draw the item text for views other than the Details view.
            if (lvContacts.View != View.Details)
            {
                JabberID jabberID = (JabberID)e.Item.Tag;
                Contact contact = AppController.Instance.Contacts[jabberID.UserName];

                e.Graphics.DrawImage(contact.AvatarImage, ImageRect);
                
                //e.DrawText();
                TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, TextRect, e.Item.ForeColor, TextFormatFlags.GlyphOverhangPadding);
                e.Graphics.DrawImage(StatusImageList.Images[(int)contact.UserStatus], IconRect);
             }
        }

        private void lvContacts_DoubleClick(object sender, EventArgs e)
        {
            ListView currentListView = sender as ListView;
            if (currentListView == null)
                return;
            JabberID jabberID = GetSelectedContact();
            if (jabberID != null)
            {
                MessagingWindow msgWindow = AppController.Instance.GetMessagingWindow(jabberID);
                msgWindow.MessageThreadID = System.Guid.NewGuid().ToString();
                msgWindow.Show();
                msgWindow.Text = string.Format("From {0} to {1}", AppController.Instance.CurrentUser.UserName, jabberID.UserName);
            }
        }

    }
}
