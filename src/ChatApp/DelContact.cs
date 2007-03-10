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

using System.Xml;


namespace ChatApp
{
    public partial class DelContact : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public DelContact()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
         {
            this.Hide();
            bool foundcontact = false;

            if (ValidateInput() == false)
            {
                DialogResult = DialogResult.None;
                return;
            }

            JabberID JID = new JabberID(tbUserName.Text.ToString(), tbServerName.Text.ToString(), Properties.Settings.Default.Resource);
            Contact delContact = new Contact(JID, tbGroupName.Text.Trim(), LoginState.Offline);

            foreach (Contact contact in AppController.Instance.Contacts)
            {
                if (contact.Equals(delContact))
                {
                    foundcontact = true;
                }
            }

            if (foundcontact)
            {
                JabberID Jid = new JabberID(tbUserName.Text.ToString(), tbServerName.Text.ToString(), "");

                UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                AppController.Instance.SessionManager.Send(resp);
                AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, tbUserName.Text.ToString()));
                AppController.Instance.Contacts.Remove(delContact);
                AppController.Instance.MainWindow.UpdateContactList();
            }

            else if (!foundcontact)
            {
                MessageBox.Show("Contact to be deleted doesnot exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
           

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