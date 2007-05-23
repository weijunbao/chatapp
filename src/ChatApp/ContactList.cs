using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Coversant.SoapBox.Base;
using System.Drawing;
using ChatApp.Properties;
using System.IO;
using System.Security.Permissions;


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
        public static readonly Image DefaultAvatarImage = ChatApp.Properties.Resources.DefaultAvatar;
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
            jabberId = (JabberID)JID.Clone();
            m_groupName = groupName;
            m_userStatus = userStatus;
            avatarImage = DefaultAvatarImage;

            avatarFolder = System.Windows.Forms.Application.LocalUserAppDataPath;
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

