using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Toolkit;

using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.IQ.Register;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.IQ;
using System.Text.RegularExpressions;


namespace ChatApp
{
    public partial class MessagingWindow : KryptonForm
    {
        string message = null;
        Regex regx = new Regex("\r\n|\n", RegexOptions.Multiline | RegexOptions.Compiled);
        private string m_remoteUserJabberId = null;
        private string _messageThreadID = String.Empty;

        private bool firstMessagefromSelf = true;
        private bool firstMessageFromFriend = true;

        public string RemoteUserJabberId
        {
            get { return m_remoteUserJabberId; }
            set { m_remoteUserJabberId = value; }
        }

        public string MessageThreadID
        {
            get { return _messageThreadID; }
            set { _messageThreadID = value; }
        }
	

        public MessagingWindow()
        {
            InitializeComponent();
            string binPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string templateFilePath = Path.Combine(binPath , @"Resources\MessageTemplate.html");
            msgHistoryWindow.Navigate(templateFilePath);
                        
        }

        private void msgHistoryWindow_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            msgHistoryWindow.Document.Body.Style = @"margin:0 2 0 2;";
            msgHistoryWindow.Document.Body.InnerHtml = @"<span id='placeholder'/>";
        }
        
        public void AddMessageToHistory(MessagePacket msg)
        {
            string encodedBody = System.Web.HttpUtility.HtmlEncode(msg.Body);

            System.Text.StringBuilder messageBuilder = new System.Text.StringBuilder();
            messageBuilder.Append(@"<div class='chat in'><div class='msg'>")
                          .Append(GetAvatarFormatting(msg))
                          .Append(GetUserFormatting(msg.From.UserName.ToString()))
                          .Append(GetMessageFormatting(encodedBody))
                          .Append(@"</div><div id='Div2'></div><div class='clear'></div></div><div class='break'></div>")
                          .Append(@"<span id='placeholder'/>");

            message = messageBuilder.ToString();

            if (msgHistoryWindow.Document.Body != null)
            {
                HtmlElementCollection spanElements = msgHistoryWindow.Document.Body.GetElementsByTagName("span");
                if (spanElements.Count == 0 || spanElements == null)
                    return;

                foreach (HtmlElement spanElement in spanElements)
                {
                    if (spanElement.Id == "placeholder")
                    {
                        spanElement.OuterHtml = message;
                    }
                }

                foreach (HtmlElement spanElement in spanElements)
                {
                    if (spanElement.Id == "placeholder")
                    {
                        spanElement.ScrollIntoView(false);
                    }
                }
                tbMessages.Focus();
            }
        }

        private string GetAvatarFormatting(MessagePacket message)
        {
            string fromUser = message.From.UserName;
            bool drawAvatar = false;
            Contact contact = null;
            if(fromUser == AppController.Instance.CurrentUser.UserName)
            {
                contact = AppController.Instance.Contacts.Self;
                if (firstMessagefromSelf)
                {
                    drawAvatar = true;
                    firstMessagefromSelf = false;
                }
            }
            else
            {
                contact = AppController.Instance.Contacts[fromUser];
                if (firstMessageFromFriend)
                {
                    drawAvatar = true;
                    firstMessageFromFriend = false;
                }
            }
            string avatarFormat = "";

            if (drawAvatar)
            {
                string avatarImgPath = "";
                if ( (contact == null) || (string.IsNullOrEmpty(contact.AvatarImagePath)) )
                {
                    avatarImgPath = "blue_ghost.bmp";
                }
                else
                {
                    avatarImgPath = contact.AvatarImagePath;
                }
                avatarFormat = string.Format("<div class='icon-i'><div style='height:1px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src=\"{0}\")'></div></div>", avatarImgPath);
            }
            return avatarFormat;
        }

        private string GetMessageFormatting(string Message)
        {
            
            Message = regx.Replace(Message, "<br />");
            return string.Format(@"<div class='1st'>{0}</div>", Message);
        }

        private string GetUserFormatting(string userName)
        {
            return string.Format(@"<span class='salutation-i'>{0}</span>", userName);
        }


        private void MessagingWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m_remoteUserJabberId != null)
                AppController.Instance.RemoveWindowForUser(m_remoteUserJabberId);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            tbMessages.Focus();
            DoSendMessage();
        }

        private void DoSendMessage()
        {
            //Create the message packet
            MessagePacket outgoingPacket = null;

            outgoingPacket = new MessagePacket(new JabberID(m_remoteUserJabberId), AppController.Instance.CurrentUser, tbMessages.Text);
            outgoingPacket.Thread = this.MessageThreadID;
            outgoingPacket.Type = "chat";   // DON'T REMOVE THIS!!!!

            //Display outgoing messages in history
            AddMessageToHistory(outgoingPacket);

            // Clear the message to send text box
            tbMessages.Text = string.Empty;

            try
            {
                AppController.Instance.BeginSend((Packet)outgoingPacket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("The following exception occurred while sending a message:\n\n{0}", ex));
            }

        }
    }
}