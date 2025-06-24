using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS.Controller;
using UMS.View;

namespace UMS
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }
        private void signinbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signinform signinform = new Signinform();
            signinform.Show();
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = usernametxt.Text.Trim();
            string password = passwordtxt.Text;

            try
            {
                
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (LoginController.ValidateLogin(username, password, out string role))
                {
                    var profile = LoginController.GetUserProfile(username);
                    if (profile != null)
                    {
                        this.Hide();
                        MainDashboardForm dashboard = new MainDashboardForm(profile);
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Unable to load profile data. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    
                    MessageBox.Show("Incorrect username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("An error occurred during login:\n" + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
