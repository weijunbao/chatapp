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