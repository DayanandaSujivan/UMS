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
            string username = usernametxt.Text;
            string password = passwordtxt.Text;

            if (LoginController.ValidateLogin(username, password, out string role))
            {
                var profile = LoginController.GetUserProfile(username);
                if (profile != null)
                {
                    this.Hide();
                    MainDashboardForm dashboard = new MainDashboardForm(profile); // ✅ pass profile
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Unable to load profile data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
