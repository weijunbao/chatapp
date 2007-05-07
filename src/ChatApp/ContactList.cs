using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Coversant.SoapBox.Base;
using System.Drawing;
using ChatApp.Properties;
using System.IO;
using System.Security.Permissions;
using System.Runtime.InteropServices;


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
                //string rawName = userName;
                //if (rawName.Contains('@') == true)
                //{
                //    int index = rawName.IndexOf('@');
                //    rawName = rawName.Substring(0, index);
                //}
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

        public void CleanupTempFiles()
        {
            foreach (Contact contact in this)
            {
                try
                {
                    File.Delete(contact.AvatarImagePath);
                }
                catch { }
            }
            string AvatarFolder = System.Windows.Forms.Application.LocalUserAppDataPath;
            AvatarFolder = Path.Combine(AvatarFolder, "Avatar");
            try
            {
                if (Directory.Exists(AvatarFolder))
                {
                    Directory.Delete(AvatarFolder, true);
                }
            }
            catch { }
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

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern uint GetTempFileName(string tmpPath, string prefix, uint uniqueIdOrZero, StringBuilder tmpFileName);
 
        public static readonly Image DefaultAvatarImage = ChatApp.Properties.Resources.DefaultAvatar;
        private string avatarImagePath = string.Empty;
        private string formattedName;
        private Image avatarImage = null;
        private string m_groupName;
        private LoginState m_userStatus;
        private JabberID jabberId;
        private string AvatarFolder = string.Empty;

        public Contact(JabberID JID,
                        string groupName, 
                        LoginState userStatus)
        {
            jabberId = (JabberID)JID.Clone();
            m_groupName = groupName;
            m_userStatus = userStatus;
            avatarImage = DefaultAvatarImage;

            AvatarFolder = System.Windows.Forms.Application.LocalUserAppDataPath;
            AvatarFolder = Path.Combine(AvatarFolder, "Avatar");
            Directory.CreateDirectory(AvatarFolder);
        }

        public string AvatarImagePath
        {
            get { return avatarImagePath; }
        }

        public Image AvatarImage
        {
            get { return avatarImage; }
            set 
            {
                avatarImage = value;
                avatarImagePath = GetNewFileName();
                avatarImage.Save(avatarImagePath);
            }
        }

        private string GetNewFileName()
        {
            new FileIOPermission(FileIOPermissionAccess.Write, this.AvatarFolder).Demand();
            StringBuilder tmpFileName = new StringBuilder(260);
            if (GetTempFileName(this.AvatarFolder, "png", 0, tmpFileName) == 0)
            {
                throw new ApplicationException("Could not create local avatat file");
            }
            return tmpFileName.ToString();
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
		    get { return jabberId.Resource;}
	    }

        public string ServerName
	    {
		    get { return jabberId.Server;}
	    }

        public string GroupName
        {
            get { return m_groupName; }
            set { m_groupName= value; }
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
            if(null == contact)
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

