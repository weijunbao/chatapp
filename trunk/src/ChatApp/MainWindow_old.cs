using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class MainWindow_old : Form
    {
        public MainWindow_old()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(OnFormClosed);
        }

        void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public BuddyListController BuddyListController
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + AppController.Instance.CurrentUser.UserName;
            /*TreeNode node = new TreeNode("My root");
            this.tvgroups.Nodes.Add(node);
            TreeNode node11 = new TreeNode("sub1");
            node.Nodes.Add(node11);            */
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                LoginWindow loginWnd = new LoginWindow();
                this.Hide();
                loginWnd.Show();
            }
        }
    }
}