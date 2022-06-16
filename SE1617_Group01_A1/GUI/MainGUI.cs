using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ciname.GUI.AuthControl;
using Ciname.GUI.ShowControl;

namespace Ciname.GUI
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginGUI loginGUI = new LoginGUI();
            DialogResult dialogResult = loginGUI.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                loginToolStripMenuItem.Click -= loginToolStripMenuItem_Click;
                loginToolStripMenuItem.Click += btnLogout_Click;
            }
        }

        private void MainGUI_Activated(object sender, EventArgs e)
        {
            if(Setting.Username != null)
            {
                loginToolStripMenuItem.Text = $"Logout ({Setting.Username})";
                this.showToolStripMenuItem.Visible = true;
            }
            else
            {
                this.showToolStripMenuItem.Visible = false;
                loginToolStripMenuItem.Text = "Login";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Setting.Username = null;
            loginToolStripMenuItem.Text = "Login";
            loginToolStripMenuItem.Click += loginToolStripMenuItem_Click;
            loginToolStripMenuItem.Click -= btnLogout_Click;
            toolStripContainer1.ContentPanel.Controls.Clear();
            MessageBox.Show("You are logged out!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGUI showGUI = new ShowGUI();
            showGUI.FormBorderStyle = FormBorderStyle.None;
            showGUI.TopLevel = false;
            showGUI.Show();
            toolStripContainer1.ContentPanel.Width = showGUI.Width;
            toolStripContainer1.ContentPanel.Height = showGUI.Height;
            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(showGUI);
            this.Width = toolStripContainer1.Width;
            this.Height = toolStripContainer1.Height + menuStrip.Height + toolStripContainer1.BottomToolStripPanel.Height + toolStripContainer1.TopToolStripPanel.Height - 10;
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
