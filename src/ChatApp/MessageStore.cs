using System;

namespace ChatApp
{
    public class MessageStoreController
    {
        public MessageStore MessageStore
        {
            get { throw new NotImplementedException(); }
            set { }
        }
    }

    public class ConfigStoreController
    {
        public ConfigStore ConfigStore
        {
            get { throw new NotImplementedException(); }
            set { }
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Store()
        {
            throw new NotImplementedException();
        }
    }

    public class MessageStore
    {
    }

    public class ConfigStore
    {
    }
}