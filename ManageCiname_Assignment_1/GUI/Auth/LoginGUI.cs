using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;

namespace Ciname.GUI.AuthControl
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
        
        private void login()
        {
            string username, password;
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            username = conf["User:Username"];
            password = conf["User:Password"];
            if (textBoxUsername.Text == username && textBoxPassword.Text == password)
            {
                Setting.Username = username;
                MessageBox.Show("You are logged in as administrator");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Don't have that user");
                this.DialogResult = DialogResult.None;
            }
        }

        private void LoginGUI_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
