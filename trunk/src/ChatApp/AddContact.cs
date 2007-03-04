using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 

using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.IQ;
using Coversant.SoapBox.Core.IQ.Auth;
using Coversant.SoapBox.Core.IQ.Register;
using Coversant.SoapBox.Core.IQ.Roster; 
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class AddContact : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        
        public AddContact()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a User ID for your Contact");
                return;
            }
            
            if (tbServerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Server for your Contact");
                return;
            }

            if (tbGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Group for your Contact");
                return;
            }
            
            JabberID JID = null;
            string message = "The User ID you entered is not valid. Please enter a valid User ID";
            try
            {
                JID = new JabberID(tbUserName.Text.ToString(), tbServerName.Text.ToString(), Properties.Settings.Default.Resource);
                if (JID.UserName.Length == 0 ||
                    JID.Server.Length == 0)
                {
                    MessageBox.Show(message, "Invalid UserID");
                    return;
                }
            }
            catch
            {
                MessageBox.Show(message, "Invalid UserID");
                return;
            }

            Contact newContact = new Contact(JID, tbGroupName.Text.Trim(), LoginState.Offline);
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                if (contact.Equals(newContact))
                {
                    MessageBox.Show("Contact already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            SubscribeRequest subscribeRequest = new SubscribeRequest(JID);
            AppController.Instance.SessionManager.Send(subscribeRequest);
            AppController.Instance.SessionManager.BeginSend(new RosterAdd(JID, tbUserName.Text.Trim(), tbGroupName.Text.Trim()));
            AppController.Instance.Contacts.Add(newContact);
            AppController.Instance.MainWindow.UpdateContactList();
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddContact_Load(object sender, EventArgs e)
        {

        }
    }
}