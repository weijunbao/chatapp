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
using Coversant.SoapBox.Core.IQ.Roster;
using Coversant.SoapBox.Core.Presence;
using Coversant.SoapBox.Core;

namespace Coversant.SoapBox.SampleClient
{
    /// <summary>
    /// Summary description for ListViewRosterItem.
    /// </summary>


    public class ListViewRosterItem : System.Windows.Forms.ListViewItem, IComparable
    {

        private RosterItem _rosterItem;
        private PresencePacket _presence;

        public ListViewRosterItem() : base() { }
        public ListViewRosterItem(RosterItem ri)
            : this()
        {
            _rosterItem = ri;
            buildSubItemsFromRosterItem();
        }

        public RosterItem RosterItem
        {
            get { return _rosterItem; }
            set
            {
                _rosterItem = value;
                buildSubItemsFromRosterItem();
            }
        }

        private void buildSubItemsFromRosterItem()
        {
            this.SubItems.Clear();
            this.Text = _rosterItem.Name;
            ListViewSubItem i1 = new ListViewSubItem(this, "Unknown");
            ListViewSubItem i2 = new ListViewSubItem(this, string.Empty);

            if (!object.Equals(_presence, null))
            {
                if (_presence is AvailableRequest)
                {
                    AvailableRequest avail = WConvert.ToAvailableRequest(_presence);
                    i1.Text = avail.Show.ToString();
                    i2.Text = avail.Status;
                }
                else if (_presence is UnavailableRequest)
                {
                    UnavailableRequest unavail = WConvert.ToUnavailableRequest(_presence);
                    i1.Text = "Unavailable";
                    i2.Text = unavail.Status;
                }
                else
                {
                    //*** Do nothing
                }
            }

            ListViewSubItem i3 = new ListViewSubItem(this, _rosterItem.Subscription.ToLower());
            this.SubItems.Add(i1);
            this.SubItems.Add(i2);
            this.SubItems.Add(i3);
        }

        public Coversant.SoapBox.Core.Presence.PresencePacket Presence
        {
            get { return _presence; }
            set
            {
                if (value is AvailableRequest)
                {
                    _presence = value;
                    AvailableRequest avail = WConvert.ToAvailableRequest(value);
                    this.SubItems[1].Text = avail.Show.ToString();
                    this.SubItems[2].Text = avail.Status;
                }
                else if (value is Coversant.SoapBox.Core.Presence.UnavailableRequest)
                {
                    _presence = value;
                    UnavailableRequest unavail = WConvert.ToUnavailableRequest(value);
                    this.SubItems[1].Text = "Unavailable";
                    this.SubItems[2].Text = unavail.Status;
                }
                else
                {
                    //'*** Do nothing
                }
            }
        }

        public int CompareTo(Object obj)
        {
            ListViewRosterItem lvri = (ListViewRosterItem)(obj);
            return lvri.RosterItem.Group.CompareTo(this.RosterItem.Group);
        }
    }
}
