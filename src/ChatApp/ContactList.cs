using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    }

    public class Contact
    {
        private string m_groupName;
        private LoginState m_userStatus;
        private JabberID jabberId;

        public Contact(JabberID JID,
                        string groupName, 
                        LoginState userStatus)
        {
            jabberId = (JabberID)JID.Clone();
            m_groupName = groupName;
            m_userStatus = userStatus;
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

