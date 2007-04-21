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


namespace ChatApp
{
    public partial class MessagingWindow : KryptonForm
    {
        string message = null;

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
            System.Text.StringBuilder messageBuilder = new System.Text.StringBuilder();
            messageBuilder.Append(msg.From.UserName.ToString()).Append(": ").Append(msg.Body).Append("\n");
            message = messageBuilder.ToString();
            rtbmsgHistory.AppendText(message);
            rtbmsgHistory.ScrollToCaret();
            tbMessages.Focus();
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
    }
}