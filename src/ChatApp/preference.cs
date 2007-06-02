#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * preference.cs - Preferance Dialog
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

namespace ChatApp
{
    public partial class preference : KryptonForm
    {
        public preference()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void btcancel_Click(object sender, EventArgs e)
        {
            // Don't save preferences; just hide the dialog
            Hide();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            // Get the preferences from the controls
            Settings.Default.FriendOnlinePlaySound = cbOsound.Checked;
            Settings.Default.FriendOnlineShowNotification = cbOnotify.Checked;
            Settings.Default.IncomingMessagePlaySound = cbChplay.Checked;
            Settings.Default.IncomingMessageShowNotification = cbChnotify.Checked;

            // Save the preferences to the Application properties
            Settings.Default.Save();

            Hide();
        }

        private void preference_Load(object sender, EventArgs e)
        {
            // Load the preferences
            cbOsound.Checked = Settings.Default.FriendOnlinePlaySound;
            cbOnotify.Checked = Settings.Default.FriendOnlineShowNotification;
            cbChplay.Checked = Settings.Default.IncomingMessagePlaySound;
            cbChnotify.Checked = Settings.Default.IncomingMessageShowNotification;
        }

        #endregion
    }
}