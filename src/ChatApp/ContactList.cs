using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Coversant.SoapBox.Base;
//this is contact list
namespace ChatApp
{
    public class ContactList
    {
        private ArrayList m_Contacts;

        public ContactList()
        {
            m_Contacts = new ArrayList();
        }

        public void AddContact(Contact contact)
        {
            m_Contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            m_Contacts.Remove(contact);
        }

        public int Count
        {
            get { return m_Contacts.Count; }
        }

        // Indexer
        public Contact this[int index]
        { 
            get { return (Contact)m_Contacts[index];  } 
        }

        public Contact this[string userName]
        {
            get
            {
                Contact contact = null;
                bool bFound = false;
                for (int i = 0; i < m_Contacts.Count; ++i)
                {
                    contact = (Contact)m_Contacts[i];
                    if (contact.UserName == userName)
                    {
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                    contact = null;
                return contact;
            }
        }
    }

    public class Contact
    {
        private string m_userName;
        private string m_fullName;
        private string m_resource;
        private string m_serverName;
        private string m_groupName;
        private LoginState m_userStatus;

        public Contact(string userName, 
                        string fullName, 
                        string resource, 
                        string serverName, 
                        string groupName, 
                        LoginState userStatus)
        {
            m_userName = userName;
            m_fullName = fullName;
            m_resource = resource;
            m_serverName = serverName;
            m_groupName = groupName;
            m_userStatus = userStatus;
        }
        
        public Contact(string userName)
        {
            m_userName = userName;
        }
        public string UserName
	    {
		    get { return m_userName;}
		    set { m_userName = value;}
	    }

        public JabberID JabberId
        {
            get
            {
                JabberID jabberId = new JabberID(m_userName, m_serverName, Properties.Settings.Default.Resource);
                return jabberId; 
            }
        }

        public string FullName
	    {
		    get { return m_fullName;}
		    set { m_fullName = value;}
	    }

        public string Resource
	    {
		    get { return m_resource;}
		    set { m_resource = value;}
	    }

        public string ServerName
	    {
		    get { return m_serverName;}
		    set { m_serverName = value;}
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
	}
}
