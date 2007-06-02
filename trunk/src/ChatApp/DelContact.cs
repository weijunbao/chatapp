#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * DelContact.cs - Window to delete a contact
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
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class DelContact : KryptonForm
    {
        public DelContact()
        {
            InitializeComponent();
            foreach (Contact contact in AppController.Instance.Contacts)
            {
                cbUsername.Items.Add(contact.UserName.ToString());
            }
        }

        #region Event Handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            Contact delContact = AppController.Instance.Contacts[cbUsername.SelectedItem.ToString()];
            JabberID Jid =
                new JabberID(delContact.UserName.ToString(), delContact.ServerName.ToString(), Settings.Default.Resource);

            UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
            AppController.Instance.SessionManager.Send(resp);
            AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, cbUsername.SelectedItem.ToString()));
            AppController.Instance.Contacts.Remove(delContact);
            AppController.Instance.MainWindow.UpdateContactList();
            Hide();
        }

        #endregion

        internal void SelectContact(JabberID contactID)
        {
            if (contactID == null)
                return;

            if (cbUsername.Items.Contains(contactID.UserName))
            {
                cbUsername.SelectedIndex = cbUsername.FindString(contactID.UserName);
            }
        }
    }
}