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
    public partial class DeleteGroup : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public DeleteGroup()
        {
            InitializeComponent();
        }

        private void DeleteGroup_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (tbGname.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a valid Group name!");
                DeleteGroup delgWnd = new DeleteGroup();
                delgWnd.Show();
            }

            else
            {
                ContactList m_contacts = AppController.Instance.Contacts;
                Contact contact;
                MainWindow m_mainWindow = AppController.Instance.MainWindow;
                SessionManager m_sessionMgr = AppController.Instance.SessionManager;
                bool showallcontacts = true;
                bool groupexist = false;

                for (int i = 0; i < m_contacts.Count; ++i)
                {
                    contact = m_contacts[i];
                    string groupName = contact.GroupName;
                    if (groupName.Equals(tbGname.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        groupexist = true;
                        break;
                    }
                }

                if (groupexist)
                {
                    string message = "Are you sure you want to delete group " + tbGname.Text + " and its contacts?";
                    if (DialogResult.Yes == MessageBox.Show(message, "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) ;
                    {
                        for (int i = 0; i < m_contacts.Count; ++i)
                        {
                            contact = m_contacts[i];
                            string groupName = contact.GroupName;
                            if (groupName.Equals(tbGname.Text, StringComparison.OrdinalIgnoreCase))
                            {
                                JabberID Jid = new JabberID(contact.UserName.ToString(), contact.ServerName.ToString(), "");
                                UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                                m_sessionMgr.Send(resp);
                                m_sessionMgr.BeginSend(new RosterRemove(Jid, contact.UserName.ToString()));
                            }
                        }
                    }
                }

                else  //---if group does not exist
                {
                    MessageBox.Show("Group to be deleted doesnot exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DeleteGroup delgWnd = new DeleteGroup();
                    delgWnd.Show();
                }

                foreach (TreeNode node in m_mainWindow.tvContacts.Nodes)
                {

                    if (node.Text == tbGname.Text.ToString())
                    {
                        node.Remove();
                        foreach (TreeNode userNode in node.Nodes)
                        {
                            contact = m_contacts[userNode.Text.ToString()];
                            userNode.Remove();
                            m_contacts.DeleteContact(contact);
                        }
                    }
                }
                m_mainWindow.UpdateContactList(showallcontacts);
            }//else

        }//button click  
    }//class

}