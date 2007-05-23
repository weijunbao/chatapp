using System;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class DelContact : KryptonForm
    {
        public DelContact()
        {
            InitializeComponent();
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                cbUsername.Items.Add(contact.UserName.ToString());
            }
        }

        #region Event Handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            Contact delContact = AppController.Instance.Contacts[cbUsername.SelectedItem.ToString()];
            JabberID Jid =
                new JabberID(delContact.UserName.ToString(), delContact.ServerName.ToString(), Settings.Default.Resource);

            UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
            AppController.Instance.SessionManager.Send(resp);
            AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, cbUsername.SelectedItem.ToString()));
            AppController.Instance.Contacts.Remove(delContact);
            AppController.Instance.MainWindow.UpdateContactList();
            Hide();
        }

        #endregion

        internal void SelectContact(JabberID contactID)
        {
            if (contactID == null)
                return;

            if (cbUsername.Items.Contains(contactID.UserName))
            {
                cbUsername.SelectedIndex = cbUsername.FindString(contactID.UserName);
            }
        }
    }
}