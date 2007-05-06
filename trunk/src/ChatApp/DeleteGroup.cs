using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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
    public partial class DeleteGroup : ComponentFactory.Krypton.Toolkit.KryptonForm
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArrayList deleteUsers = new ArrayList();
            this.Hide();

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
                JabberID Jid = new JabberID(delcontact.UserName.ToString(), delcontact.ServerName.ToString(), Properties.Settings.Default.Resource);

                UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                AppController.Instance.SessionManager.Send(resp);
                AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, delcontact.UserName.ToString()));

                AppController.Instance.Contacts.Remove(delcontact);
                AppController.Instance.MainWindow.UpdateContactList();
            }
        }
    }//class
}