#region GNU-GPL

/*
 * ChatApp - An XMPP chat application.
 * http://code.google.com/p/chatapp/
 * 
 * LoginState.cs - Useful Enumerations
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

namespace ChatApp
{
    public enum LoginState
    {
        Online = 0,
        Away = 1,
        Chat = 2,
        Busy = 3,
        ExtendedAway = 4,
        Offline = 5
    }
}