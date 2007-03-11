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
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArrayList deleteusers = new ArrayList();
            this.Hide();

            if (tbGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a valid Group name!");
                this.Show();
            }

            else
            {

                bool groupexist = false;

                foreach (Contact contact in AppController.Instance.Contacts)
                {
                    if (contact.GroupName.Equals(tbGroupName.Text))
                    {
                          groupexist = true;
                          deleteusers.Add(contact.UserName);
                        
                    }
                }


                if (groupexist)
                {
                    for (int i = 0; i < deleteusers.Count; i++)
                    {
                        
                        Contact delcontact = AppController.Instance.Contacts[deleteusers[i].ToString()];
                        
                        JabberID Jid = new JabberID(delcontact.UserName.ToString(), delcontact.ServerName.ToString(), Properties.Settings.Default.Resource);
                        //Contact delContact = new Contact(Jid, tbGroupName.Text.Trim(), LoginState.Offline);
                        UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                        AppController.Instance.SessionManager.Send(resp);
                        AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, delcontact.UserName.ToString()));
                        AppController.Instance.Contacts.Remove(delcontact);
                        AppController.Instance.MainWindow.UpdateContactList();
                    }
                }
                if (!groupexist)
                {
                    MessageBox.Show("Group name does not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }

            }
        }

      
    }//class
}