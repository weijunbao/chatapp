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
            this.lblContacttName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblNewGroup = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbContactName = new System.Windows.Forms.TextBox();
            this.tbNewGname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblContacttName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNewGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tbNewGname);
            this.kryptonPanel1.Controls.Add(this.tbContactName);
            this.kryptonPanel1.Controls.Add(this.btnOk);
            this.kryptonPanel1.Controls.Add(this.lblNewGroup);
            this.kryptonPanel1.Controls.Add(this.lblContacttName);
            this.kryptonPanel1.Location = new System.Drawing.Point(-2, -1);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(356, 154);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lblContacttName
            // 
            this.lblContacttName.Location = new System.Drawing.Point(33, 28);
            this.lblContacttName.Name = "lblContacttName";
            this.lblContacttName.Size = new System.Drawing.Size(88, 19);
            this.lblContacttName.TabIndex = 0;
            this.lblContacttName.Values.Text = "Contact tName:";
            this.lblContacttName.Paint += new System.Windows.Forms.PaintEventHandler(this.lblContacttName_Paint);
            // 
            // lblNewGroup
            // 
            this.lblNewGroup.Location = new System.Drawing.Point(39, 81);
            this.lblNewGroup.Name = "lblNewGroup";
            this.lblNewGroup.Size = new System.Drawing.Size(103, 19);
            this.lblNewGroup.TabIndex = 1;
            this.lblNewGroup.Values.Text = "New Group Name:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(256, 114);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(65, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.Values.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbContactName
            // 
            this.tbContactName.Location = new System.Drawing.Point(148, 27);
            this.tbContactName.Name = "tbContactName";
            this.tbContactName.Size = new System.Drawing.Size(144, 20);
            this.tbContactName.TabIndex = 0;
            // 
            // tbNewGname
            // 
            this.tbNewGname.Location = new System.Drawing.Point(148, 81);
            this.tbNewGname.Name = "tbNewGname";
            this.tbNewGname.Size = new System.Drawing.Size(144, 20);
            this.tbNewGname.TabIndex = 1;
            // 
            // EditContact
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 150);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Contact";
            this.Load += new System.EventHandler(this.EditContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblContacttName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNewGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNewGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblContacttName;
        private System.Windows.Forms.TextBox tbNewGname;
        private System.Windows.Forms.TextBox tbContactName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
    }
}