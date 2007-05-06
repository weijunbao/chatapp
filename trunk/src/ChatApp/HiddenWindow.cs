using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ChatApp
{
    public partial class HiddenWindow : Form
    {
        private string toolTipMessage;

        public HiddenWindow()
        {
            InitializeComponent();
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams baseParams = new System.Windows.Forms.CreateParams();
                baseParams.Style = 0x40000000; //WS_CHILD 
                baseParams.Caption = "HiddenWindow";
                return baseParams;
            }
        }

        private void MnuItemExit_Click(object sender, EventArgs e)
        {
            AppController.Instance.ExitApplication();
        }

        private void MnuItemShow_Click(object sender, EventArgs e)
        {
            AppController.Instance.Activate();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AppController.Instance.Activate();
        }

        private void ShowBalloonThreadProc()
        {
            this.TrayIcon.ShowBalloonTip(3, "Chat App", toolTipMessage, ToolTipIcon.Info);
            Thread.Sleep(1000);
            // this.TrayIcon.ShowBalloonTip(0, "", string.Empty, ToolTipIcon.None);
        }

        public void ShowBalloonToolTip(string message)
        {
            toolTipMessage = message;
            Thread balloonThread = new Thread(new ThreadStart(ShowBalloonThreadProc));
            balloonThread.Start();
        }
    }
}