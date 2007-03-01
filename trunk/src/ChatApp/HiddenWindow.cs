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