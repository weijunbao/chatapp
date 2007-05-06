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
            this.btok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btcancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbChnotify = new System.Windows.Forms.CheckBox();
            this.cbChplay = new System.Windows.Forms.CheckBox();
            this.lbfndonline = new System.Windows.Forms.Label();
            this.lbincomchat = new System.Windows.Forms.Label();
            this.cbOnotify = new System.Windows.Forms.CheckBox();
            this.cbOsound = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btcancel)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btok);
            this.kryptonPanel1.Controls.Add(this.btcancel);
            this.kryptonPanel1.Controls.Add(this.cbChnotify);
            this.kryptonPanel1.Controls.Add(this.cbChplay);
            this.kryptonPanel1.Controls.Add(this.lbfndonline);
            this.kryptonPanel1.Controls.Add(this.lbincomchat);
            this.kryptonPanel1.Controls.Add(this.cbOnotify);
            this.kryptonPanel1.Controls.Add(this.cbOsound);
            this.kryptonPanel1.Location = new System.Drawing.Point(-2, 1);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(272, 260);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(110, 219);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(75, 25);
            this.btok.TabIndex = 9;
            this.btok.Values.Text = "OK";
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // btcancel
            // 
            this.btcancel.Location = new System.Drawing.Point(191, 219);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(75, 25);
            this.btcancel.TabIndex = 8;
            this.btcancel.Values.Text = "Cancel";
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // cbChnotify
            // 
            this.cbChnotify.AutoSize = true;
            this.cbChnotify.BackColor = System.Drawing.Color.Transparent;
            this.cbChnotify.Location = new System.Drawing.Point(90, 154);
            this.cbChnotify.Name = "cbChnotify";
            this.cbChnotify.Size = new System.Drawing.Size(109, 17);
            this.cbChnotify.TabIndex = 5;
            this.cbChnotify.Text = "Show Notification";
            this.cbChnotify.UseVisualStyleBackColor = false;
            this.cbChnotify.CheckedChanged += new System.EventHandler(this.cbChnotify_CheckedChanged);
            // 
            // cbChplay
            // 
            this.cbChplay.AutoSize = true;
            this.cbChplay.BackColor = System.Drawing.Color.Transparent;
            this.cbChplay.Checked = true;
            this.cbChplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbChplay.Location = new System.Drawing.Point(90, 131);
            this.cbChplay.Name = "cbChplay";
            this.cbChplay.Size = new System.Drawing.Size(80, 17);
            this.cbChplay.TabIndex = 4;
            this.cbChplay.Text = "Play Sound";
            this.cbChplay.UseVisualStyleBackColor = false;
            this.cbChplay.CheckedChanged += new System.EventHandler(this.cbChplay_CheckedChanged);
            // 
            // lbfndonline
            // 
            this.lbfndonline.AutoSize = true;
            this.lbfndonline.BackColor = System.Drawing.Color.Transparent;
            this.lbfndonline.Location = new System.Drawing.Point(20, 24);
            this.lbfndonline.Name = "lbfndonline";
            this.lbfndonline.Size = new System.Drawing.Size(69, 13);
            this.lbfndonline.TabIndex = 3;
            this.lbfndonline.Text = "Friend Online";
            // 
            // lbincomchat
            // 
            this.lbincomchat.AutoSize = true;
            this.lbincomchat.BackColor = System.Drawing.Color.Transparent;
            this.lbincomchat.Location = new System.Drawing.Point(20, 105);
            this.lbincomchat.Name = "lbincomchat";
            this.lbincomchat.Size = new System.Drawing.Size(75, 13);
            this.lbincomchat.TabIndex = 2;
            this.lbincomchat.Text = "Incoming Chat";
            // 
            // cbOnotify
            // 
            this.cbOnotify.AutoSize = true;
            this.cbOnotify.BackColor = System.Drawing.Color.Transparent;
            this.cbOnotify.Location = new System.Drawing.Point(90, 67);
            this.cbOnotify.Name = "cbOnotify";
            this.cbOnotify.Size = new System.Drawing.Size(109, 17);
            this.cbOnotify.TabIndex = 1;
            this.cbOnotify.Text = "Show Notification";
            this.cbOnotify.UseVisualStyleBackColor = false;
            this.cbOnotify.CheckedChanged += new System.EventHandler(this.cbShnotify_CheckedChanged);
            // 
            // cbOsound
            // 
            this.cbOsound.AutoSize = true;
            this.cbOsound.BackColor = System.Drawing.Color.Transparent;
            this.cbOsound.Checked = true;
            this.cbOsound.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbOsound.Location = new System.Drawing.Point(90, 44);
            this.cbOsound.Name = "cbOsound";
            this.cbOsound.Size = new System.Drawing.Size(80, 17);
            this.cbOsound.TabIndex = 0;
            this.cbOsound.Text = "Play Sound";
            this.cbOsound.UseVisualStyleBackColor = false;
            this.cbOsound.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // preference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 260);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "preference";
            this.Text = "preference";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
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
    }
}