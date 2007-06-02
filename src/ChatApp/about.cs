#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * about.cs - About Box
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