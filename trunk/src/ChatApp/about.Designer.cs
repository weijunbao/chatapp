namespace ChatApp
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.lblAlso = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblLink = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.lblInclude = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblAppName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.betaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLinkLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInclude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAppName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLinkLabel1);
            this.kryptonPanel1.Controls.Add(this.lblAlso);
            this.kryptonPanel1.Controls.Add(this.lblLink);
            this.kryptonPanel1.Controls.Add(this.lblInclude);
            this.kryptonPanel1.Controls.Add(this.lblAppName);
            this.kryptonPanel1.Controls.Add(this.betaLabel);
            this.kryptonPanel1.Controls.Add(this.userPictureBox);
            this.kryptonPanel1.Controls.Add(this.btnOK);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(270, 188);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(12, 121);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(225, 19);
            this.kryptonLinkLabel1.TabIndex = 5;
            this.kryptonLinkLabel1.Values.Text = "http://www.famfamfam.com/lab/icons/silk/";
            this.kryptonLinkLabel1.LinkClicked += new System.EventHandler(this.kryptonLinkLabel1_LinkClicked);
            // 
            // lblAlso
            // 
            this.lblAlso.Location = new System.Drawing.Point(12, 106);
            this.lblAlso.Name = "lblAlso";
            this.lblAlso.Size = new System.Drawing.Size(100, 19);
            this.lblAlso.TabIndex = 4;
            this.lblAlso.Values.Text = "Also images from:";
            // 
            // lblLink
            // 
            this.lblLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLink.Location = new System.Drawing.Point(12, 81);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(170, 19);
            this.lblLink.TabIndex = 3;
            this.lblLink.Values.Text = "http://developers.coversant.net/";
            this.lblLink.LinkClicked += new System.EventHandler(this.lblLink_LinkClicked);
            // 
            // lblInclude
            // 
            this.lblInclude.Location = new System.Drawing.Point(12, 66);
            this.lblInclude.Name = "lblInclude";
            this.lblInclude.Size = new System.Drawing.Size(243, 19);
            this.lblInclude.TabIndex = 2;
            this.lblInclude.Values.Text = "Includes components from Coversant SoapBox";
            // 
            // lblAppName
            // 
            this.lblAppName.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.lblAppName.Location = new System.Drawing.Point(66, 12);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(84, 27);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Values.Text = "ChatApp";
            // 
            // betaLabel
            // 
            this.betaLabel.Location = new System.Drawing.Point(66, 41);
            this.betaLabel.Name = "betaLabel";
            this.betaLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.betaLabel.Size = new System.Drawing.Size(67, 19);
            this.betaLabel.TabIndex = 1;
            this.betaLabel.Values.Text = "1.0.0.1 beta";
            // 
            // userPictureBox
            // 
            this.userPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userPictureBox.ErrorImage = null;
            this.userPictureBox.Image = global::ChatApp.Properties.Resources.user48;
            this.userPictureBox.ImageLocation = "";
            this.userPictureBox.InitialImage = null;
            this.userPictureBox.Location = new System.Drawing.Point(12, 12);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(48, 48);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userPictureBox.TabIndex = 13;
            this.userPictureBox.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(168, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 31);
            this.btnOK.TabIndex = 6;
            this.btnOK.Values.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // About
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(270, 188);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLinkLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInclude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAppName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel betaLabel;
        private System.Windows.Forms.PictureBox userPictureBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAppName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblInclude;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblLink;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAlso;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
    }
}