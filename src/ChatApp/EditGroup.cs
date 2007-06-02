#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * EditGroup.cs - Window to Edit Groups
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
using System.Windows.Forms;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;

namespace ChatApp
{
    public partial class EditGroup : KryptonForm
    {
        public EditGroup()
        {
            InitializeComponent();
            cbOldgroup.Items.AddRange(AppController.Instance.Contacts.GetAllGroups().ToArray());
            if (cbOldgroup.Items.Count > 0)
            {
                cbOldgroup.SelectedIndex = 0;
            }
        }

        #region Event Handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            Hide();
            ArrayList editgroup = new ArrayList();

            if (ValidateInput() == false)
            {
                DialogResult = DialogResult.None;
                return;
            }

            foreach (Contact contact in AppController.Instance.Contacts)
            {
                if (contact.GroupName.Equals(cbOldgroup.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    editgroup.Add(contact.UserName);
                }
            }

            for (int i = 0; i < editgroup.Count; i++)
            {
                Contact editGp = AppController.Instance.Contacts[editgroup[i].ToString()];
                JabberID Jid =
                    new JabberID(editGp.UserName.ToString(), editGp.ServerName.ToString(), Settings.Default.Resource);

                Contact delContact = new Contact(Jid, editGp.GroupName.ToString(), LoginState.Offline);
                Contact editContact = new Contact(Jid, tbNewGroup.Text.Trim(), LoginState.Offline);

                UnsubscribedResponse resp = new UnsubscribedResponse(Jid);
                AppController.Instance.SessionManager.Send(resp);
                AppController.Instance.SessionManager.BeginSend(new RosterRemove(Jid, editGp.UserName.ToString()));
                AppController.Instance.Contacts.Remove(delContact);

                SubscribeRequest p = new SubscribeRequest(Jid);
                AppController.Instance.SessionManager.Send(p);
                AppController.Instance.SessionManager.BeginSend(
                    new RosterAdd(Jid, editGp.UserName.ToString(), tbNewGroup.Text.ToString()));
                AppController.Instance.Contacts.Add(editContact);


                AppController.Instance.MainWindow.UpdateContactList();
            }
        }

        #endregion

        private bool ValidateInput()
        {
            if (tbNewGroup.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a group name");
                return false;
            }

            return true;
        }
    }
}