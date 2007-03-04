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
            this.startAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.sortByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_showOnlineContacts = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblWelcome = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tvContacts = new System.Windows.Forms.TreeView();
            this.StatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.lblStatus = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnLogout = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.statusContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.awayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.setStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            chatAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLogout)).BeginInit();
            this.statusContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            chatAppToolStripMenuItem.Click += new System.EventHandler(this.chatAppToolStripMenuItem_Click);
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
            this.mainMenuStrip.Size = new System.Drawing.Size(330, 24);
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
            this.sortByGroupToolStripMenuItem,
            this.toolStripMenuItem2,
            this.menu_showOnlineContacts});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // startAToolStripMenuItem
            // 
            this.startAToolStripMenuItem.Name = "startAToolStripMenuItem";
            this.startAToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.startAToolStripMenuItem.Text = "Start a chat";
            this.startAToolStripMenuItem.Click += new System.EventHandler(this.startAToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(214, 6);
            // 
            // sortByNameToolStripMenuItem
            // 
            this.sortByNameToolStripMenuItem.Name = "sortByNameToolStripMenuItem";
            this.sortByNameToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.sortByNameToolStripMenuItem.Text = "Sort by name";
            this.sortByNameToolStripMenuItem.Click += new System.EventHandler(this.sortByNameToolStripMenuItem_Click);
            // 
            // sortByGroupToolStripMenuItem
            // 
            this.sortByGroupToolStripMenuItem.Name = "sortByGroupToolStripMenuItem";
            this.sortByGroupToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.sortByGroupToolStripMenuItem.Text = "Sort by group";
            this.sortByGroupToolStripMenuItem.Click += new System.EventHandler(this.sortByGroupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(214, 6);
            // 
            // menu_showOnlineContacts
            // 
            this.menu_showOnlineContacts.CheckOnClick = true;
            this.menu_showOnlineContacts.Name = "menu_showOnlineContacts";
            this.menu_showOnlineContacts.Size = new System.Drawing.Size(217, 22);
            this.menu_showOnlineContacts.Text = "Show online contacts only";
            this.menu_showOnlineContacts.Click += new System.EventHandler(this.menu_showOnlineContacts_Click);
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lblWelcome);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Controls.Add(this.lblStatus);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.BtnLogout);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.tbSearch);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 24);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(330, 604);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.lblWelcome.Location = new System.Drawing.Point(67, 6);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(89, 27);
            this.lblWelcome.TabIndex = 20;
            this.lblWelcome.Values.Text = "Welcome";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.tvContacts);
            this.kryptonPanel2.Location = new System.Drawing.Point(13, 57);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderPrimary;
            this.kryptonPanel2.Size = new System.Drawing.Size(304, 499);
            this.kryptonPanel2.TabIndex = 17;
            // 
            // tvContacts
            // 
            this.tvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContacts.ImageIndex = 3;
            this.tvContacts.ImageList = this.StatusImageList;
            this.tvContacts.Location = new System.Drawing.Point(0, 0);
            this.tvContacts.Name = "tvContacts";
            this.tvContacts.SelectedImageIndex = 3;
            this.tvContacts.Size = new System.Drawing.Size(304, 499);
            this.tvContacts.TabIndex = 0;
            this.tvContacts.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvContacts_NodeMouseDoubleClick);
            // 
            // StatusImageList
            // 
            this.StatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImageList.ImageStream")));
            this.StatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImageList.Images.SetKeyName(0, "status_online.png");
            this.StatusImageList.Images.SetKeyName(1, "status_away.png");
            this.StatusImageList.Images.SetKeyName(2, "status_busy.png");
            this.StatusImageList.Images.SetKeyName(3, "status_offline.png");
            this.StatusImageList.Images.SetKeyName(4, "group.png");
            // 
            // lblStatus
            // 
            this.lblStatus.ContextMenuStrip = this.statusContextMenuStrip;
            this.lblStatus.Location = new System.Drawing.Point(67, 32);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 19);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Values.Text = "Online";
            this.lblStatus.LinkClicked += new System.EventHandler(this.lblStatus_LinkClicked);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(8, 68);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(87, 19);
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "My Contact List";
            // 
            // BtnLogout
            // 
            this.BtnLogout.Location = new System.Drawing.Point(235, 4);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.BtnLogout.Size = new System.Drawing.Size(84, 29);
            this.BtnLogout.TabIndex = 14;
            this.BtnLogout.Values.Text = "Logout";
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(13, 562);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(304, 33);
            this.tbSearch.TabIndex = 8;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
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
            this.awayMenuItem.Text = "Away";
            // 
            // onlineMenuItem
            // 
            this.onlineMenuItem.Image = global::ChatApp.Properties.Resources.status_online;
            this.onlineMenuItem.Name = "onlineMenuItem";
            this.onlineMenuItem.Size = new System.Drawing.Size(117, 22);
            this.onlineMenuItem.Text = "Online";
            // 
            // busyMenuItem
            // 
            this.busyMenuItem.Image = global::ChatApp.Properties.Resources.status_busy;
            this.busyMenuItem.Name = "busyMenuItem";
            this.busyMenuItem.Size = new System.Drawing.Size(117, 22);
            this.busyMenuItem.Text = "Busy";
            // 
            // offlineMenuItem
            // 
            this.offlineMenuItem.Image = global::ChatApp.Properties.Resources.status_offline;
            this.offlineMenuItem.Name = "offlineMenuItem";
            this.offlineMenuItem.Size = new System.Drawing.Size(117, 22);
            this.offlineMenuItem.Text = "Offline";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::ChatApp.Properties.Resources.user48;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(13, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // setStatusMenuItem
            // 
            this.setStatusMenuItem.DropDown = this.statusContextMenuStrip;
            this.setStatusMenuItem.Name = "setStatusMenuItem";
            this.setStatusMenuItem.Size = new System.Drawing.Size(217, 22);
            this.setStatusMenuItem.Text = "Set Online Status";
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
            this.ClientSize = new System.Drawing.Size(330, 628);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = global::ChatApp.Properties.Settings.Default.AppName;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLogout)).EndInit();
            this.statusContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem startAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_showOnlineContacts;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnLogout;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
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
    }
}

