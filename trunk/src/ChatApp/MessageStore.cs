#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * MessageStore.cs - Message store
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