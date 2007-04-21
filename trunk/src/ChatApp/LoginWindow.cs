using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Coversant.SoapBox.Base;
using ChatApp.Properties;
using ComponentFactory.Krypton;

namespace ChatApp
{
    public partial class LoginWindow : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private string baseCaption;
        private bool m_loginSuccess = false;

        public bool LoginSuccessful
        {
            get 
            { 
                return m_loginSuccess; 
            }
        }

        public LoginWindow()
        {
            InitializeComponent();
            baseCaption = this.Text;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            WaitLabel.Text = String.Empty;      // Reset the previous error message
            WaitLabel.Visible = true;
            EnableControls(false);
            if (IsInputValid())
            {
                m_loginSuccess = AppController.Instance.Login(this.UserNameTextBox.Text, this.PasswordTextBox.Text, this.ServerNameTextBox.Text);
            }
            if (m_loginSuccess)
                this.Close();
            else
            {
                EnableControls(true);
                WaitLabel.Text = "Login failed. Please try again";
            }
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
            if (string.IsNullOrEmpty(this.UserNameTextBox.Text))
            {
                ShowError("User Name", UserNameTextBox);
                IsError = true;
            }
            else if (string.IsNullOrEmpty(this.PasswordTextBox.Text))
            {
                ShowError("Password", PasswordTextBox);
                IsError = true;
            }
            else if (string.IsNullOrEmpty(this.ServerNameTextBox.Text))
            {
                ShowError("Server Name", ServerNameTextBox);
                IsError = true;
            }

            try 
            { 
                JabberID jd = new JabberID(UserNameTextBox.Text,AppController.Resource);
            }
            catch
            {
                MessageBox.Show("Your user name is not formatted correctly. Please use a different user name.\nExamples of a valid user name are: 'ViewsonicUser', 'CertificationUser', 'JohnDoe'", "Invalid Characters");
                IsError = true;
            }

            string hostName = ServerNameTextBox.Text;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Text = string.Format("{0}  -  Validating Server Name", baseCaption);
                System.Net.IPHostEntry IP = System.Net.Dns.GetHostEntry(hostName);
            }
            catch
            {
                MessageBox.Show("The Server name you entered cannot be found. Please try a different server.", "Unknown Host Name");
                IsError = true;
            }
            finally
            {
                this.Text = baseCaption;
                this.Cursor = Cursors.Default;
            }

            Settings.Default.UserName = this.UserNameTextBox.Text;
            if (this.checkBoxRemember.Checked)
            {
                Settings.Default.Password = this.PasswordTextBox.Text;
            }
            else
            {
                Settings.Default.Password = string.Empty;
            }
            Settings.Default.Server   = this.ServerNameTextBox.Text;
            Settings.Default.Save();

            return !IsError;
        }

        private void ShowError(string ErrorContext, Control FocusControl)
        {
            MessageBox.Show(this, String.Format("Please Enter a valid {0}", ErrorContext), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FocusControl.Focus();
        }

        void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainWindow m_mainWindow = AppController.Instance.MainWindow;
            m_mainWindow.Show();
        }
    }
}