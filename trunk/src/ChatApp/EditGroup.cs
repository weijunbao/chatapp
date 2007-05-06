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
using System.Collections;

namespace ChatApp
{
    public partial class EditGroup : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public EditGroup()
        {
            InitializeComponent();
            cbOldgroup.Items.AddRange(AppController.Instance.Contacts.GetAllGroups().ToArray());
            if (cbOldgroup.Items.Count > 0)
            {
                cbOldgroup.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            ArrayList editgroup = new ArrayList();

            if (ValidateInput() == false)
            {
                DialogResult = DialogResult.None;
                return;
            }
            
            foreach (Contact contact in AppController.Instance.Contacts)
            {
           
                if (contact.GroupName.Equals(cbOldgroup.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    editgroup.Add(contact.UserName);
                }
            }

            for (int i = 0; i < editgroup.Count; i++)
                {
                    Contact editGp = AppController.Instance.Contacts[editgroup[i].ToString()];
                    JabberID Jid = new JabberID(editGp.UserName.ToString(), editGp.ServerName.ToString(), Properties.Settings.Default.Resource);

                    Contact delContact = new Contact(Jid, editGp.GroupName.ToString(), LoginState.Offline);
                    Contact editContact = new Contact(Jid, tbNewGroup.Text.Trim(), LoginState.Offline);
                    
                    UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                    AppController.Instance.SessionManager.Send(resp);
                    AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, editGp.UserName.ToString()));
                    AppController.Instance.Contacts.Remove(delContact);

                    SubscribeRequest p = new SubscribeRequest(Jid);
                    AppController.Instance.SessionManager.Send(p);
                    AppController.Instance.SessionManager.BeginSend(new RosterAdd(Jid, editGp.UserName.ToString(), tbNewGroup.Text.ToString()));
                    AppController.Instance.Contacts.Add(editContact);


                    AppController.Instance.MainWindow.UpdateContactList();


                }

        }

        private bool ValidateInput()
        {
            if (tbNewGroup.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a group name");
                return false;
            }

            return true;
        }
    }
}