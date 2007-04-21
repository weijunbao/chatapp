namespace ChatApp
{
    partial class HiddenWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
              

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HiddenWindow));
            this.TrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayMenuStrip
            // 
            this.TrayMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuItemShow,
            this.toolStripSeparator1,
            this.MnuItemExit});
            this.TrayMenuStrip.Name = "TrayMenuStrip";
            this.TrayMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TrayMenuStrip.ShowImageMargin = false;
            this.TrayMenuStrip.Size = new System.Drawing.Size(86, 54);
            // 
            // MnuItemShow
            // 
            this.MnuItemShow.Name = "MnuItemShow";
            this.MnuItemShow.Size = new System.Drawing.Size(85, 22);
            this.MnuItemShow.Text = "Show";
            this.MnuItemShow.Click += new System.EventHandler(this.MnuItemShow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(82, 6);
            // 
            // MnuItemExit
            // 
            this.MnuItemExit.Name = "MnuItemExit";
            this.MnuItemExit.Size = new System.Drawing.Size(85, 22);
            this.MnuItemExit.Text = "Exit";
            this.MnuItemExit.Click += new System.EventHandler(this.MnuItemExit_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenuStrip;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "TrayIcon";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // HiddenWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(10000, 10000);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HiddenWindow";
            this.ShowInTaskbar = false;
            this.TrayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuItemShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuItemExit;
        private System.Windows.Forms.NotifyIcon TrayIcon;
    }
}