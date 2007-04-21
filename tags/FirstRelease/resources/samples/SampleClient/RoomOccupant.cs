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
using Coversant.SoapBox.Core;
using Coversant.SoapBox.Core.Message;
using Coversant.SoapBox.Core.IQ;
using Coversant.SoapBox.Core.IQ.Time;
using Coversant.SoapBox.Core.IQ.Version;
using Coversant.SoapBox.Core.IQ.Last;

namespace Coversant.SoapBox.SampleClient
{
	public class RoomOccupant
	{
		JabberID _occupantJID = null;
		SessionManager _sm = null;
												 
		public RoomOccupant(JabberID jid, SessionManager sm)
		{
            _occupantJID = jid;
            _sm = sm;
		}

		public string OccupantJID
		{
			get { return _occupantJID.ToString(); } 
		}

		public string NickName
		{
			get { return _occupantJID.Resource; }
		}

		public override string ToString()
		{
			return this.NickName;
		}

		public void SendPrivateMessage()
		{
			_sm.MessageWindows.Show(_occupantJID);
		}

		public void SendPrivateMessage(string msg)
		{
            MessagePacket msgPacket = new MessagePacket("chat");
            msgPacket.Body = msg;
            msgPacket.To = _occupantJID;
            msgPacket.From = _sm.LocalUser;

            _sm.SendAndForget(msgPacket);
            _sm.MessageWindows.Show(_occupantJID);
            _sm.MessageWindows.Item(_occupantJID).AddMessageToHistory(msgPacket);
		}

		public void RequestVersion() 
		{
			VersionRequest req = new VersionRequest(_occupantJID);
			_sm.BeginSend(req, new AsyncCallback(VersionResponseCallback));
		}

		private void VersionResponseCallback(IAsyncResult ar)
		{
			try
			{
				Packet p = _sm.Session.EndSend(ar);
                if (p == null) 
					throw new ApplicationException("No response received");

				if (p is VersionResponse)
				{
                    VersionResponse resp = WConvert.ToVersionResponse(p);
                    string respText = string.Format("Nick Name: {0}, Client Name: {1}, Version: {2}, OS: {3}", _occupantJID.Resource, resp.Name, resp.Version, resp.OS);
                    MessageBox.Show(respText);
				}
				else
				{
                    throw new ApplicationException("Version response was not received");
				}
			}
			catch (PacketException ex)
			{
                MessageBox.Show(string.Concat("Error requesting version: ", ex.Message));
			}
			catch (Exception ex)
			{
                MessageBox.Show(string.Concat("Error requesting version: ", ex.Message));
			}
		}

		public void RequestTime()
		{
			TimeRequest req = new TimeRequest(_occupantJID);
            _sm.BeginSend(req.ToPacket, new AsyncCallback(TimeResponseCallback));
		}

		private void TimeResponseCallback(IAsyncResult ar)
		{
			try
			{
				Packet p = _sm.Session.EndSend(ar);
				if (p == null) 
					throw new ApplicationException("No response received");

				if (p is TimeResponse)
				{
					TimeResponse resp = WConvert.ToTimeResponse(p);
					string respText = string.Format("Nick Name: {0}, UTC: {1}, Timezone: {2}, Raw Time: {3}", _occupantJID.Resource, resp.UTCDateTime.ToString(), resp.Timezone, resp.RawTime);
					MessageBox.Show(respText);
				}
				else
				{
					throw new ApplicationException("Time response was not received");
				}
			}
			catch (PacketException ex)
			{
                MessageBox.Show(string.Concat("Error requesting time: ", ex.Message));
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Concat("Error requesting time: ", ex.Message));
			}
		}
	}
}
