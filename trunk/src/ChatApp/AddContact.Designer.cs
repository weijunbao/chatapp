namespace ChatApp
{
    partial class AddContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddContact));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.lblserverName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblUserName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblserverName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tbServerName);
            this.kryptonPanel1.Controls.Add(this.lblserverName);
            this.kryptonPanel1.Controls.Add(this.tbGroupName);
            this.kryptonPanel1.Controls.Add(this.lblGroupName);
            this.kryptonPanel1.Controls.Add(this.tbUserName);
            this.kryptonPanel1.Controls.Add(this.btnOk);
            this.kryptonPanel1.Controls.Add(this.lblUserName);
            this.kryptonPanel1.Location = new System.Drawing.Point(-4, -21);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(378, 215);
            this.kryptonPanel1.TabIndex = 0;
            this.kryptonPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel1_Paint);
            // 
            // tbServerName
            // 
            this.tbServerName.Location = new System.Drawing.Point(115, 96);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(170, 20);
            this.tbServerName.TabIndex = 1;
            // 
            // lblserverName
            // 
            this.lblserverName.Location = new System.Drawing.Point(26, 97);
            this.lblserverName.Name = "lblserverName";
            this.lblserverName.Size = new System.Drawing.Size(77, 19);
            this.lblserverName.TabIndex = 4;
            this.lblserverName.Values.Text = "Server Name:";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(115, 140);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(170, 20);
            this.tbGroupName.TabIndex = 2;
            // 
            // lblGroupName
            // 
            this.lblGroupName.LinkBehavior = ComponentFactory.Krypton.Toolkit.KryptonLinkBehavior.NeverUnderline;
            this.lblGroupName.Location = new System.Drawing.Point(26, 140);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(77, 19);
            this.lblGroupName.TabIndex = 3;
            this.lblGroupName.Values.Text = "Group Name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(115, 54);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(170, 20);
            this.tbUserName.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(290, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(58, 26);
            this.btnOk.TabIndex = 3;
            this.btnOk.Values.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(26, 55);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 19);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Values.Text = "UserName:";
            // 
            // AddContact
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 193);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Contact";
            this.Load += new System.EventHandler(this.AddContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblserverName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblGroupName;
        private System.Windows.Forms.TextBox tbUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
        private System.Windows.Forms.TextBox tbGroupName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblserverName;
        private System.Windows.Forms.TextBox tbServerName;
    }
}