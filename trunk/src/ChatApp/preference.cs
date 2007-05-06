using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 


namespace ChatApp
{
    public partial class preference : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private bool defInChsound;
        private bool defInChnotify;
        private bool defOnlinesound;
        private bool defOnlinenotify;

        public preference()
        {
            InitializeComponent();
            defInChnotify = cbChnotify.Checked;
            defInChsound = cbChplay.Checked;
            defOnlinenotify = cbOnotify.Checked;
            defOnlinesound = cbOsound.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//incoming presence sound
        {
            
            if (cbOsound.Checked == true)
            {
                AppController.Instance.Osound = true;
            }
            else
            {
                cbOsound.Checked = false;
                AppController.Instance.Osound = false;
            }
        }

       
        private void cbShnotify_CheckedChanged(object sender, EventArgs e)//incoming presence notification
        {
            if (cbOnotify.Checked == true)
            {
                AppController.Instance.Onotify = true;
            }
            else
            {
                cbOnotify.Checked = false;
                AppController.Instance.Onotify = false;
            }
        }

       

        private void cbChnotify_CheckedChanged(object sender, EventArgs e)//incoming message notification
        {
            if (cbChnotify.Checked == true)
            {
                AppController.Instance.chNotify = true;
            }
            else
            {
                cbChnotify.Checked = false;
                AppController.Instance.chNotify = false;
            }
        }

        private void cbChplay_CheckedChanged(object sender, EventArgs e)//incoming message sound
        {
            if (cbChplay.Checked == true)
            {
                AppController.Instance.chSound = true;
            }
            else
            {
                cbChplay.Checked = false;
                AppController.Instance.chSound = false;
            }
        }

        private void btok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            AppController.Instance.Osound = defOnlinesound;
            AppController.Instance.Onotify = defOnlinenotify;
            AppController.Instance.chSound = defInChsound;
            AppController.Instance.chNotify = defInChnotify;
            this.Hide();
        }
    }
}