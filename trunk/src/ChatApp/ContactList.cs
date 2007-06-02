#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * ContactList.cs - Manages the contacts
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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ChatApp.Properties;
using Coversant.SoapBox.Base;

namespace ChatApp
{
    public class ContactList : List<Contact>
    {
        public ContactList()
        {
        }

        // Indexer
        public Contact this[string userName]
        {
            get
            {
                foreach (Contact contact in this)
                {
                    if (contact.UserName == userName)
                    {
                        return contact;
                    }
                }
                return null;
            }
        }

        public List<string> GetAllGroups()
        {
            List<string> groupList = new List<string>();
            foreach (Contact contact in this)
            {
                string GroupName = contact.GroupName;
                if (!groupList.Contains(GroupName))
                {
                    groupList.Add(GroupName);
                }
            }
            return groupList;
        }

        private Contact self;

        public Contact Self
        {
            get { return self; }
            set { self = value; }
        }
    }

    public class Contact
    {
        public enum AvatarType
        {
            VCardAvatar,
            JabberXAvatar
        }

        private AvatarType avatarType;
        private string avatarHash = string.Empty;
        public static readonly Image DefaultAvatarImage = Resources.DefaultAvatar;
        private string avatarImagePath = string.Empty;
        private string formattedName;
        private Image avatarImage = null;
        private string m_groupName;
        private LoginState m_userStatus;
        private JabberID jabberId;
        private string avatarFolder = string.Empty;

        public Contact(JabberID JID,
                       string groupName,
                       LoginState userStatus)
        {
            jabberId = (JabberID) JID.Clone();
            m_groupName = groupName;
            m_userStatus = userStatus;
            avatarImage = DefaultAvatarImage;

            avatarFolder = Application.LocalUserAppDataPath;
            avatarFolder = Path.Combine(avatarFolder, "Avatar");
            Directory.CreateDirectory(avatarFolder);
        }

        public string AvatarHash
        {
            set { this.avatarHash = value; }
            get { return this.avatarHash; }
        }

        public AvatarType AvatatType
        {
            get { return avatarType; }
            set { avatarType = value; }
        }

        public string AvatarImagePath
        {
            get { return avatarImagePath; }
        }

        public Image AvatarImage
        {
            get
            {
                if (this.avatarImage == DefaultAvatarImage)
                {
                    // Check if the avatar file exits
                    avatarImagePath = GetAvatarFileName();
                    if (File.Exists(avatarImagePath))
                    {
                        avatarImage = Image.FromFile(avatarImagePath);
                    }
                }
                return avatarImage;
            }
            set
            {
                avatarImage = value;
                if (!File.Exists(avatarImagePath))
                {
                    avatarImagePath = GetAvatarFileName();
                }
                if (!File.Exists(avatarImagePath))
                {
                    avatarImage.Save(avatarImagePath);
                }
            }
        }

        private string GetAvatarFileName()
        {
            String tmpFileName;
            if (this.AvatarHash == string.Empty)
            {
                tmpFileName = Path.Combine(this.avatarFolder, Guid.NewGuid().ToString()) + ".temp";
            }
            else
            {
                tmpFileName = Path.Combine(this.avatarFolder, this.AvatarHash);
                tmpFileName += ".avatar";
            }
            return tmpFileName;
        }

        public string FormattedName
        {
            get { return formattedName; }
            set { formattedName = value; }
        }

        public string UserName
        {
            get { return jabberId.UserName; }
        }

        public JabberID JabberId
        {
            get { return jabberId; }
        }

        public string Resource
        {
            get { return jabberId.Resource; }
        }

        public string ServerName
        {
            get { return jabberId.Server; }
        }

        public string GroupName
        {
            get { return m_groupName; }
            set { m_groupName = value; }
        }

        public LoginState UserStatus
        {
            get { return m_userStatus; }
            set { m_userStatus = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Contact contact = obj as Contact;
            if (null == contact)
            {
                return false;
            }
            if (contact.UserName.Equals(this.UserName, StringComparison.OrdinalIgnoreCase) &&
                contact.ServerName.Equals(this.ServerName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.UserName.GetHashCode() + this.ServerName.GetHashCode();
        }
    }
}