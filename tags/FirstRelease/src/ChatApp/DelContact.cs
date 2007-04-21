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
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                cbUsername.Items.Add(contact.UserName.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {


            Contact delContact = AppController.Instance.Contacts[cbUsername.SelectedItem.ToString()];
            JabberID Jid = new JabberID(delContact.UserName.ToString(), delContact.ServerName.ToString(), Properties.Settings.Default.Resource);

            UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
            AppController.Instance.SessionManager.Send(resp);
            AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, cbUsername.SelectedItem.ToString()));
            AppController.Instance.Contacts.Remove(delContact);
            AppController.Instance.MainWindow.UpdateContactList();
            this.Hide();

        }

    }
}