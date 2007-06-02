#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * Copyright (C) 2007  George Chiramattel
 * http://george.chiramattel.com
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

#endregion //GNU-GPL

using System;
using System.Windows.Forms;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class AddContact : KryptonForm
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                DialogResult = DialogResult.None;
                return;
            }

            JabberID JID = null;
            string message = "The User ID you entered is not valid. Please enter a valid User ID";
            try
            {
                JID = new JabberID(tbUserName.Text.ToString(), tbServerName.Text.ToString(), Settings.Default.Resource);
                if (JID.UserName.Length == 0 ||
                    JID.Server.Length == 0)
                {
                    MessageBox.Show(message, "Invalid UserID");
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            catch
            {
                MessageBox.Show(message, "Invalid UserID");
                DialogResult = DialogResult.None;
                return;
            }
            Contact newContact = new Contact(JID, tbGroupName.Text.Trim(), LoginState.Offline);
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                if (contact.Equals(newContact))
                {
                    MessageBox.Show("Contact already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
            }

            SubscribeRequest subscribeRequest = new SubscribeRequest(JID);
            AppController.Instance.SessionManager.Send(subscribeRequest);
            AppController.Instance.SessionManager.BeginSend(
                new RosterAdd(JID, tbUserName.Text.Trim(), tbGroupName.Text.Trim()));
            AppController.Instance.Contacts.Add(newContact);
            AppController.Instance.MainWindow.UpdateContactList();
        }

        private bool ValidateInput()
        {
            if (tbUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a User ID for your Contact");
                return false;
            }

            if (tbServerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Server for your Contact");
                return false;
            }

            if (tbGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Group for your Contact");
                return false;
            }


            return true;
        }
    }
}