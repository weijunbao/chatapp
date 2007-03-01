namespace ChatApp
{
    partial class LoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.WaitLabel = new System.Windows.Forms.Label();
            this.LoginButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.lbl_ServerName = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.lbl_UserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginButton)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.WaitLabel);
            this.kryptonPanel1.Controls.Add(this.LoginButton);
            this.kryptonPanel1.Controls.Add(this.checkBoxRemember);
            this.kryptonPanel1.Controls.Add(this.ServerNameTextBox);
            this.kryptonPanel1.Controls.Add(this.lbl_ServerName);
            this.kryptonPanel1.Controls.Add(this.PasswordTextBox);
            this.kryptonPanel1.Controls.Add(this.lbl_Password);
            this.kryptonPanel1.Controls.Add(this.UserNameTextBox);
            this.kryptonPanel1.Controls.Add(this.lbl_UserName);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(296, 201);
            this.kryptonPanel1.TabIndex = 0;
            this.kryptonPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel1_Paint);
            // 
            // WaitLabel
            // 
            this.WaitLabel.AutoSize = true;
            this.WaitLabel.BackColor = System.Drawing.Color.Transparent;
            this.WaitLabel.Location = new System.Drawing.Point(15, 163);
            this.WaitLabel.Name = "WaitLabel";
            this.WaitLabel.Size = new System.Drawing.Size(73, 13);
            this.WaitLabel.TabIndex = 17;
            this.WaitLabel.Text = "Connecting....";
            this.WaitLabel.Visible = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(195, 158);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.LoginButton.Size = new System.Drawing.Size(90, 31);
            this.LoginButton.TabIndex = 16;
            this.LoginButton.Values.Text = "Login";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRemember.Checked = global::ChatApp.Properties.Settings.Default.RememberPassword;
            this.checkBoxRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRemember.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ChatApp.Properties.Settings.Default, "RememberPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxRemember.Location = new System.Drawing.Point(161, 105);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(126, 17);
            this.checkBoxRemember.TabIndex = 12;
            this.checkBoxRemember.Text = "Remember Password";
            this.checkBoxRemember.UseVisualStyleBackColor = false;
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChatApp.Properties.Settings.Default, "Server", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ServerNameTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.ServerNameTextBox.Location = new System.Drawing.Point(15, 130);
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(270, 22);
            this.ServerNameTextBox.TabIndex = 14;
            this.ServerNameTextBox.Text = global::ChatApp.Properties.Settings.Default.Server;
            // 
            // lbl_ServerName
            // 
            this.lbl_ServerName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ServerName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_ServerName.Location = new System.Drawing.Point(12, 114);
            this.lbl_ServerName.Name = "lbl_ServerName";
            this.lbl_ServerName.Size = new System.Drawing.Size(70, 13);
            this.lbl_ServerName.TabIndex = 13;
            this.lbl_ServerName.Text = "Server";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChatApp.Properties.Settings.Default, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PasswordTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 77);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(273, 22);
            this.PasswordTextBox.TabIndex = 11;
            this.PasswordTextBox.Text = global::ChatApp.Properties.Settings.Default.Password;
            // 
            // lbl_Password
            // 
            this.lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Password.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_Password.Location = new System.Drawing.Point(12, 62);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(76, 14);
            this.lbl_Password.TabIndex = 10;
            this.lbl_Password.Text = "Password";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChatApp.Properties.Settings.Default, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UserNameTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.UserNameTextBox.Location = new System.Drawing.Point(12, 24);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(273, 22);
            this.UserNameTextBox.TabIndex = 9;
            this.UserNameTextBox.Text = global::ChatApp.Properties.Settings.Default.UserName;
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_UserName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lbl_UserName.Location = new System.Drawing.Point(12, 10);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(76, 14);
            this.lbl_UserName.TabIndex = 8;
            this.lbl_UserName.Text = "User Name";
            // 
            // LoginWindow
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(296, 201);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter User Credentials";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        internal System.Windows.Forms.TextBox ServerNameTextBox;
        internal System.Windows.Forms.Label lbl_ServerName;
        internal System.Windows.Forms.TextBox PasswordTextBox;
        internal System.Windows.Forms.Label lbl_Password;
        internal System.Windows.Forms.TextBox UserNameTextBox;
        internal System.Windows.Forms.Label lbl_UserName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton LoginButton;
        private System.Windows.Forms.Label WaitLabel;
    }
}