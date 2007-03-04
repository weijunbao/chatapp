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
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ContactList m_contacts = AppController.Instance.Contacts;
            Contact contact;
            MainWindow m_mainWindow = AppController.Instance.MainWindow;
            SessionManager m_sessionMgr = AppController.Instance.SessionManager;
            //m_mainWindow.tvContacts.Nodes.Clear();
            bool contactexist = false;

            for (int i = 0; i < m_contacts.Count; ++i)
            {
                contact = m_contacts[i];
                string contactname = contact.UserName;
                if (contactname.Equals(tbContactName.Text, StringComparison.OrdinalIgnoreCase))
                {
                    contactexist = true;
                    break;
                }
            }

            if (contactexist)
            {
                for (int i = 0; i < m_contacts.Count; ++i)
                {
                    contact = m_contacts[i];
                    string contactname = contact.UserName;
                    if (contactname.Equals(tbContactName.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        contact.GroupName = tbNewGname.Text.ToString();

                        JabberID Jid = new JabberID(contact.UserName.ToString(), contact.ServerName.ToString(), "");
                        UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                        m_sessionMgr.Send(resp);
                        m_sessionMgr.BeginSend(new RosterRemove(Jid, contact.UserName.ToString()));


                        SubscribeRequest p = new SubscribeRequest(Jid);
                        m_sessionMgr.Send(p);
                        m_sessionMgr.BeginSend(new RosterAdd(Jid, contact.UserName.ToString(), contact.GroupName.ToString()));
                    }
                }

            }
            else //if contact does not exist
            {
                MessageBox.Show("Contact does not exist", "Change Group", MessageBoxButtons.OK);
                EditContact edtWnd = new EditContact();
                edtWnd.Show();
            }
            m_mainWindow.UpdateContactList();
        }
    }
}