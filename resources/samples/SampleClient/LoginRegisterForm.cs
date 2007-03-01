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
using System.Threading;
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.IQ.Register;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ;
using Coversant.SoapBox.Core.IQ.Auth;
using System.Data;

namespace Coversant.SoapBox.SampleClient
{
	/// <summary>
	/// Summary description for LoginRegisterForm.
	/// </summary>
	public class LoginRegisterForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label label9;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label12;
		internal System.Windows.Forms.Label label14;

		//Holds a local copy of the SessionManager used for sending/receiving packets
		private SessionManager _SessionManager;
		private string _baseText;		
		internal System.Windows.Forms.TextBox UserNameTextBox;
		internal System.Windows.Forms.TextBox PasswordTextBox;
		internal System.Windows.Forms.TextBox ResourceTextBox;
		internal System.Windows.Forms.Button LoginButton;
		internal System.Windows.Forms.Button RegisterButton;
		internal System.Windows.Forms.TextBox ServerNameTextBox;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox Language;
		private const string USER_FILE_NAME = "SoapBoxUserSettings.xml";

		//Used for marshalling operations to the main thread
		private delegate void DoGUIWork();
	
		public LoginRegisterForm() : base()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			SetupLanguages();
			_baseText = this.Text;

			Rectangle screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
			this.Location = new Point(Convert.ToInt32((screen.Width - this.Width) / 2),
				Convert.ToInt32((screen.Height - this.Height) / 2));

			if (System.IO.File.Exists(USER_FILE_NAME))
				LoadSettings();
		}

		public class LanguageItem
		{
			public System.Globalization.CultureInfo Culture;

			public LanguageItem(System.Globalization.CultureInfo c)
			{
				Culture = c;
			}

			public override string ToString()
			{
				return Culture.DisplayName;
			}
		}

		private void SetupLanguages()
		{
			//*** This method loads a bunch of languages into the dropdown. These languages aren't
			//	for textual display on the GUI, but rather for the language that gets put
			//  on the XMPP Stream, so that we can attempt to do some translation.

			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("en-us")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("es-es")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("fr-fr")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("ja-jp")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("de-de")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("zh-hk")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("it-it")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("ko-kr")));
			Language.Items.Add(new LanguageItem(new System.Globalization.CultureInfo("ru-ru")));

			Language.SelectedIndex = 0;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginRegisterForm));
            this.Label7 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ResourceTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label7.Location = new System.Drawing.Point(136, 8);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(147, 21);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "Ex: JohnDoe";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LoginButton.Font = new System.Drawing.Font("Verdana", 9F);
            this.LoginButton.Location = new System.Drawing.Point(240, 256);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(50, 28);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerNameTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.ServerNameTextBox.Location = new System.Drawing.Point(8, 224);
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(272, 22);
            this.ServerNameTextBox.TabIndex = 3;
            this.ServerNameTextBox.Text = "soapbox.net";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 9F);
            this.label9.Location = new System.Drawing.Point(8, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Server";            
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Verdana", 9F);
            this.label10.Location = new System.Drawing.Point(7, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 14);
            this.label10.TabIndex = 5;
            this.label10.Text = "Resource";
            // 
            // ResourceTextBox
            // 
            this.ResourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourceTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.ResourceTextBox.Location = new System.Drawing.Point(7, 118);
            this.ResourceTextBox.Name = "ResourceTextBox";
            this.ResourceTextBox.Size = new System.Drawing.Size(273, 22);
            this.ResourceTextBox.TabIndex = 2;
            this.ResourceTextBox.Text = "Desktop";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.PasswordTextBox.Location = new System.Drawing.Point(7, 69);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(273, 22);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Verdana", 9F);
            this.label11.Location = new System.Drawing.Point(7, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 14);
            this.label11.TabIndex = 8;
            this.label11.Text = "Password";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 9F);
            this.label12.Location = new System.Drawing.Point(7, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "User Name";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTextBox.Font = new System.Drawing.Font("Verdana", 9F);
            this.UserNameTextBox.Location = new System.Drawing.Point(7, 21);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(273, 22);
            this.UserNameTextBox.TabIndex = 0;
            this.UserNameTextBox.Text = "SoapBoxUser";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RegisterButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RegisterButton.Font = new System.Drawing.Font("Verdana", 9F);
            this.RegisterButton.Location = new System.Drawing.Point(8, 256);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(140, 28);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Register New User";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(160, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 21);
            this.label14.TabIndex = 11;
            this.label14.Text = "Ex: Work";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F);
            this.label1.Location = new System.Drawing.Point(8, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Language";
            // 
            // Language
            // 
            this.Language.Location = new System.Drawing.Point(8, 176);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(272, 21);
            this.Language.TabIndex = 15;
            // 
            // LoginRegisterForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(296, 294);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.ServerNameTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ResourceTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(304, 304);
            this.Name = "LoginRegisterForm";
            this.Text = "SoapBox Login";
            this.Load += new System.EventHandler(this.LoginRegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//Performs User Registration and informs the user of the results.
		//This process can take a few seconds and is called
		//on a background thread.
		private bool DoRegistration()
		{
			try
			{
				InitializeSessionManager();
				try
				{
					RegisterUser();
					MessageBox.Show(string.Format("User '{0}' registered successfully.\n\nYou will be logged in automatically.", UserNameTextBox.Text), "Register Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return true;
				}
				catch (ConflictPacketException)
				{
					MessageBox.Show(String.Format("User '{0}' was already registered.  You may login.", UserNameTextBox.Text), "Already Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return true;
				}
				catch (PacketException ex)
				{
					MessageBox.Show(string.Format("The following error occurred while registering:\n\nCode: {0}\nText: {1}", ex.ErrorCode, ex.Message), "Register Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("The following exception occurred while registering:{0}{0}{1}", "\n", ex.Message), "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
				if (_SessionManager != null) _SessionManager.Dispose();
			}
		}
		
		//Attempts to register a user based on the information on the form.
		//RegisterInfo is collected.
		//Then the registration is attempted.
		//The response is passed back on the response paramater.
		private void RegisterUser() 
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				
				JabberID JID = new JabberID(UserNameTextBox.Text, ServerNameTextBox.Text, ResourceTextBox.Text);

				//get registration info
				RegisterInfoResponse IQRegisterInfoResponse = GetRegistrationInfo(JID);
				RegisterRequest IQRegister = new RegisterRequest(new JabberID(ServerNameTextBox.Text), JID.UserName, PasswordTextBox.Text, IQRegisterInfoResponse.Key);
				_SessionManager.Send(IQRegister, 30000);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
		//Gets the registration info from the specified server
		//based on the specified JabberID
		//The Jabber server doesn't do much with this, but it is part of the protocol
		//and some of the transports actually require the Key value that is returned here
		//in order to complete registration.
		private RegisterInfoResponse GetRegistrationInfo(JabberID JID)
		{
			//get registration info
			RegisterInfoRequest IQRegisterInfo = new RegisterInfoRequest(new JabberID(ServerNameTextBox.Text));

			Packet response = _SessionManager.Send(IQRegisterInfo, 30000);	
			return WConvert.ToRegisterInfoResponse(response);
		}
		
		//Loads the Contact list
		//This is in it's own routine because it is called on a delegate
		//and marshalled to the main GUI thread from a background thread
		//from the DoAuthentication method.
		private void LoadCL() { _SessionManager.LoadContactList(); }
		
		//Initializes the SessionManager.
		//This creates a connection to the server and calls open stream.
		private void InitializeSessionManager()
		{
			ConnectionOptions options = new ConnectionOptions(ServerNameTextBox.Text, 5222);
			options.StreamCulture = ((LanguageItem) Language.SelectedItem).Culture;

			Session s = new Session(options);
			s.OpenStreamSynchronous();

			_SessionManager = new SessionManager(s, this);		
			this.BringToFront();
		}
		
		//Authenticates the user with the server on the form.
		//This is called in a background thread.
		private void DoAuthentication()
		{
			try
			{
				if (! object.Equals(_SessionManager, null))
				{
					try
					{
						_SessionManager.CloseStream();
						_SessionManager.Dispose();
						_SessionManager = null;
					}
					catch
					{
					}
				}

				Session s = Session.Login(UserNameTextBox.Text, PasswordTextBox.Text, ResourceTextBox.Text, ServerNameTextBox.Text, ((LanguageItem)Language.SelectedItem).Culture);
				_SessionManager = new SessionManager(s, this);

				_SessionManager.LocalUser = new JabberID(UserNameTextBox.Text, ServerNameTextBox.Text, ResourceTextBox.Text);
				LoadCL();
				this.Hide();
			}
			catch (PacketException ex)
			{
				MessageBox.Show(string.Concat("Unable to Login :" , ex.Message), "Login Error" ,System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
			catch (StreamException ex)
			{
				MessageBox.Show(string.Concat("Unable to Login :" , ex.Message), "Login Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("The following exception occurred while authenticating:\n\n{0}", ex), "Login Failure");
				if (_SessionManager != null) _SessionManager.Dispose();
			}
		}
		
		//Make sure we show up as the topmost form once we're loaded.
		private void LoginRegisterForm_Load(object sender, System.EventArgs e) ////Handles MyBase.Load
		{
			this.BringToFront();
		}
		
		//The user wants to log in.  This could use more status
		//info and some control locking.
		private void LoginButton_Click(object sender, System.EventArgs e) ////Handles LoginButton.Click
		{
			//Auth in a new thread so the GUI doesn't hang
			Validate();
			Login();
		}
		
		private void Login()
		{
			SaveSettings();
			
			try { DoAuthentication(); }
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		
		//Attempt to register a user based on the info on the form.
		//We could pull this out and use it for registering with
		//gateways/transports as well if that feature is added.
		private void RegisterButton_Click(object sender, System.EventArgs e) ////Handles RegisterButton.Click
		{
			bool shouldLogin = false;
			
			if (! Validate())
				return;
			
			try
			{
				//Register in a new thread so the GUI doesn't hang
				this.Text = string.Format("{0}  -  Registering", _baseText);
				shouldLogin = DoRegistration();
			}
			finally
			{
				this.Text = _baseText;
			}
			
			if (shouldLogin)
				Login();
		}
		
		private new bool Validate()
		{
			UserNameTextBox.Text = UserNameTextBox.Text.Trim();
			PasswordTextBox.Text = PasswordTextBox.Text.Trim();
			ResourceTextBox.Text = ResourceTextBox.Text.Trim();
			ServerNameTextBox.Text = ServerNameTextBox.Text.Trim();
						
			if (UserNameTextBox.Text.IndexOfAny(new Char[] { '@', ' ', '/', '\\'} ) > -1)
			{
				MessageBox.Show("Your user name is not formatted correctly. Please use a different user name.\nExamples of a valid user name are: 'ViewsonicUser', 'CertificationUser', 'JohnDoe'", "Invalid Characters");
				return false;
			}
			
			if (UserNameTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("You must enter a user name to login.", "Empty User Name");
				return false;
			}
			
			if (PasswordTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("You must enter a password to login.", "Empty Password");
				return false;
			}
			
			if (ResourceTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("You must enter a resource Name to login.", "Empty Resource");
				return false;
			}
			
			if (ServerNameTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("You must enter a Server Name to login.", "Empty Server Name");
				return false;
			}
						
			try { JabberID j = new JabberID(ServerNameTextBox.Text, ServerNameTextBox.Text, ResourceTextBox.Text); }
			catch
			{
				MessageBox.Show("Your user name is not formatted correctly. Please use a different user name.\nExamples of a valid user name are: 'ViewsonicUser', 'CertificationUser', 'JohnDoe'", "Invalid Characters");
				return false;
			}
			
			string hostName = ServerNameTextBox.Text;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.Text = string.Format("{0}  -  Validating Server Name", _baseText);
				System.Net.IPHostEntry IP = System.Net.Dns.GetHostByName(hostName);
			}
			catch
			{
				MessageBox.Show("The Server name you entered cannot be found. Please try a different server.", "Unknown Host Name");
				return false;
			}
			finally
			{
				this.Text = _baseText;
				this.Cursor = Cursors.Default;
			}
			
			return true;
		}
		
		private void _SessionManager_IncomingAsynchronousException(System.Exception ReceivedException) //Handles _SessionManager.IncomingAsynchronousException
		{
			string message = string.Concat("An error has occurred while processing your request.  The error is as follows: ", ReceivedException.Message);
			MessageBox.Show(message);
		}
		
		private DataSet MakeUserDataset()
		{
			DataSet ds = new DataSet("User Login");
			DataTable dt = ds.Tables.Add("User Settings");
			
			dt.Columns.Add("UserName");
			dt.Columns.Add("Password");
			dt.Columns.Add("Resource");
			dt.Columns.Add("ServerName");
			dt.Columns.Add("Port");
			
			ds.AcceptChanges();
			
			return ds;
		}
		
		private void LoadSettings()
		{
			try
			{
				DataSet ds = new DataSet();
				ds.ReadXml(USER_FILE_NAME);
				
				UserNameTextBox.Text = (string) ds.Tables[0].Rows[0]["UserName"];
				PasswordTextBox.Text = (string) ds.Tables[0].Rows[0]["Password"];
				ResourceTextBox.Text = (string) ds.Tables[0].Rows[0]["Resource"];
				ServerNameTextBox.Text = (string) ds.Tables[0].Rows[0]["ServerName"];				
			}
			catch {}
		}
		
		private void SaveSettings()
		{
			try
			{
				DataSet ds = MakeUserDataset();
				DataRow dr = ds.Tables[0].NewRow();
				dr["UserName"] = UserNameTextBox.Text;
				dr["Password"] = PasswordTextBox.Text;
				dr["Resource"] = ResourceTextBox.Text;
				dr["ServerName"] = ServerNameTextBox.Text;

				ds.Tables[0].Rows.Add(dr);
				ds.AcceptChanges();

				ds.WriteXml(USER_FILE_NAME);
			}
			catch {}
		}
		
		protected override void OnClosed(System.EventArgs e)
		{
			if (_SessionManager != null)
				_SessionManager.Dispose();
			
			Application.Exit();
		}
	}
}
