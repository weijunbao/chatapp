#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * HiddenWindow.cs - Window to interact with the tray window
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