using System;
using System.Threading;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class HiddenWindow : Form
    {
        private string toolTipMessage;

        public HiddenWindow()
        {
            InitializeComponent();
        }

        #region Event Handlers

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

        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = new CreateParams();
                baseParams.Style = 0x40000000; //WS_CHILD 
                baseParams.Caption = "HiddenWindow";
                return baseParams;
            }
        }

        private void ShowBalloonThreadProc()
        {
            TrayIcon.ShowBalloonTip(3, "Chat App", toolTipMessage, ToolTipIcon.Info);
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