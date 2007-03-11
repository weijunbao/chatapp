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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGroup));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblOldGroup = new System.Windows.Forms.Label();
            this.tbOldGroup = new System.Windows.Forms.TextBox();
            this.lblNewGroup = new System.Windows.Forms.Label();
            this.tbNewGroup = new System.Windows.Forms.TextBox();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lblOldGroup);
            this.kryptonPanel1.Controls.Add(this.tbOldGroup);
            this.kryptonPanel1.Controls.Add(this.lblNewGroup);
            this.kryptonPanel1.Controls.Add(this.tbNewGroup);
            this.kryptonPanel1.Controls.Add(this.btnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(292, 144);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lblOldGroup
            // 
            this.lblOldGroup.AutoSize = true;
            this.lblOldGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblOldGroup.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblOldGroup.Location = new System.Drawing.Point(12, 10);
            this.lblOldGroup.Name = "lblOldGroup";
            this.lblOldGroup.Size = new System.Drawing.Size(75, 14);
            this.lblOldGroup.TabIndex = 0;
            this.lblOldGroup.Text = "Old Group:";
            // 
            // tbOldGroup
            // 
            this.tbOldGroup.Location = new System.Drawing.Point(15, 27);
            this.tbOldGroup.Name = "tbOldGroup";
            this.tbOldGroup.Size = new System.Drawing.Size(270, 20);
            this.tbOldGroup.TabIndex = 1;
            // 
            // lblNewGroup
            // 
            this.lblNewGroup.AutoSize = true;
            this.lblNewGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblNewGroup.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblNewGroup.Location = new System.Drawing.Point(12, 64);
            this.lblNewGroup.Name = "lblNewGroup";
            this.lblNewGroup.Size = new System.Drawing.Size(82, 14);
            this.lblNewGroup.TabIndex = 2;
            this.lblNewGroup.Text = "New Group:";
            // 
            // tbNewGroup
            // 
            this.tbNewGroup.Location = new System.Drawing.Point(15, 80);
            this.tbNewGroup.Name = "tbNewGroup";
            this.tbNewGroup.Size = new System.Drawing.Size(270, 20);
            this.tbNewGroup.TabIndex = 3;
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
            // EditGroup
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
            this.Name = "EditGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Group";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TextBox tbNewGroup;
        private System.Windows.Forms.TextBox tbOldGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
        private System.Windows.Forms.Label lblOldGroup;
        private System.Windows.Forms.Label lblNewGroup;
    }
}