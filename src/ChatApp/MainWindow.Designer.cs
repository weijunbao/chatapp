#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.awayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.rootPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblWelcome = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblStatus = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.BtnLogout = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.lvContacts = new System.Windows.Forms.ListView();
            this.columnUserName = new System.Windows.Forms.ColumnHeader();
            this.columnStatus = new System.Windows.Forms.ColumnHeader();
            this.StatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            chatAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.contactsContextMenuStrip.SuspendLayout();
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
            this.myProfileToolStripMenuItem.Enabled = false;
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
            this.preferenceToolStripMenuItem.Click += new System.EventHandler(this.preferenceToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.contactsToolStripMenuItem,
            this.actionsToolStripMenuItem,
            chatAppToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(298, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.DropDown = this.contactsContextMenuStrip;
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.contactsToolStripMenuItem.Text = "&Contacts";
            // 
            // contactsContextMenuStrip
            // 
            this.contactsContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.contactsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.deleteContactToolStripMenuItem,
            this.toolStripSeparator2,
            this.editGroupToolStripMenuItem,
            this.deleteGroupToolStripMenuItem});
            this.contactsContextMenuStrip.Name = "contactsContextMenuStrip";
            this.contactsContextMenuStrip.OwnerItem = this.contactsToolStripMenuItem;
            this.contactsContextMenuStrip.Size = new System.Drawing.Size(159, 120);
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.AddContactMenuItem_Click);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editContactToolStripMenuItem.Text = "Edit Contact";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.EditContactMenuItem_Click);
            // 
            // deleteContactToolStripMenuItem
            // 
            this.deleteContactToolStripMenuItem.Name = "deleteContactToolStripMenuItem";
            this.deleteContactToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteContactToolStripMenuItem.Text = "Delete Contact";
            this.deleteContactToolStripMenuItem.Click += new System.EventHandler(this.DeleteContactMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editGroupToolStripMenuItem.Text = "Rename Group";
            this.editGroupToolStripMenuItem.Click += new System.EventHandler(this.EditGroupMenuItem_Click);
            // 
            // deleteGroupToolStripMenuItem
            // 
            this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteGroupToolStripMenuItem.Text = "Delete Group";
            this.deleteGroupToolStripMenuItem.Click += new System.EventHandler(this.DeleteGroupMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetStatusMenuItem,
            this.StartChatToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // SetStatusMenuItem
            // 
            this.SetStatusMenuItem.DropDown = this.statusContextMenuStrip;
            this.SetStatusMenuItem.Name = "SetStatusMenuItem";
            this.SetStatusMenuItem.Size = new System.Drawing.Size(170, 22);
            this.SetStatusMenuItem.Text = "Set Online Status";
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
            this.statusContextMenuStrip.OwnerItem = this.SetStatusMenuItem;
            this.statusContextMenuStrip.Size = new System.Drawing.Size(118, 92);
            // 
            // awayMenuItem
            // 
            this.awayMenuItem.Image = global::ChatApp.Properties.Resources.status_away;
            this.awayMenuItem.Name = "awayMenuItem";
            this.awayMenuItem.Size = new System.Drawing.Size(117, 22);
            this.awayMenuItem.Tag = ChatApp.LoginState.Away;
            this.awayMenuItem.Text = "Away";
            this.awayMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // onlineMenuItem
            // 
            this.onlineMenuItem.Image = global::ChatApp.Properties.Resources.status_online;
            this.onlineMenuItem.Name = "onlineMenuItem";
            this.onlineMenuItem.Size = new System.Drawing.Size(117, 22);
            this.onlineMenuItem.Tag = ChatApp.LoginState.Online;
            this.onlineMenuItem.Text = "Online";
            this.onlineMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // busyMenuItem
            // 
            this.busyMenuItem.Image = global::ChatApp.Properties.Resources.status_busy;
            this.busyMenuItem.Name = "busyMenuItem";
            this.busyMenuItem.Size = new System.Drawing.Size(117, 22);
            this.busyMenuItem.Tag = ChatApp.LoginState.Busy;
            this.busyMenuItem.Text = "Busy";
            this.busyMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // offlineMenuItem
            // 
            this.offlineMenuItem.Image = global::ChatApp.Properties.Resources.status_offline;
            this.offlineMenuItem.Name = "offlineMenuItem";
            this.offlineMenuItem.Size = new System.Drawing.Size(117, 22);
            this.offlineMenuItem.Tag = ChatApp.LoginState.Offline;
            this.offlineMenuItem.Text = "Offline";
            this.offlineMenuItem.Click += new System.EventHandler(this.StatusMenu_Click);
            // 
            // StartChatToolStripMenuItem
            // 
            this.StartChatToolStripMenuItem.Name = "StartChatToolStripMenuItem";
            this.StartChatToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.StartChatToolStripMenuItem.Text = "Start a Chat";
            this.StartChatToolStripMenuItem.Click += new System.EventHandler(this.StartChatMenuItem_Click);
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
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.rootPanel.Size = new System.Drawing.Size(298, 413);
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
            this.BtnLogout.Location = new System.Drawing.Point(220, 6);
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
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            this.splitContainer.Panel1.Controls.Add(this.lvContacts);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbSearch);
            this.splitContainer.Size = new System.Drawing.Size(280, 348);
            this.splitContainer.SplitterDistance = 321;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 17;
            // 
            // lvContacts
            // 
            this.lvContacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUserName,
            this.columnStatus});
            this.lvContacts.ContextMenuStrip = this.contactsContextMenuStrip;
            this.lvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvContacts.FullRowSelect = true;
            this.lvContacts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvContacts.LargeImageList = this.StatusImageList;
            this.lvContacts.Location = new System.Drawing.Point(0, 0);
            this.lvContacts.MultiSelect = false;
            this.lvContacts.Name = "lvContacts";
            this.lvContacts.OwnerDraw = true;
            this.lvContacts.ShowItemToolTips = true;
            this.lvContacts.Size = new System.Drawing.Size(280, 321);
            this.lvContacts.SmallImageList = this.StatusImageList;
            this.lvContacts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvContacts.TabIndex = 1;
            this.lvContacts.TileSize = new System.Drawing.Size(280, 36);
            this.lvContacts.UseCompatibleStateImageBehavior = false;
            this.lvContacts.View = System.Windows.Forms.View.Tile;
            this.lvContacts.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvContacts_DrawItem);
            this.lvContacts.DoubleClick += new System.EventHandler(this.lvContacts_DoubleClick);
            this.lvContacts.Resize += new System.EventHandler(this.lvContacts_Resize);
            // 
            // columnUserName
            // 
            this.columnUserName.Text = "User Name";
            this.columnUserName.Width = 215;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            // 
            // StatusImageList
            // 
            this.StatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImageList.ImageStream")));
            this.StatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImageList.Images.SetKeyName(0, "Online");
            this.StatusImageList.Images.SetKeyName(1, "Away");
            this.StatusImageList.Images.SetKeyName(2, "Chat");
            this.StatusImageList.Images.SetKeyName(3, "Busy");
            this.StatusImageList.Images.SetKeyName(4, "ExtendedAway");
            this.StatusImageList.Images.SetKeyName(5, "Offline");
            this.StatusImageList.Images.SetKeyName(6, "group.png");
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(-1, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(280, 20);
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
            this.ClientSize = new System.Drawing.Size(298, 437);
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
            this.contactsContextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel rootPanel;
        private System.Windows.Forms.PictureBox userPictureBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnLogout;
        // The tree view is made public so that AppController can access
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWelcome;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        public System.Windows.Forms.ImageList StatusImageList;
        public System.String currentUser;
        private System.Windows.Forms.ContextMenuStrip statusContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem awayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetStatusMenuItem;
        private System.Windows.Forms.TextBox tbSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainer;
        private System.Windows.Forms.ContextMenuStrip contactsContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ListView lvContacts;
        private System.Windows.Forms.ColumnHeader columnUserName;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

