using System;
using System.Collections;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class DeleteGroup : KryptonForm
    {
        public DeleteGroup()
        {
            InitializeComponent();
            cbDeletegroup.Items.AddRange(AppController.Instance.Contacts.GetAllGroups().ToArray());
            if (cbDeletegroup.Items.Count > 0)
            {
                cbDeletegroup.SelectedIndex = 0;
            }
        }

        #region Event Handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArrayList deleteUsers = new ArrayList();
            Hide();

            foreach (Contact contact in AppController.Instance.Contacts)
            {
                if (contact.GroupName.Equals(cbDeletegroup.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    deleteUsers.Add(contact.UserName);
                }
            }

            for (int i = 0; i < deleteUsers.Count; i++)
            {
                Contact delcontact = AppController.Instance.Contacts[deleteUsers[i].ToString()];
                JabberID Jid =
                    new JabberID(delcontact.UserName.ToString(), delcontact.ServerName.ToString(),
                                 Settings.Default.Resource);

                UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                AppController.Instance.SessionManager.Send(resp);
                AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, delcontact.UserName.ToString()));

                AppController.Instance.Contacts.Remove(delcontact);
                AppController.Instance.MainWindow.UpdateContactList();
            }
        }

        #endregion
    } //class
}