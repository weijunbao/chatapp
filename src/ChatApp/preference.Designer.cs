namespace ChatApp
{
    partial class preference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(preference));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.cbOnotify = new System.Windows.Forms.CheckBox();
            this.lbincomchat = new System.Windows.Forms.Label();
            this.cbChnotify = new System.Windows.Forms.CheckBox();
            this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.cbChplay = new System.Windows.Forms.CheckBox();
            this.cbOsound = new System.Windows.Forms.CheckBox();
            this.lbfndonline = new System.Windows.Forms.Label();
            this.btok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btcancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).BeginInit();
            this.kryptonGroup2.Panel.SuspendLayout();
            this.kryptonGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btcancel)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroup2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroup1);
            this.kryptonPanel1.Controls.Add(this.btok);
            this.kryptonPanel1.Controls.Add(this.btcancel);
            this.kryptonPanel1.Location = new System.Drawing.Point(-2, 1);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(272, 260);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonGroup2
            // 
            this.kryptonGroup2.Location = new System.Drawing.Point(9, 113);
            this.kryptonGroup2.Name = "kryptonGroup2";
            // 
            // kryptonGroup2.Panel
            // 
            this.kryptonGroup2.Panel.Controls.Add(this.cbOnotify);
            this.kryptonGroup2.Panel.Controls.Add(this.lbincomchat);
            this.kryptonGroup2.Panel.Controls.Add(this.cbChnotify);
            this.kryptonGroup2.Size = new System.Drawing.Size(257, 83);
            this.kryptonGroup2.TabIndex = 11;
            // 
            // cbOnotify
            // 
            this.cbOnotify.AutoSize = true;
            this.cbOnotify.BackColor = System.Drawing.Color.Transparent;
            this.cbOnotify.Location = new System.Drawing.Point(26, 26);
            this.cbOnotify.Name = "cbOnotify";
            this.cbOnotify.Size = new System.Drawing.Size(155, 17);
            this.cbOnotify.TabIndex = 1;
            this.cbOnotify.Text = "when a friend comes online";
            this.cbOnotify.UseVisualStyleBackColor = false;
            // 
            // lbincomchat
            // 
            this.lbincomchat.AutoSize = true;
            this.lbincomchat.BackColor = System.Drawing.Color.Transparent;
            this.lbincomchat.Location = new System.Drawing.Point(8, 6);
            this.lbincomchat.Name = "lbincomchat";
            this.lbincomchat.Size = new System.Drawing.Size(90, 13);
            this.lbincomchat.TabIndex = 2;
            this.lbincomchat.Text = "Show Notification";
            // 
            // cbChnotify
            // 
            this.cbChnotify.AutoSize = true;
            this.cbChnotify.BackColor = System.Drawing.Color.Transparent;
            this.cbChnotify.Location = new System.Drawing.Point(26, 49);
            this.cbChnotify.Name = "cbChnotify";
            this.cbChnotify.Size = new System.Drawing.Size(140, 17);
            this.cbChnotify.TabIndex = 5;
            this.cbChnotify.Text = "when a message arrives";
            this.cbChnotify.UseVisualStyleBackColor = false;
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Location = new System.Drawing.Point(9, 11);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.cbChplay);
            this.kryptonGroup1.Panel.Controls.Add(this.cbOsound);
            this.kryptonGroup1.Panel.Controls.Add(this.lbfndonline);
            this.kryptonGroup1.Size = new System.Drawing.Size(257, 84);
            this.kryptonGroup1.TabIndex = 10;
            // 
            // cbChplay
            // 
            this.cbChplay.AutoSize = true;
            this.cbChplay.BackColor = System.Drawing.Color.Transparent;
            this.cbChplay.Location = new System.Drawing.Point(26, 49);
            this.cbChplay.Name = "cbChplay";
            this.cbChplay.Size = new System.Drawing.Size(140, 17);
            this.cbChplay.TabIndex = 4;
            this.cbChplay.Text = "when a message arrives";
            this.cbChplay.UseVisualStyleBackColor = false;
            // 
            // cbOsound
            // 
            this.cbOsound.AutoSize = true;
            this.cbOsound.BackColor = System.Drawing.Color.Transparent;
            this.cbOsound.Location = new System.Drawing.Point(26, 26);
            this.cbOsound.Name = "cbOsound";
            this.cbOsound.Size = new System.Drawing.Size(155, 17);
            this.cbOsound.TabIndex = 0;
            this.cbOsound.Text = "when a friend comes online";
            this.cbOsound.UseVisualStyleBackColor = false;
            // 
            // lbfndonline
            // 
            this.lbfndonline.AutoSize = true;
            this.lbfndonline.BackColor = System.Drawing.Color.Transparent;
            this.lbfndonline.Location = new System.Drawing.Point(8, 6);
            this.lbfndonline.Name = "lbfndonline";
            this.lbfndonline.Size = new System.Drawing.Size(68, 13);
            this.lbfndonline.TabIndex = 3;
            this.lbfndonline.Text = "Play a sound";
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(110, 202);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(75, 25);
            this.btok.TabIndex = 9;
            this.btok.Values.Text = "OK";
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // btcancel
            // 
            this.btcancel.Location = new System.Drawing.Point(191, 202);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(75, 25);
            this.btcancel.TabIndex = 8;
            this.btcancel.Values.Text = "Cancel";
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // preference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 239);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "preference";
            this.Text = "Preference";
            this.WindowActive = true;
            this.Load += new System.EventHandler(this.preference_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).EndInit();
            this.kryptonGroup2.Panel.ResumeLayout(false);
            this.kryptonGroup2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).EndInit();
            this.kryptonGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            this.kryptonGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btcancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.CheckBox cbOsound;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btok;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btcancel;
        private System.Windows.Forms.CheckBox cbChnotify;
        private System.Windows.Forms.CheckBox cbChplay;
        private System.Windows.Forms.Label lbfndonline;
        private System.Windows.Forms.Label lbincomchat;
        private System.Windows.Forms.CheckBox cbOnotify;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
    }
}