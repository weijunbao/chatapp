using System;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ChatApp
{
    public partial class About : KryptonForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LaunchInBrowser(string Link)
        {
            ProcessStartInfo procInfo = new ProcessStartInfo(Link);
            procInfo.UseShellExecute = true;
            Process.Start(procInfo);
        }

        private void lblLink_LinkClicked(object sender, EventArgs e)
        {
            KryptonLinkLabel label = sender as KryptonLinkLabel;
            if (label == null)
                return;
            LaunchInBrowser(label.Text);
        }
    }
}