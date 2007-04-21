namespace ChatApp
{
    partial class EditContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditContact));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblContacttName = new System.Windows.Forms.Label();
            this.tbnewGpName = new System.Windows.Forms.TextBox();
            this.lblNewGroupName = new System.Windows.Forms.Label();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbContactname = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cbContactname);
            this.kryptonPanel1.Controls.Add(this.lblContacttName);
            this.kryptonPanel1.Controls.Add(this.tbnewGpName);
            this.kryptonPanel1.Controls.Add(this.lblNewGroupName);
            this.kryptonPanel1.Controls.Add(this.btnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(292, 144);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lblContacttName
            // 
            this.lblContacttName.AutoSize = true;
            this.lblContacttName.BackColor = System.Drawing.Color.Transparent;
            this.lblContacttName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblContacttName.Location = new System.Drawing.Point(12, 10);
            this.lblContacttName.Name = "lblContacttName";
            this.lblContacttName.Size = new System.Drawing.Size(101, 14);
            this.lblContacttName.TabIndex = 0;
            this.lblContacttName.Text = "Contact Name:";
            // 
            // tbnewGpName
            // 
            this.tbnewGpName.Location = new System.Drawing.Point(15, 80);
            this.tbnewGpName.Name = "tbnewGpName";
            this.tbnewGpName.Size = new System.Drawing.Size(270, 20);
            this.tbnewGpName.TabIndex = 3;
            // 
            // lblNewGroupName
            // 
            this.lblNewGroupName.AutoSize = true;
            this.lblNewGroupName.BackColor = System.Drawing.Color.Transparent;
            this.lblNewGroupName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblNewGroupName.Location = new System.Drawing.Point(12, 64);
            this.lblNewGroupName.Name = "lblNewGroupName";
            this.lblNewGroupName.Size = new System.Drawing.Size(122, 14);
            this.lblNewGroupName.TabIndex = 2;
            this.lblNewGroupName.Text = "New Group Name:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(210, 106);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 4;
            this.btnOk.Values.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbContactname
            // 
            this.cbContactname.FormattingEnabled = true;
            this.cbContactname.Location = new System.Drawing.Point(15, 27);
            this.cbContactname.Name = "cbContactname";
            this.cbContactname.Size = new System.Drawing.Size(270, 21);
            this.cbContactname.TabIndex = 5;
            // 
            // EditContact
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 144);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Contact";
            this.WindowActive = true;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TextBox tbnewGpName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
        private System.Windows.Forms.Label lblContacttName;
        private System.Windows.Forms.Label lblNewGroupName;
        private System.Windows.Forms.ComboBox cbContactname;
    }
}