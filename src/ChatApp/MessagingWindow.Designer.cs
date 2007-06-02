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
    partial class MessagingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagingWindow));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.msgHistoryWindow = new System.Windows.Forms.WebBrowser();
            this.btnSend = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbMessages = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.MinimumSize = new System.Drawing.Size(200, 200);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.msgHistoryWindow);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnSend);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.tbMessages);
            this.kryptonSplitContainer1.Panel2MinSize = 50;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(492, 359);
            this.kryptonSplitContainer1.SplitterDistance = 300;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // msgHistoryWindow
            // 
            this.msgHistoryWindow.AllowWebBrowserDrop = false;
            this.msgHistoryWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgHistoryWindow.IsWebBrowserContextMenuEnabled = false;
            this.msgHistoryWindow.Location = new System.Drawing.Point(0, 0);
            this.msgHistoryWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this.msgHistoryWindow.Name = "msgHistoryWindow";
            this.msgHistoryWindow.ScriptErrorsSuppressed = true;
            this.msgHistoryWindow.Size = new System.Drawing.Size(492, 300);
            this.msgHistoryWindow.TabIndex = 0;
            this.msgHistoryWindow.TabStop = false;
            this.msgHistoryWindow.WebBrowserShortcutsEnabled = false;
            this.msgHistoryWindow.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.OnMsgHistoryWindowDocumentCompleted);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(423, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 54);
            this.btnSend.TabIndex = 1;
            this.btnSend.Values.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.OnButtonSendClick);
            // 
            // tbMessages
            // 
            this.tbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessages.Location = new System.Drawing.Point(3, 0);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Size = new System.Drawing.Size(414, 54);
            this.tbMessages.TabIndex = 0;
            // 
            // MessagingWindow
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(492, 359);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MessagingWindow";
            this.Text = "Messaging Window";
            this.WindowActive = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnMessagingWindowFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSend;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.WebBrowser msgHistoryWindow;
    }
}