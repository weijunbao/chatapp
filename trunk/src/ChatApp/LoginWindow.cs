using System;
using System.Net;
using System.Windows.Forms;
using ChatApp.Properties;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;

namespace ChatApp
{
    public partial class LoginWindow : KryptonForm
    {
        private string baseCaption;
        private bool m_loginSuccess = false;

        public LoginWindow()
        {
            InitializeComponent();
            baseCaption = Text;
        }

        #region Event Handlers

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            WaitLabel.Text = String.Empty; // Reset the previous error message
            WaitLabel.Visible = true;
            EnableControls(false);
            if (IsInputValid())
            {
                m_loginSuccess =
                    AppController.Instance.Login(UserNameTextBox.Text, PasswordTextBox.Text, ServerNameTextBox.Text);
            }
            if (m_loginSuccess)
                Close();
            else
            {
                EnableControls(true);
                WaitLabel.Text = "Login failed. Please try again";
            }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
        }

        #endregion

        public bool LoginSuccessful
        {
            get { return m_loginSuccess; }
        }

        private void EnableControls(bool bEnable)
        {
            UserNameTextBox.Enabled = bEnable;
            PasswordTextBox.Enabled = bEnable;
            checkBoxRemember.Enabled = bEnable;
            ServerNameTextBox.Enabled = bEnable;
            LoginButton.Enabled = bEnable;
        }

        private bool IsInputValid()
        {
            UserNameTextBox.Text = UserNameTextBox.Text.Trim();
            PasswordTextBox.Text = PasswordTextBox.Text.Trim();
            ServerNameTextBox.Text = ServerNameTextBox.Text.Trim();

            bool IsError = false;
            if (string.IsNullOrEmpty(UserNameTextBox.Text))
            {
                ShowError("User Name", UserNameTextBox);
                IsError = true;
            }
            else if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                ShowError("Password", PasswordTextBox);
                IsError = true;
            }
            else if (string.IsNullOrEmpty(ServerNameTextBox.Text))
            {
                ShowError("Server Name", ServerNameTextBox);
                IsError = true;
            }

            try
            {
                JabberID jd = new JabberID(UserNameTextBox.Text, AppController.Resource);
            }
            catch
            {
                MessageBox.Show(
                    "Your user name is not formatted correctly. Please use a different user name.\nExamples of a valid user name are: 'ViewsonicUser', 'CertificationUser', 'JohnDoe'",
                    "Invalid Characters");
                IsError = true;
            }

            string hostName = ServerNameTextBox.Text;
            try
            {
                Cursor = Cursors.WaitCursor;
                Text = string.Format("{0}  -  Validating Server Name", baseCaption);
                IPHostEntry IP = Dns.GetHostEntry(hostName);
            }
            catch
            {
                MessageBox.Show("The Server name you entered cannot be found. Please try a different server.",
                                "Unknown Host Name");
                IsError = true;
            }
            finally
            {
                Text = baseCaption;
                Cursor = Cursors.Default;
            }

            Settings.Default.UserName = UserNameTextBox.Text;
            if (checkBoxRemember.Checked)
            {
                Settings.Default.Password = PasswordTextBox.Text;
            }
            else
            {
                Settings.Default.Password = string.Empty;
            }
            Settings.Default.Server = ServerNameTextBox.Text;
            Settings.Default.Save();

            return !IsError;
        }

        private void ShowError(string ErrorContext, Control FocusControl)
        {
            MessageBox.Show(this, String.Format("Please Enter a valid {0}", ErrorContext), "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            FocusControl.Focus();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainWindow m_mainWindow = AppController.Instance.MainWindow;
            m_mainWindow.Show();
        }
    }
}