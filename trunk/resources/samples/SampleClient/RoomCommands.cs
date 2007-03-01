#region License Information, Copyright (c) 2006 Coversant
//Copyright (c) 2006 Coversant, Inc.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of 
//this software and associated documentation files (the "Software"), to deal in 
//the Software without restriction, including without limitation the rights to 
//use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of 
//the Software, and to permit persons to whom the Software is furnished to do so, 
//subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all 
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
//FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
//IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
//CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Windows.Forms;
using Coversant.SoapBox.Base;

namespace Coversant.SoapBox.SampleClient
{
	public class RoomCommands
	{
		public const string Join = "/join ";
		public const string Leave = "/leave";
		public const string Part = "/part";
		public const string Topic = "/topic ";
		public const string Subject = "/subject ";
		public const string Nick = "/nick ";
		public const string Quit = "/quit";
		public const string Exit = "/exit";
		public const string Invite = "/invite ";
		public const string Message = "/msg ";
		public const string Help = "/help";
		public const string Clear = "/clear";

		static string _helpText = null;

		private RoomCommands() {}

		public static bool ContainsRoomCommand(string msg)
		{
            msg = msg.ToLower();
            return msg.StartsWith(Subject) || msg.StartsWith(Leave) || msg.StartsWith(Part) || msg.StartsWith(Topic) || msg.StartsWith(Nick) || msg.StartsWith(Invite) || msg.StartsWith(Message) || msg.StartsWith(Clear);
		}

		public static bool ContainsGlobalCommand(string msg)
		{
			msg = msg.ToLower();
            return msg.StartsWith(Join) || msg.StartsWith(Quit) || msg.StartsWith(RoomCommands.Exit) || msg.StartsWith(Help);
		}

		public static string GetHelpText()
		{
			if (_helpText == null)
			{
                _helpText = MUCResources.HelpText;
			}

            return _helpText;
		}

		public static bool ProcessGlobalMessage(string msg, MultiUserChatForm _form)
		{
			try
			{
				if (msg.StartsWith(Join))
				{
                    JabberID jid = JabberID.Parse(msg.Substring(Join.Length));

					if (! jid.IsFullJID())
                        throw new ArgumentException("The JabberID must be a full JabberID in the form of room@service/nick");

                    _form.JoinRoom(jid);
				}
                else if ( msg.StartsWith(Quit) || msg.StartsWith(RoomCommands.Exit) )
                    _form.Close();
				else if ( msg.StartsWith(Help) )
                    _form.txtHistory.AppendText(GetHelpText());
                else
                    return false;

                return true;
			}
			catch ( Exception ex)
			{
                MessageBox.Show(string.Concat("Error processing command: ", ex.Message));
                return false;
			}
		}

		public static bool ProcessRoomMessage(string msg, ChatRoomTabPage rm)
		{
			try
			{
				if ( msg.StartsWith(Leave) || msg.StartsWith(Part) )
					rm.LeaveRoom();
				else if ( msg.StartsWith(Topic) )
					rm.ChangeSubject(GetCommandValue(Topic, msg));
				else if ( msg.StartsWith(Subject) )
					rm.ChangeSubject(GetCommandValue(Subject, msg));
				else if ( msg.StartsWith(Nick) )
					rm.ChangeNickName(new JabberID(rm.Room.ToString(), GetCommandValue(Nick, msg)));
				else if ( msg.StartsWith(Invite) )
					rm.Invite(JabberID.Parse(GetCommandValue(Invite, msg)));
				else if ( msg.StartsWith(Message) )
				{
                    string[] parts = GetCommandParts(msg);
                    
					if ( parts.Length < 3 )
                        throw new ArgumentException("Unsupported number of command arguments");

                    string[] messageContent = new string[parts.Length - 3];

                    Array.Copy(parts, 2, messageContent, 0, parts.Length - 2);
                    rm.SendPrivateMessage(parts[1], string.Join(" ", messageContent));
				}
                else if ( msg.StartsWith(Clear) )
                    rm.ClearMessageHistory();
				else
					return false;

				return true;
			}
			catch ( Exception ex)
			{
				MessageBox.Show(string.Concat("Error processing command: ", ex.Message));
				return false;
			}
		}

		public static string GetCommandValue(string cmd, string fullMessage)
		{
			return fullMessage.Substring(cmd.Length);
		}

		public static string[] GetCommandParts(string cmd)
		{
			return cmd.Split(' ');
		}
	}
}
