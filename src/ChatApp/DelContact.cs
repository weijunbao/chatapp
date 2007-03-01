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

        private void DelContact_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelContact dlWnd = new DelContact();
            bool noException = true;
                try
                {
                    if (tbUserName.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("You must enter a User ID for deleting Contact");
                        noException = false;
                        dlWnd.Show();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("The following exception has occurred:\n\n{0}.", ex));
                    noException = false;
                }

                MainWindow m_mainWindow = AppController.Instance.MainWindow;
                bool foundcontact = false;
                Contact contact = null;
                ContactList m_contacts = AppController.Instance.Contacts;

                foreach (TreeNode node in m_mainWindow.tvContacts.Nodes)
                {
                    contact = m_contacts[node.Text.ToString()];

                    foreach (TreeNode userNode in node.Nodes)
                    {
                        contact = m_contacts[userNode.Text.ToString()];
                        if (contact.UserName == tbUserName.Text.ToString())
                        {
                            foundcontact = true;
                        }
                    }
                }

                if (foundcontact)
                {
                    JabberID Jid = new JabberID(tbUserName.Text.ToString(), tbServerName.Text.ToString(), "");

                    UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                    SessionManager m_sessionMgr = AppController.Instance.SessionManager;
                    m_sessionMgr.Send(resp);
                    m_sessionMgr.BeginSend(new RosterRemove(Jid, tbUserName.Text.ToString()));

                    //--------------To remove the contact from the tree view

                    foreach (TreeNode node in m_mainWindow.tvContacts.Nodes)
                    {
                        contact = m_contacts[node.Text.ToString()];

                        foreach (TreeNode userNode in node.Nodes)
                        {
                            contact = m_contacts[userNode.Text.ToString()];
                            if (contact.UserName == tbUserName.Text.ToString())
                            {
                                userNode.Remove();
                                m_contacts.DeleteContact(contact);
                                foundcontact = true;
                            }
                        }
                    }
                }

                else if (!foundcontact && noException==true)
                {
                    MessageBox.Show("Contact to be deleted doesnot exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dlWnd.Show();
                }

                else
                {
                }

        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}