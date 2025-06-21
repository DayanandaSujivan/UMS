using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UMS.Controller;
using UMS.Model;

namespace UMS
{
    public partial class Signinform : Form
    {
        private byte[] profilePicBytes = null;

        public Signinform()
        {
            InitializeComponent();
        }

        private void checkbtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(nictxt.Text, out int nic))
            {
                var adminData = LoginController.GetAdminApprovalByNIC(nic);
                if (adminData != null)
                {
                    fullnametxt.Text = adminData.FullName;
                    phonetxt.Text = adminData.phone.ToString();
                    emailtxt.Text = adminData.Email;
                    homeaddresstxt.Text = adminData.Address;
                    dobpicker.Text = adminData.DOB;
                    roletxt.Text = adminData.Role;
                    roletxt.Enabled = false;
                }
                else
                {
                    MessageBox.Show("NIC not found or already signed up.");
                }
            }
            else
            {
                MessageBox.Show("Invalid NIC format.");
            }
        }

        private void profilepicuploadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                /*profilepic.Image = img;
                profilepic.SizeMode = PictureBoxSizeMode.StretchImage;*/

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, img.RawFormat);
                    profilePicBytes = ms.ToArray();
                }
            }
        }

        private void signinbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernametxt.Text) || string.IsNullOrWhiteSpace(passwordtxt.Text))
            {
                MessageBox.Show("Username and Password are required.");
                return;
            }

            var adminData = LoginController.GetAdminApprovalByNIC(int.Parse(nictxt.Text));
            if (adminData == null)
            {
                MessageBox.Show("NIC not approved.");
                return;
            }

            bool registered = LoginController.RegisterUser(adminData, usernametxt.Text, passwordtxt.Text, profilePicBytes);
            if (registered)
            {
                MessageBox.Show("Registration successful!");
                this.Hide();
                new Loginform().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed.");
            }
        }

        private void loginlbl_Click(object sender, EventArgs e)
        {
            this.Close();
            new Loginform().ShowDialog();
        }
    }
}
