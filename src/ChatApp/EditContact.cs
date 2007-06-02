#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * EditContact.cs - Window to Edit Groups
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
    public partial class EditContact : KryptonForm
    {
        public EditContact()
        {
            InitializeComponent();
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                cbContactname.Items.Add(contact.UserName.ToString());
            }
        }

        #region Event Handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            Hide();
            if (ValidateInput() == false)
            {
                DialogResult = DialogResult.None;
                return;
            }

            Contact contact = AppController.Instance.Contacts[cbContactname.SelectedItem.ToString()];
            JabberID Jid =
                new JabberID(contact.UserName.ToString(), contact.ServerName.ToString(), Settings.Default.Resource);
            Contact delContact = new Contact(Jid, contact.GroupName.ToString(), LoginState.Offline);
            Contact editContact = new Contact(Jid, tbnewGpName.Text.Trim(), LoginState.Offline);

            UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
            AppController.Instance.SessionManager.Send(resp);
            AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, contact.UserName.ToString()));
            AppController.Instance.Contacts.Remove(delContact);

            SubscribeRequest p = new SubscribeRequest(Jid);
            AppController.Instance.SessionManager.Send(p);
            AppController.Instance.SessionManager.BeginSend(
                new RosterAdd(Jid, contact.UserName.ToString(), tbnewGpName.Text.ToString()));
            AppController.Instance.Contacts.Add(editContact);


            AppController.Instance.MainWindow.UpdateContactList();
        }

        #endregion

        private bool ValidateInput()
        {
            if (tbnewGpName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a Group for your Contact");
                return false;
            }

            return true;
        }

        internal void SelectContact(JabberID contactID)
        {
            if (contactID == null)
                return;

            if (cbContactname.Items.Contains(contactID.UserName))
            {
                cbContactname.SelectedIndex = cbContactname.FindString(contactID.UserName);
            }
        }

        private void EditContact_Load(object sender, EventArgs e)
        {

        }
    }
}