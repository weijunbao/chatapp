#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * DeleteGroup.cs - Window to delete Groups
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
using System.Collections;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class DeleteGroup : KryptonForm
    {
        public DeleteGroup()
        {
            InitializeComponent();
            cbDeletegroup.Items.AddRange(AppController.Instance.Contacts.GetAllGroups().ToArray());
            if (cbDeletegroup.Items.Count > 0)
            {
                cbDeletegroup.SelectedIndex = 0;
            }
        }

        #region Event Handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArrayList deleteUsers = new ArrayList();
            Hide();

            foreach (Contact contact in AppController.Instance.Contacts)
            {
                if (contact.GroupName.Equals(cbDeletegroup.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    deleteUsers.Add(contact.UserName);
                }
            }

            for (int i = 0; i < deleteUsers.Count; i++)
            {
                Contact delcontact = AppController.Instance.Contacts[deleteUsers[i].ToString()];
                JabberID Jid =
                    new JabberID(delcontact.UserName.ToString(), delcontact.ServerName.ToString(),
                                 Settings.Default.Resource);

                UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                AppController.Instance.SessionManager.Send(resp);
                AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, delcontact.UserName.ToString()));

                AppController.Instance.Contacts.Remove(delcontact);
                AppController.Instance.MainWindow.UpdateContactList();
            }
        }

        #endregion

    } //class
}