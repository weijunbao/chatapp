using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class HiddenWindow : Form
    {
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
    }
}