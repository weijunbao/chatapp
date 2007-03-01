namespace ChatApp
{
    partial class EditGroup
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tbNewGroup = new System.Windows.Forms.TextBox();
            this.tbOldGroup = new System.Windows.Forms.TextBox();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblNewGroup = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblOldGroup = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNewGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOldGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tbNewGroup);
            this.kryptonPanel1.Controls.Add(this.tbOldGroup);
            this.kryptonPanel1.Controls.Add(this.btnOk);
            this.kryptonPanel1.Controls.Add(this.lblNewGroup);
            this.kryptonPanel1.Controls.Add(this.lblOldGroup);
            this.kryptonPanel1.Location = new System.Drawing.Point(-4, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(400, 150);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // tbNewGroup
            // 
            this.tbNewGroup.Location = new System.Drawing.Point(136, 74);
            this.tbNewGroup.Name = "tbNewGroup";
            this.tbNewGroup.Size = new System.Drawing.Size(138, 20);
            this.tbNewGroup.TabIndex = 1;
            // 
            // tbOldGroup
            // 
            this.tbOldGroup.Location = new System.Drawing.Point(136, 32);
            this.tbOldGroup.Name = "tbOldGroup";
            this.tbOldGroup.Size = new System.Drawing.Size(138, 20);
            this.tbOldGroup.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(293, 109);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Values.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblNewGroup
            // 
            this.lblNewGroup.Location = new System.Drawing.Point(11, 74);
            this.lblNewGroup.Name = "lblNewGroup";
            this.lblNewGroup.Size = new System.Drawing.Size(70, 19);
            this.lblNewGroup.TabIndex = 1;
            this.lblNewGroup.Values.Text = "New Group:";
            // 
            // lblOldGroup
            // 
            this.lblOldGroup.Location = new System.Drawing.Point(16, 32);
            this.lblOldGroup.Name = "lblOldGroup";
            this.lblOldGroup.Size = new System.Drawing.Size(65, 19);
            this.lblOldGroup.TabIndex = 0;
            this.lblOldGroup.Values.Text = "Old Group:";
            // 
            // EditGroup
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 146);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "EditGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Group";
            this.Load += new System.EventHandler(this.EditGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNewGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOldGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TextBox tbNewGroup;
        private System.Windows.Forms.TextBox tbOldGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNewGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblOldGroup;
    }
}