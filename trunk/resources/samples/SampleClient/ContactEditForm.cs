#region License Information, Copyright (c) 2006 Coversant
//Copyright (c) 2006 Coversant, Inc.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of 
//this software and associated documentation files (the "Software"), to deal in 
//the Software without restriction, including without limitation the rights to 
//use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of 
//the Software, and to permit persons to whom the Software is furnished to do so, 
//subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all 
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
//FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
//IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
//CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Coversant.SoapBox.SampleClient
{
    /// <summary>
    /// Summary description for ContactEditForm.
    /// </summary>
    public class ContactEditForm : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.Label Label4;
        public System.Windows.Forms.TextBox JabberIDTextBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button CancelBtn;
        internal System.Windows.Forms.Button OKButton;
        internal System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox FriendlyNameTextBox;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        public System.Windows.Forms.TextBox GroupNameTextBox;
        internal System.Windows.Forms.Label Label6;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ContactEditForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.Label4 = new System.Windows.Forms.Label();
            this.JabberIDTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.FriendlyNameTextBox = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupNameTextBox = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label4.Location = new System.Drawing.Point(280, 24);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(155, 13);
            this.Label4.TabIndex = 18;
            this.Label4.Text = "Ex: user@jabber.org";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // JabberIDTextBox
            // 
            this.JabberIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.JabberIDTextBox.Enabled = false;
            this.JabberIDTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.JabberIDTextBox.Location = new System.Drawing.Point(16, 40);
            this.JabberIDTextBox.Name = "JabberIDTextBox";
            this.JabberIDTextBox.Size = new System.Drawing.Size(424, 22);
            this.JabberIDTextBox.TabIndex = 16;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Verdana", 9F);
            this.Label1.Location = new System.Drawing.Point(16, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 19);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "JabberID";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.CancelBtn.Location = new System.Drawing.Point(240, 208);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(88, 22);
            this.CancelBtn.TabIndex = 15;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.OKButton.Location = new System.Drawing.Point(352, 208);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(88, 22);
            this.OKButton.TabIndex = 14;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = false;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Verdana", 9F);
            this.Label2.Location = new System.Drawing.Point(16, 80);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 19);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "Friendly Name";
            // 
            // FriendlyNameTextBox
            // 
            this.FriendlyNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FriendlyNameTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.FriendlyNameTextBox.Location = new System.Drawing.Point(16, 104);
            this.FriendlyNameTextBox.Name = "FriendlyNameTextBox";
            this.FriendlyNameTextBox.Size = new System.Drawing.Size(424, 22);
            this.FriendlyNameTextBox.TabIndex = 12;
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label3.Location = new System.Drawing.Point(280, 88);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(155, 13);
            this.Label3.TabIndex = 17;
            this.Label3.Text = "Ex: John Doe";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Verdana", 9F);
            this.Label5.Location = new System.Drawing.Point(16, 144);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(112, 19);
            this.Label5.TabIndex = 20;
            this.Label5.Text = "Group";
            // 
            // GroupNameTextBox
            // 
            this.GroupNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupNameTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.GroupNameTextBox.Location = new System.Drawing.Point(16, 168);
            this.GroupNameTextBox.Name = "GroupNameTextBox";
            this.GroupNameTextBox.Size = new System.Drawing.Size(424, 22);
            this.GroupNameTextBox.TabIndex = 13;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label6.Location = new System.Drawing.Point(280, 152);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(155, 13);
            this.Label6.TabIndex = 19;
            this.Label6.Text = "Ex: John Doe";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ContactEditForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(456, 246);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.JabberIDTextBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.FriendlyNameTextBox);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.GroupNameTextBox);
            this.Controls.Add(this.Label6);
            this.Name = "ContactEditForm";
            this.Text = "ContactEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
