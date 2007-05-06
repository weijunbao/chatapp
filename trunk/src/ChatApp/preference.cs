using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 


namespace ChatApp
{
    public partial class preference : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public preference()
        {
            InitializeComponent();
        }

        private void preference_Load(object sender, EventArgs e)
        {
            // Load the preferences
            cbOsound.Checked   = ChatApp.Properties.Settings.Default.FriendOnlinePlaySound;
            cbOnotify.Checked  = ChatApp.Properties.Settings.Default.FriendOnlineShowNotification;
            cbChplay.Checked   = ChatApp.Properties.Settings.Default.IncomingMessagePlaySound;
            cbChnotify.Checked = ChatApp.Properties.Settings.Default.IncomingMessageShowNotification;
        }

        private void btok_Click(object sender, EventArgs e)
        {
            // Get the preferences from the controls
            ChatApp.Properties.Settings.Default.FriendOnlinePlaySound = cbOsound.Checked;
            ChatApp.Properties.Settings.Default.FriendOnlineShowNotification = cbOnotify.Checked;
            ChatApp.Properties.Settings.Default.IncomingMessagePlaySound = cbChplay.Checked;
            ChatApp.Properties.Settings.Default.IncomingMessageShowNotification = cbChnotify.Checked;

            // Save the preferences to the Application properties
            ChatApp.Properties.Settings.Default.Save();

            this.Hide();
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            // Don't save preferences; just hide the dialog
            this.Hide();
        }
    }
}