namespace ChatApp
{
    partial class MainWindow
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
            System.Windows.Forms.ToolStripMenuItem chatAppToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.myProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.awayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.sortByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.rootPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblWelcome = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblStatus = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.BtnLogout = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.tvContacts = new System.Windows.Forms.TreeView();
            this.StatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            chatAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.statusContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rootPanel)).BeginInit();
            this.rootPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chatAppToolStripMenuItem
            // 
            chatAppToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myProfileToolStripMenuItem,
            this.preferenceToolStripMenuItem});
            chatAppToolStripMenuItem.Name = "chatAppToolStripMenuItem";
            chatAppToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            chatAppToolStripMenuItem.Text = "&Tools";
            // 
            // myProfileToolStripMenuItem
            // 
            this.myProfileToolStripMenuItem.Name = "myProfileToolStripMenuItem";
            this.myProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.myProfileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.myProfileToolStripMenuItem.Text = "My profile";
            // 
            // preferenceToolStripMenuItem
            // 
            this.preferenceToolStripMenuItem.Name = "preferenceToolStripMenuItem";
            this.preferenceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.preferenceToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.preferenceToolStripMenuItem.Text = "Preferences";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactsToolStripMenuItem,
            this.actionsToolStripMenuItem,
            chatAppToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(292, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.deleteContactToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editGroupToolStripMenuItem,
            this.deleteGroupToolStripMenuItem});
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.contactsToolStripMenuItem.Text = "&Contacts";
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.addContactToolStripMenuItem_Click);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editContactToolStripMenuItem.Text = "Edit Contact";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.editContactToolStripMenuItem_Click);
            // 
            // deleteContactToolStripMenuItem
            // 
            this.deleteContactToolStripMenuItem.Name = "deleteContactToolStripMenuItem";
            this.deleteContactToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteContactToolStripMenuItem.Text = "Delete Contact";
            this.deleteContactToolStripMenuItem.Click += new System.EventHandler(this.deleteContactToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editGroupToolStripMenuItem.Text = "Rename Group";
            this.editGroupToolStripMenuItem.Click += new System.EventHandler(this.editGroupToolStripMenuItem_Click);
            // 
            // deleteGroupToolStripMenuItem
            // 
            this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteGroupToolStripMenuItem.Text = "Delete Group";
            this.deleteGroupToolStripMenuItem.Click += new System.EventHandler(this.deleteGroupToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setStatusMenuItem,
            this.startAToolStripMenuItem,
            this.toolStripMenuItem4,
            this.sortByNameToolStripMenuItem,
            this.sortByGroupToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // setStatusMenuItem
            // 
            this.setStatusMenuItem.DropDown = this.statusContextMenuStrip;
            this.setStatusMenuItem.Name = "setStatusMenuItem";
            this.setStatusMenuItem.Size = new System.Drawing.Size(170, 22);
            this.setStatusMenuItem.Text = "Set Online Status";
            // 
            // statusContextMenuStrip
            // 
            this.statusContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.statusContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.awayMenuItem,
            this.onlineMenuItem,
            this.busyMenuItem,
            this.offlineMenuItem});
            this.statusContextMenuStrip.Name = "statusContextMenuStrip";
            this.statusContextMenuStrip.Size = new System.Drawing.Size(118, 92);
            // 
            // awayMenuItem
            // 
            this.awayMenuItem.Image = global::ChatApp.Properties.Resources.status_away;
            this.awayMenuItem.Name = "awayMenuItem";
            this.awayMenuItem.Size = new System.Drawing.Size(117, 22);
            this.awayMenuItem.Tag = LoginState.Away;
            this.awayMenuItem.Text = "Away";
            this.awayMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // onlineMenuItem
            // 
            this.onlineMenuItem.Image = global::ChatApp.Properties.Resources.status_online;
            this.onlineMenuItem.Name = "onlineMenuItem";
            this.onlineMenuItem.Size = new System.Drawing.Size(117, 22);
            this.onlineMenuItem.Tag = LoginState.Online;
            this.onlineMenuItem.Text = "Online";
            this.onlineMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // busyMenuItem
            // 
            this.busyMenuItem.Image = global::ChatApp.Properties.Resources.status_busy;
            this.busyMenuItem.Name = "busyMenuItem";
            this.busyMenuItem.Size = new System.Drawing.Size(117, 22);
            this.busyMenuItem.Tag = LoginState.Busy;
            this.busyMenuItem.Text = "Busy";
            this.busyMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // offlineMenuItem
            // 
            this.offlineMenuItem.Image = global::ChatApp.Properties.Resources.status_offline;
            this.offlineMenuItem.Name = "offlineMenuItem";
            this.offlineMenuItem.Size = new System.Drawing.Size(117, 22);
            this.offlineMenuItem.Tag = LoginState.Offline;
            this.offlineMenuItem.Text = "Offline";
            this.offlineMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // startAToolStripMenuItem
            // 
            this.startAToolStripMenuItem.Name = "startAToolStripMenuItem";
            this.startAToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.startAToolStripMenuItem.Text = "Start a chat";
            this.startAToolStripMenuItem.Click += new System.EventHandler(this.StartChatMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(167, 6);
            // 
            // sortByNameToolStripMenuItem
            // 
            this.sortByNameToolStripMenuItem.Name = "sortByNameToolStripMenuItem";
            this.sortByNameToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sortByNameToolStripMenuItem.Text = "Sort by name";
            this.sortByNameToolStripMenuItem.Click += new System.EventHandler(this.sortByNameToolStripMenuItem_Click);
            // 
            // sortByGroupToolStripMenuItem
            // 
            this.sortByGroupToolStripMenuItem.Name = "sortByGroupToolStripMenuItem";
            this.sortByGroupToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sortByGroupToolStripMenuItem.Text = "Sort by group";
            this.sortByGroupToolStripMenuItem.Click += new System.EventHandler(this.sortByGroupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // rootPanel
            // 
            this.rootPanel.Controls.Add(this.lblWelcome);
            this.rootPanel.Controls.Add(this.lblStatus);
            this.rootPanel.Controls.Add(this.BtnLogout);
            this.rootPanel.Controls.Add(this.userPictureBox);
            this.rootPanel.Controls.Add(this.splitContainer);
            this.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootPanel.Location = new System.Drawing.Point(0, 24);
            this.rootPanel.Name = "rootPanel";
            this.rootPanel.Size = new System.Drawing.Size(292, 249);
            this.rootPanel.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.lblWelcome.Location = new System.Drawing.Point(62, 6);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(89, 27);
            this.lblWelcome.TabIndex = 20;
            this.lblWelcome.Values.Text = "Welcome";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(62, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 19);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Values.Image = global::ChatApp.Properties.Resources.status_online;
            this.lblStatus.Values.Text = "Online";
            this.lblStatus.LinkClicked += new System.EventHandler(this.lblStatus_LinkClicked);
            // 
            // BtnLogout
            // 
            this.BtnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLogout.Location = new System.Drawing.Point(214, 6);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.BtnLogout.Size = new System.Drawing.Size(69, 27);
            this.BtnLogout.TabIndex = 14;
            this.BtnLogout.Values.Text = "Logout";
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // userPictureBox
            // 
            this.userPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userPictureBox.ErrorImage = null;
            this.userPictureBox.Image = global::ChatApp.Properties.Resources.user48;
            this.userPictureBox.ImageLocation = "";
            this.userPictureBox.InitialImage = null;
            this.userPictureBox.Location = new System.Drawing.Point(9, 5);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(48, 48);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userPictureBox.TabIndex = 12;
            this.userPictureBox.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(9, 56);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tvContacts);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbSearch);
            this.splitContainer.Size = new System.Drawing.Size(274, 184);
            this.splitContainer.SplitterDistance = 157;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 17;
            // 
            // tvContacts
            // 
            this.tvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContacts.HideSelection = false;
            this.tvContacts.ImageIndex = 0;
            this.tvContacts.ImageList = this.StatusImageList;
            this.tvContacts.Location = new System.Drawing.Point(0, 0);
            this.tvContacts.Name = "tvContacts";
            this.tvContacts.SelectedImageIndex = 0;
            this.tvContacts.Size = new System.Drawing.Size(274, 157);
            this.tvContacts.TabIndex = 0;
            this.tvContacts.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvContacts_NodeMouseDoubleClick);
            // 
            // StatusImageList
            // 
            this.StatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImageList.ImageStream")));
            this.StatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImageList.Images.SetKeyName(0, "Away");
            this.StatusImageList.Images.SetKeyName(1, "Online");
            this.StatusImageList.Images.SetKeyName(2, "Busy");
            this.StatusImageList.Images.SetKeyName(3, "Offline");
            this.StatusImageList.Images.SetKeyName(4, "group.png");
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(-1, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(274, 20);
            this.tbSearch.TabIndex = 9;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(ChatApp.MainWindow);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.rootPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainWindow";
            this.Text = global::ChatApp.Properties.Settings.Default.AppName;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rootPanel)).EndInit();
            this.rootPanel.ResumeLayout(false);
            this.rootPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).EndInit();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem myProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel rootPanel;
        private System.Windows.Forms.PictureBox userPictureBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnLogout;
        // The tree view is made public so that AppController can access
        public System.Windows.Forms.TreeView tvContacts;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWelcome;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        public System.Windows.Forms.ImageList StatusImageList;
        public System.String currentUser;
        private System.Windows.Forms.ContextMenuStrip statusContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem awayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setStatusMenuItem;
        private System.Windows.Forms.TextBox tbSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainer;
    }
}

