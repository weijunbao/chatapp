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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Coversant.SoapBox.Base;
namespace Coversant.SoapBox.SampleClient
{
	/// <summary>
	/// Summary description for DebugOutput.
	/// </summary>
	public class DebugOutput : System.Windows.Forms.Form
	{
        internal System.Windows.Forms.TextBox Output;
        private IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem clearToolStripMenuItem;


		public DebugOutput()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

             PacketProcessor.SocketXmlReceived += new SocketXmlDataEventHandler(this.onXMLReceived);
             PacketProcessor.SocketXmlSent += new SocketXmlDataEventHandler(this.onXMLSent);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            Coversant.SoapBox.Base.PacketProcessor.SocketXmlReceived -= new SocketXmlDataEventHandler(this.onXMLReceived);
            Coversant.SoapBox.Base.PacketProcessor.SocketXmlSent -= new SocketXmlDataEventHandler(this.onXMLSent);

			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.Output = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.ContextMenuStrip = this.contextMenuStrip1;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.Location = new System.Drawing.Point(0, 0);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Output.Size = new System.Drawing.Size(464, 502);
            this.Output.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // DebugOutput
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(464, 502);
            this.Controls.Add(this.Output);
            this.Name = "DebugOutput";
            this.Text = "DebugOutput";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void onXMLReceived(string xml, long socketId) 
		{
			try
			{
				System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
				doc.LoadXml(xml);

				System.IO.StringWriter sw = new System.IO.StringWriter();
				System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter(sw);
				w.Formatting = System.Xml.Formatting.Indented;
				w.Indentation = 4;
                
				doc.Save(w);
				w.Flush();
				w.Close();
                string s = sw.ToString();
                int lineEnd = s.IndexOf("<", 2);
                s = s.Substring(lineEnd);

                string t = String.Format("{2}Received at {0}: {2}{1}{2}", DateTime.Now.ToShortTimeString(), s, "\r\n");
                AppendTextThreadSafe(t);
			}
			catch(Exception)
			{
			}

		}

        private void onXMLSent(string xml, long socketId) 
		{
			try
			{
				System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
				doc.LoadXml(xml);

				System.IO.StringWriter sw = new System.IO.StringWriter();
				System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter(sw);
				w.Formatting = System.Xml.Formatting.Indented;
				w.Indentation = 4;

				doc.Save(w);
				w.Flush();
				w.Close();

                string s = sw.ToString();
                int lineEnd = s.IndexOf("<", 2);
                s = s.Substring(lineEnd);

                string t = String.Format("{2}Sent at {0}: {2}{1}{2}", DateTime.Now.ToShortTimeString(), s, "\r\n");
                AppendTextThreadSafe(t);
			}
			catch(Exception)
			{
			}

		}

        private void AppendTextThreadSafe(string s)
        {
            if (this.InvokeRequired)
                this.BeginInvoke( (MethodInvoker) delegate() { this.Output.AppendText(s); });
            else
                this.Output.AppendText(s);

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Output.Clear();
        }
	}
}
