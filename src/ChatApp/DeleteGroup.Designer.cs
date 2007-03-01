namespace ChatApp
{
    partial class DeleteGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteGroup));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblGroupName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbGname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tbGname);
            this.kryptonPanel1.Controls.Add(this.btnOk);
            this.kryptonPanel1.Controls.Add(this.lblGroupName);
            this.kryptonPanel1.Location = new System.Drawing.Point(-2, -1);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(298, 101);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lblGroupName
            // 
            this.lblGroupName.Location = new System.Drawing.Point(14, 27);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(77, 19);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Values.Text = "Group Name:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(217, 62);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(53, 25);
            this.btnOk.TabIndex = 1;
            this.btnOk.Values.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbGname
            // 
            this.tbGname.Location = new System.Drawing.Point(114, 26);
            this.tbGname.Name = "tbGname";
            this.tbGname.Size = new System.Drawing.Size(132, 20);
            this.tbGname.TabIndex = 0;
            // 
            // DeleteGroup
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 98);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Group";
            this.WindowActive = true;
            this.Load += new System.EventHandler(this.DeleteGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TextBox tbGname;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblGroupName;
    }
}