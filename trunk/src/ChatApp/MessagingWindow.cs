#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * MessagingWindow.cs - Main Message window
 *
 * Copyright (C) 2007  George Chiramattel
 * http://george.chiramattel.com
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

#endregion //GNU-GPL

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Coversant.SoapBox.Base;
using Coversant.SoapBox.Core.Message;

namespace ChatApp
{
    public partial class MessagingWindow : KryptonForm
    {
        #region Private Fields

        private string message = null;
        private Regex regx = new Regex("\r\n|\n", RegexOptions.Multiline | RegexOptions.Compiled);
        private JabberID m_remoteUserJabberId = null;
        private string _messageThreadID = String.Empty;

        private bool firstMessagefromSelf = true;
        private bool firstMessageFromFriend = true;

        #endregion

        public MessagingWindow()
        {
            InitializeComponent();
            string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string templateFilePath = Path.Combine(binPath, @"Resources\MessageTemplate.html");
            msgHistoryWindow.Navigate(templateFilePath);

#if DEBUG
            msgHistoryWindow.IsWebBrowserContextMenuEnabled = true;
#endif
        }

        #region Event Handlers

        private void OnButtonSendClick(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbMessages.Text))
            {
                return;
            }
            tbMessages.Focus();
            DoSendMessage();
        }

        private void OnMessagingWindowFormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_remoteUserJabberId != null)
                AppController.Instance.RemoveWindowForUser(m_remoteUserJabberId.JabberIDNoResource);
        }

        private void OnMsgHistoryWindowDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            msgHistoryWindow.Document.Body.Style = @"margin:0 2 0 2;";
            msgHistoryWindow.Document.Body.InnerHtml = @"<span id='placeholder'/>";
        }

        #endregion

        public JabberID RemoteUserJabberId
        {
            get { return m_remoteUserJabberId; }
            set { m_remoteUserJabberId = value; }
        }

        public string MessageThreadID
        {
            get { return _messageThreadID; }
            set { _messageThreadID = value; }
        }

        public void AddMessageToHistory(MessagePacket msg)
        {
            string encodedBody = HttpUtility.HtmlEncode(msg.Body);

            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append(@"<div class='chat in'><div class='msg'>")
                .Append(GetAvatarFormatting(msg))
                .Append(GetUserFormatting(msg))
                .Append(GetMessageFormatting(encodedBody))
                //.Append(@"</div><div id='Div2'></div><div class='clear'></div></div><div class='break'></div>")
                .Append(@"</div><div id='Div2'></div></div>")
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
            string iconStyle = "";

            if (fromUser == AppController.Instance.CurrentUser.UserName)
            {
                contact = AppController.Instance.Contacts.Self;
                if (firstMessagefromSelf)
                {
                    drawAvatar = true;
                    iconStyle = "icon-o";
                    firstMessagefromSelf = false;
                }
            }
            else
            {
                contact = AppController.Instance.Contacts[fromUser];
                if (firstMessageFromFriend)
                {
                    drawAvatar = true;
                    iconStyle = "icon-i";
                    firstMessageFromFriend = false;
                }
            }
            string avatarFormat = "";

            if (drawAvatar)
            {
                string avatarImgPath = "";
                if ((contact == null) || (string.IsNullOrEmpty(contact.AvatarImagePath)))
                {
                    avatarImgPath = "user.png";
                }
                else
                {
                    avatarImgPath = contact.AvatarImagePath;
                }
                avatarFormat =
                    string.Format(" <img class='{0}' src='{1}' height='36' width='36'>", iconStyle, avatarImgPath);
            }
            return avatarFormat;
        }

        private string GetMessageFormatting(string Message)
        {
            Message = regx.Replace(Message, "<br />");
            return string.Format(@"<div class='1st'>{0}</div>", Message);
        }

        private string GetUserFormatting(MessagePacket message)
        {
            string fromUser = message.From.UserName.ToString();
            string userFormat = "";
            if (fromUser == AppController.Instance.CurrentUser.UserName)
            {
                userFormat = string.Format(@"<span class='salutation-o'>{0}</span>", fromUser);
            }
            else
            {
                userFormat = string.Format(@"<span class='salutation-i'>{0}</span>", fromUser);
            }

            return userFormat;
        }

        private void DoSendMessage()
        {
            //Create the message packet
            MessagePacket outgoingPacket = null;

            outgoingPacket =
                new MessagePacket(m_remoteUserJabberId, AppController.Instance.CurrentUser, tbMessages.Text);
            outgoingPacket.Thread = MessageThreadID;
            outgoingPacket.Type = "chat"; // DON'T REMOVE THIS!!!!

            //Display outgoing messages in history
            AddMessageToHistory(outgoingPacket);

            // Clear the message to send text box
            tbMessages.Text = string.Empty;

            try
            {
                AppController.Instance.BeginSend((Packet) outgoingPacket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("The following exception occurred while sending a message:\n\n{0}", ex));
            }
        }
    }
}