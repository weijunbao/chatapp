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
using ComponentFactory.Krypton.Toolkit;

namespace ChatApp
{
    public partial class EditContact : KryptonForm
    {
        public EditContact()
        {
            InitializeComponent();
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                cbContactname.Items.Add(contact.UserName.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (ValidateInput() == false)
            {
                DialogResult = DialogResult.None;
                return;
            }

            Contact contact = AppController.Instance.Contacts[cbContactname.SelectedItem.ToString()];
            JabberID Jid = new JabberID(contact.UserName.ToString(), contact.ServerName.ToString(), Properties.Settings.Default.Resource);
            Contact delContact = new Contact(Jid, contact.GroupName.ToString(), LoginState.Offline);
            Contact editContact = new Contact(Jid, tbnewGpName.Text.Trim(), LoginState.Offline);

            UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
            AppController.Instance.SessionManager.Send(resp);
            AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, contact.UserName.ToString()));
            AppController.Instance.Contacts.Remove(delContact);

            SubscribeRequest p = new SubscribeRequest(Jid);
            AppController.Instance.SessionManager.Send(p);
            AppController.Instance.SessionManager.BeginSend(new RosterAdd(Jid, contact.UserName.ToString(), tbnewGpName.Text.ToString()));
            AppController.Instance.Contacts.Add(editContact);


            AppController.Instance.MainWindow.UpdateContactList();
        }


        private bool ValidateInput()
        {
            if (tbnewGpName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Group for your Contact");
                return false;
            }

            return true;
        }

        internal void SelectContact(JabberID contactID)
        {
            if (contactID == null)
                return;

            if (cbContactname.Items.Contains(contactID.UserName))
            {
                cbContactname.SelectedIndex = cbContactname.FindString(contactID.UserName);
            }
        }
    }
}