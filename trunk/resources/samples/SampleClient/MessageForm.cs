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

namespace Coversant.SoapBox.SampleClient
{
    /// <summary>
    /// Summary description for MessageForm.
    /// </summary>
    public class MessageForm : System.Windows.Forms.Form
    {
        //Holds a local copy of the SessionManager used mainly send/recieve packets
        private SessionManager _SessionManager;

        //Contains the local user this applies to
        //This is here for when GroupChat private messages are implemented.
        private JabberID _localUser;
        private bool _subjectChanged = false;
        private string _messageThreadID = "";

        //The user we're talking to on the other end.
        private JabberID _remoteUser;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox SubjectTextBox;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.TextBox ToTextBox;
        private System.Windows.Forms.RichTextBox MessageTextBox;
        private System.Windows.Forms.TabControl LanguageHistory;

        internal SessionManager.IncomingMessageDelegate _incomingMessageDelegate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox HistoryTextBox;

        public class MessageHistoryTabPage
        {
            public TabPage tp;
            public System.Globalization.CultureInfo culture;
        }

        private System.Collections.Hashtable _historyPageDictionary = new System.Collections.Hashtable();

        public MessageForm()
            : base()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            CenterForm();
            SetupTabs();
        }

        public MessageForm(SessionManager mySession)
            : this()
        {
            _SessionManager = mySession;
            _incomingMessageDelegate = new SessionManager.IncomingMessageDelegate(OnIncomingMessage);
            _SessionManager.IncomingMessage += (_incomingMessageDelegate);
            SetupTabs();
        }

        public MessageForm(SessionManager mySession, JabberID RemoteUserJID)
            : this(mySession)
        {
            RemoteUser = RemoteUserJID;
            SetupTabs();
        }

        public MessageForm(SessionManager mySession, JabberID LocalUserJID, JabberID RemoteUserJID)
            : this(mySession, RemoteUserJID)
        {
            LocalUser = LocalUserJID;
            SetupTabs();
        }

        private void SetupTabs()
        {
            LanguageHistory.TabPages.Clear();
        }

        private void CenterForm()
        {
            Rectangle screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(Convert.ToInt32((screen.Width - this.Width) / 2), Convert.ToInt32((screen.Height - this.Height) / 2));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.label5 = new System.Windows.Forms.Label();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.MessageTextBox = new System.Windows.Forms.RichTextBox();
            this.LanguageHistory = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HistoryTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.LanguageHistory.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.label5.Location = new System.Drawing.Point(7, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "To";
            // 
            // ToTextBox
            // 
            this.ToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTextBox.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.ToTextBox.Location = new System.Drawing.Point(67, 7);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.ReadOnly = true;
            this.ToTextBox.Size = new System.Drawing.Size(420, 20);
            this.ToTextBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.label6.Location = new System.Drawing.Point(7, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Message Composition";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.label7.Location = new System.Drawing.Point(7, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Message History";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.label8.Location = new System.Drawing.Point(7, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "Subject";
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SubjectTextBox.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.SubjectTextBox.Location = new System.Drawing.Point(67, 28);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(420, 20);
            this.SubjectTextBox.TabIndex = 1;
            this.SubjectTextBox.TextChanged += new System.EventHandler(this.SubjectTextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F);
            this.button1.Location = new System.Drawing.Point(420, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // PictureBox2
            // 
            this.PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(7, 312);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(137, 40);
            this.PictureBox2.TabIndex = 10;
            this.PictureBox2.TabStop = false;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextBox.Location = new System.Drawing.Point(8, 248);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(472, 56);
            this.MessageTextBox.TabIndex = 11;
            this.MessageTextBox.Text = "";
            this.MessageTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyUp);
            // 
            // LanguageHistory
            // 
            this.LanguageHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageHistory.Controls.Add(this.tabPage1);
            this.LanguageHistory.Location = new System.Drawing.Point(8, 80);
            this.LanguageHistory.Name = "LanguageHistory";
            this.LanguageHistory.SelectedIndex = 0;
            this.LanguageHistory.Size = new System.Drawing.Size(472, 128);
            this.LanguageHistory.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HistoryTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(464, 102);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "(default)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HistoryTextBox
            // 
            this.HistoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryTextBox.Location = new System.Drawing.Point(0, 0);
            this.HistoryTextBox.Name = "HistoryTextBox";
            this.HistoryTextBox.ReadOnly = true;
            this.HistoryTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.HistoryTextBox.Size = new System.Drawing.Size(464, 102);
            this.HistoryTextBox.TabIndex = 0;
            this.HistoryTextBox.Text = "";
            // 
            // MessageForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(493, 353);
            this.Controls.Add(this.LanguageHistory);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.SubjectTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(280, 336);
            this.Name = "MessageForm";
            this.Text = "SoapBox Messages";
            this.Closed += new System.EventHandler(this.MessageForm_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.LanguageHistory.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public JabberID RemoteUser
        {
            get { return _remoteUser; }
            set
            {
                _remoteUser = value;
                this.Text = string.Format("Messages To/From {0}", _remoteUser);
                ToTextBox.Text = value.ToString();
            }
        }

        //This is specified here because groupchat private messages
        //also use the message window.  Otherwise we could use the
        //global LocalUser on the SessionManager.
        public JabberID LocalUser
        {
            get
            {
                if (_localUser == null) _localUser = _SessionManager.LocalUser;
                return _localUser;
            }
            set { _localUser = value; }
        }

        //Send the message in the MessageTextBox to the RemoteUser.
        private void DoSendMessage()
        {

            //If no local or remote user is initialized, don't do anything
            if (LocalUser == null || RemoteUser == null) return;

            //Create the message packet
            MessagePacket outgoingPacket;
            if (_subjectChanged)
            {
                _subjectChanged = false;
                outgoingPacket = new MessagePacket(RemoteUser, LocalUser, SubjectTextBox.Text, MessageTextBox.Text);
            }
            else
            {
                outgoingPacket = new MessagePacket(RemoteUser, LocalUser, MessageTextBox.Text);
            }

            //ensure this is a chat message so that current clients interpret it correctly
            outgoingPacket.Type = "chat";
            outgoingPacket.Thread = this.MessageThreadID;

            //Display outgoing messages in history
            AddMessageToHistory(outgoingPacket);

            // Clear the message to send text box
            MessageTextBox.Text = string.Empty;

            try
            {
                Packet p = (Packet)outgoingPacket;
                _SessionManager.BeginSend(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("The following exception occurred while sending a message:\n\n{0}", ex));
            }

        }

        public void PostMessage(MessagePacket p)
        {
            OnIncomingMessage(p);
        }

        /// <summary>
        /// Event received from SessionManager when a message packet is received.
        /// </summary>        
        private void OnIncomingMessage(AbstractMessagePacket IncomingMessagePacket)
        {
            if (IncomingMessagePacket is MessageErrorPacket)
            {
                MessageErrorPacket msgError = (MessageErrorPacket)IncomingMessagePacket;
                if (msgError.To.ToString().ToLower().Equals(LocalUser.ToString().ToLower()))
                    MessageBox.Show(
                        string.Format("The following message error packet was received:\n\nCode: {0}\nText: {1}", msgError.ErrorCode, msgError.ErrorText));
            }
            else if (IncomingMessagePacket is MessagePacket)
            {
                MessagePacket msgPacket = (MessagePacket)IncomingMessagePacket;

                if (msgPacket.From.Equals(RemoteUser, JabberID.JabberIDCompareEnum.JabberIDCompareWithResource) || 
                    msgPacket.Thread.Equals(MessageThreadID, StringComparison.InvariantCultureIgnoreCase))
                {                    
                    this.Invoke(new Session.PacketReceivedDelegate(IncomingAsyncMessage), new object[]{msgPacket}); 
                }
            }
        }

        //Invoked by the AsyncMessageHandlerHelper.
        private void IncomingAsyncMessage(Packet p)
        {
            MessagePacket IncomingMessage = p as MessagePacket;
            AddMessageToHistory(IncomingMessage);
        }

        //If the message applies to us this routine:
        //Adds the given message to the message collection.
        //Adds the message to the textbox.
        public void AddMessageToHistory(MessagePacket msg)
        {
            //this probably means a different type of message (like a "composing" event)
            //'but for the sake of this sample we don't need to handle it
            if (msg.BodiesByCulture.ContainsKey(String.Empty) && msg.Body.Length == 0) return;

            //*** Determine which languages this message has in it
            System.Globalization.CultureInfo defaultCulture = _SessionManager.Session.StreamCulture;

            foreach (string localizedLanguage in msg.BodiesByCulture.Keys)
            {
                string actualLanguage = localizedLanguage;

                string localizedBody = msg.BodiesByCulture[actualLanguage];
                if (actualLanguage.Equals(String.Empty))
                {
                    if (msg.HasXMLLangAttribute() == true)
                    {
                        actualLanguage = msg.Culture.Name;
                    }
                    else
                    {
                        //*** The message body didn't have a language tag on it. The 
                        //	Packet doesn't have a language tag on it, so we have 
                        //  no idea what language this is in - assume it to be the 
                        //  stream native language
                        actualLanguage = defaultCulture.Name;
                    }
                }

                if (localizedBody.EndsWith("\r\n"))
                {
                    localizedBody = localizedBody.Substring(0, localizedBody.Length - "\r\n".Length);
                }

                RichTextBox rtb = GetTextBoxForLanguage(new System.Globalization.CultureInfo(actualLanguage));


                System.Text.StringBuilder messageBuilder = new System.Text.StringBuilder();
                messageBuilder.Append(msg.From.UserName.ToString());
                if (msg.From.IsFullJID())
                {
                    messageBuilder.Append("/");
                    messageBuilder.Append(msg.From.Resource);
                }
                messageBuilder.Append(":  ");

                if (rtb.Text.Length > 0)
                {
                    messageBuilder.Insert(0, "\r\n");
                }

                rtb.Text = messageBuilder.Insert(0, rtb.Text).Append(localizedBody).ToString();

                //make sure the current text stays visible
                rtb.Select(rtb.TextLength - 1, 1);
                rtb.ScrollToCaret();
            }

        }

        private RichTextBox GetTextBoxForLanguage(System.Globalization.CultureInfo culture)
        {
            TabPage tp = GetTabPageForLanguage(culture);
            foreach (Control c in tp.Controls)
            {
                if (c is RichTextBox)
                {
                    return (RichTextBox)c;
                }
            }

            return null;
        }

        private TabPage GetTabPageForLanguage(System.Globalization.CultureInfo culture)
        {
            if (_historyPageDictionary.ContainsKey(culture.Name.ToLower()))
            {
                return ((MessageHistoryTabPage)_historyPageDictionary[culture.Name.ToLower()]).tp;
            }
            else
            {

                MessageHistoryTabPage page = new MessageHistoryTabPage();
                page.culture = culture;
                page.tp = new TabPage(culture.EnglishName);

                RichTextBox rtb = new RichTextBox();
                rtb.Multiline = true;
                rtb.ReadOnly = true;
                rtb.Visible = true;
                page.tp.Controls.Add(rtb);
                rtb.Dock = DockStyle.Fill;
                rtb.ScrollBars = RichTextBoxScrollBars.Vertical;

                LanguageHistory.TabPages.Add(page.tp);
                _historyPageDictionary.Add(culture.Name.ToLower(), page);

                return page.tp;
            }
        }

        private void CloseButton_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void SendButton_Click(System.Object sender, System.EventArgs e) //Handles SendButton.Click
        {
            DoSendMessage();
            MessageTextBox.Focus();
        }

        private void MessageTextBox_KeyUp(Object sender, System.Windows.Forms.KeyEventArgs e) //Handles MessageTextBox.KeyUp
        {
            //if they hit return we send the message			
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                DoSendMessage();
            }
        }

        public string MessageThreadID
        {
            get { return _messageThreadID; }
            set { _messageThreadID = value; }
        }

        private void MessageForm_Closed(Object sender, System.EventArgs e) //Handles MyBase.Closed
        {
            _SessionManager.MessageWindows.Remove(RemoteUser);
            _SessionManager.IncomingMessage -= (_incomingMessageDelegate);
            _SessionManager = null;
            this.Dispose();
        }

        private void SubjectTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _subjectChanged = true;
        }
    }
}
