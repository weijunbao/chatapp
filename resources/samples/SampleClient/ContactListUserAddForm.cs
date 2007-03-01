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

using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core;

namespace Coversant.SoapBox.SampleClient
{
	/// <summary>
	/// Summary description for ContactListUserAddForm.
	/// </summary>
	public class ContactListUserAddForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox JabberIDTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button CancelBtn;
		internal System.Windows.Forms.Button OKButton;
	
		public ContactListUserAddForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Rectangle screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
			this.Location = new Point(Convert.ToInt32((screen.Width - this.Width) / 2),
				Convert.ToInt32((screen.Height - this.Height) / 2));
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactListUserAddForm));
            this.Label4 = new System.Windows.Forms.Label();
            this.JabberIDTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label4.Location = new System.Drawing.Point(197, 10);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(133, 14);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Ex: user@jabber.org";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // JabberIDTextBox
            // 
            this.JabberIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.JabberIDTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.JabberIDTextBox.Location = new System.Drawing.Point(7, 24);
            this.JabberIDTextBox.Name = "JabberIDTextBox";
            this.JabberIDTextBox.Size = new System.Drawing.Size(323, 22);
            this.JabberIDTextBox.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Verdana", 9F);
            this.Label1.Location = new System.Drawing.Point(10, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 21);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "JabberID";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.CancelBtn.Location = new System.Drawing.Point(8, 72);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(83, 24);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OKButton.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.OKButton.Location = new System.Drawing.Point(240, 72);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(83, 24);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ContactListUserAddForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(336, 102);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.JabberIDTextBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContactListUserAddForm";
            this.Text = "Add Contact";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void OKButton_Click(object sender, System.EventArgs e)
		{
			//this.DialogResult = DialogResult.OK;
			//this.Close();
			try
			{
				if (JabberIDTextBox.Text.Trim().Length == 0)
				{
					MessageBox.Show("You must enter a User ID for your Contact");
					return;
				}
				
				try
				{
					JabberID J = new JabberID(JabberIDTextBox.Text.Trim());
					if (J.UserName.Length == 0 ||
						J.Server.Length == 0)
					{
						MessageBox.Show("The User ID you entered is not valid. Please enter a valid User ID", "Invalid UserID");
						return;
					}
				}
				catch 
				{
					MessageBox.Show("The User ID you entered is not valid. Please enter a valid User ID", "Invalid UserID");
					return;
				}
				
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("The following exception has occurred:\n\n{0}.", ex));
			}
		}

		private void CancelBtn_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
