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
    public partial class EditGroup : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public EditGroup()
        {
            InitializeComponent();
        }

        private void EditGroup_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
               this.Hide();
            
                ContactList m_contacts = AppController.Instance.Contacts;
                Contact contact;
                MainWindow m_mainWindow = AppController.Instance.MainWindow;
                SessionManager m_sessionMgr = AppController.Instance.SessionManager;
                m_mainWindow.tvContacts.Nodes.Clear();
                bool grouppresent = false;

                for (int i = 0; i < m_contacts.Count; ++i)
                {
                    contact = m_contacts[i];
                    string groupName = contact.GroupName;
                    if (groupName.Equals(tbOldGroup.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        contact.GroupName = tbNewGroup.Text.ToString();

                        JabberID Jid = new JabberID(contact.UserName.ToString(), contact.ServerName.ToString(), "");
                        UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                        m_sessionMgr.Send(resp);
                        m_sessionMgr.BeginSend(new RosterRemove(Jid, contact.UserName.ToString()));
                        
                        
                        SubscribeRequest p = new SubscribeRequest(Jid);
                        m_sessionMgr.Send(p);
                        m_sessionMgr.BeginSend(new RosterAdd(Jid, contact.UserName.ToString(), contact.GroupName.ToString()));

                        grouppresent = true;
                    }
                }

                if (!grouppresent)
                {
                    MessageBox.Show("Group to be renamed doesnot exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (TreeNode node in m_mainWindow.tvContacts.Nodes)
                {
                    // If the tree already contain this group, do not add it
                    if (node.Text.Equals(tbOldGroup.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        node.Text.Replace(tbOldGroup.Text.ToString(),tbNewGroup.Text.ToString());
                        break;
                    }
                }

                m_mainWindow.UpdateContactList();
        
        }
    }
}