using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS.Model;

namespace UMS.View
{
    public partial class MainDashboardForm : Form
    {
        private readonly UserProfile _user;

        // This constructor is used during login
        public MainDashboardForm(UserProfile user)
        {
            InitializeComponent();
            _user = user;
            SetupDashboard();
        }

        // This optional constructor is only useful for testing or Designer support
        public MainDashboardForm()
        {
            InitializeComponent();
            _user = new UserProfile { FullName = "Test User", Role = "student", ProfilePic = null };
            SetupDashboard();
        }

        private void SetupDashboard()
        {
            profilepiclable.Text = $"Hello, {_user.FullName}";

            if (_user.ProfilePic != null && _user.ProfilePic.Length > 0)
            {
                using (var ms = new MemoryStream(_user.ProfilePic))
                {
                    profilepictureBox.Image = Image.FromStream(ms);
                }
            }

            switch (_user.Role.ToLower())
            {
                case "admin":
                    EnableAdminFeatures();
                    break;
                case "student":
                    EnableStudentFeatures();
                    break;
                case "staff":
                    EnableStaffFeatures();
                    break;
                case "lecturer":
                    EnableLecturerFeatures();
                    break;
                default:
                    MessageBox.Show("Unknown role access.");
                    break;
            }
        }

        private void EnableAdminFeatures() { /* Enable all buttons */ }
        private void EnableStudentFeatures() { 
            userbtn.Enabled = false;
            coursebtn.Enabled = false;
            studentbtn.Enabled = false; 
        
        }
        private void EnableStaffFeatures() { /* Disable/manage staff view */ }
        private void EnableLecturerFeatures() { /* Disable/manage lecturer view */ }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            // Confirm logout (optional)
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Hide current dashboard
                this.Hide();

                // Show login form again
                Loginform login = new Loginform();
                login.Show();
                this.Close();
            }
        }
        public void LoadForm(object formObj)
        {
            if (mainpanel.Controls.Count > 0)
                mainpanel.Controls.RemoveAt(0);

            Form form = formObj as Form;
            if (form != null)
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                mainpanel.Controls.Add(form);
                mainpanel.Tag = form;
                form.Show();
            }
            else
            {
                MessageBox.Show("Invalid form object", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void settingbtn_Click(object sender, EventArgs e)
        {
            LoadForm(new SettingForm());
        }
    }

}
