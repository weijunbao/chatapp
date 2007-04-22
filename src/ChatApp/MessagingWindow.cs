using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
        }

        
        public void AddMessageToHistory(MessagePacket msg)
        {
            string encodedBody = System.Web.HttpUtility.HtmlEncode(msg.Body);

            System.Text.StringBuilder messageBuilder = new System.Text.StringBuilder();
            messageBuilder.Append(GetUserFormatting(msg.From.UserName.ToString()))
                          .Append(GetMessageFormatting(encodedBody))
                          .Append(@"<span id='placeholder'/>");

            message = messageBuilder.ToString();

            HtmlElementCollection spanElements = msgHistoryWindow.Document.Body.GetElementsByTagName("span");
            if (spanElements.Count == 0 || spanElements == null)
                return;

            HtmlElement spanElement = spanElements[0];
            spanElement.OuterHtml = message;

            msgHistoryWindow.Document.Body.GetElementsByTagName("span")[0].ScrollIntoView(false);
            tbMessages.Focus();
        }

        private string GetMessageFormatting(string Message)
        {
            
            Message = regx.Replace(Message, "<br />");
            return string.Format(@"<font size='-1' style='font-family:arial,Sans-Serif'>{0}</font><br />", Message);
        }

        private string GetUserFormatting(string UserName)
        {
            return string.Format(@"<font size='-2' color='blue' style='font-family:arial,Sans-Serif'><b>{0}</b>&nbsp;:&nbsp;</font>", UserName);
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
            ////Create the message packet
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

        private void msgHistoryWindow_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            msgHistoryWindow.Document.Body.Style = @"margin:0 2 0 2;";
            msgHistoryWindow.Document.Body.InnerHtml = @"<span id='placeholder'/>";
        }

        private void MessagingWindow_Load(object sender, EventArgs e)
        {
            msgHistoryWindow.Navigate("about:blank");
        }
    }
}