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
    public partial class AddContact : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        
        public AddContact()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();

            try
            {
                if (tbUserName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter a User ID for your Contact");
                    return;
                }
                
                if (tbServerName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter a Server for your Contact");
                    return;
                }

                if (tbGroupName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter a Group for your Contact");
                    return;
                }

                try
                {
                    JabberID J = new JabberID(tbUserName.Text.ToString(),tbServerName.Text.ToString(),"");
                    if (J.UserName.Length == 0 ||
                        J.Server.Length == 0)
                    {
                        MessageBox.Show("The User ID you entered is not valid. Please enter a valid User ID", "Invalid UserID");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("The User ID you entered is not valid. Please enter a valid User ID", "Invalid UserID");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("The following exception has occurred:\n\n{0}.", ex));
            }

            MainWindow m_mainWindow = AppController.Instance.MainWindow;
            ContactList m_contacts = AppController.Instance.Contacts;
            bool showallcontacts = true;
            bool contactadd = true;
            Contact c;
            
            Contact contact = new Contact(tbUserName.Text.ToString(), 
                                            tbUserName.Text.ToString(), 
                                            Properties.Settings.Default.Resource, 
                                            tbServerName.Text.ToString(), 
                                            tbGroupName.Text.ToString(), 
                                            LoginState.Offline);
           

            for (int i = 0; i < m_contacts.Count; i++)
            {
                c = m_contacts[i];
                if ((c.UserName.Equals(contact.UserName, StringComparison.OrdinalIgnoreCase))&&(c.ServerName.Equals(contact.ServerName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Contact already exists!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    contactadd = false;
                    break;
                }
            }

            if (contactadd)
            {
                m_contacts.AddContact(contact);
                
                
                JabberID Jid = new JabberID(tbUserName.Text.ToString(), tbServerName.Text.ToString(), "");
                SubscribeRequest p = new SubscribeRequest(Jid);
                SessionManager m_sessionMgr = AppController.Instance.SessionManager;
                m_sessionMgr.Send(p);
                m_sessionMgr.BeginSend(new RosterAdd(Jid, tbUserName.Text.ToString(), tbGroupName.Text.ToString()));
           
            }
            
            m_mainWindow.UpdateContactList(showallcontacts);
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddContact_Load(object sender, EventArgs e)
        {

        }
    }
}