using System;
using System.Windows.Forms;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class AddContact : KryptonForm
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                DialogResult = DialogResult.None;
                return;
            }

            JabberID JID = null;
            string message = "The User ID you entered is not valid. Please enter a valid User ID";
            try
            {
                JID = new JabberID(tbUserName.Text.ToString(), tbServerName.Text.ToString(), Settings.Default.Resource);
                if (JID.UserName.Length == 0 ||
                    JID.Server.Length == 0)
                {
                    MessageBox.Show(message, "Invalid UserID");
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            catch
            {
                MessageBox.Show(message, "Invalid UserID");
                DialogResult = DialogResult.None;
                return;
            }
            Contact newContact = new Contact(JID, tbGroupName.Text.Trim(), LoginState.Offline);
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                if (contact.Equals(newContact))
                {
                    MessageBox.Show("Contact already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
            }

            SubscribeRequest subscribeRequest = new SubscribeRequest(JID);
            AppController.Instance.SessionManager.Send(subscribeRequest);
            AppController.Instance.SessionManager.BeginSend(
                new RosterAdd(JID, tbUserName.Text.Trim(), tbGroupName.Text.Trim()));
            AppController.Instance.Contacts.Add(newContact);
            AppController.Instance.MainWindow.UpdateContactList();
        }

        private bool ValidateInput()
        {
            if (tbUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a User ID for your Contact");
                return false;
            }

            if (tbServerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Server for your Contact");
                return false;
            }

            if (tbGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Group for your Contact");
                return false;
            }


            return true;
        }
    }
}