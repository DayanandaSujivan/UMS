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
    public partial class SettingForm : Form
    {
        private readonly UserProfile _user;
        public SettingForm(UserProfile user)
        {
            InitializeComponent();
            _user = user;
        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    profilepicturebox.Image = Image.FromFile(dialog.FileName);
                }
            }

        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            if (_user != null)
            {
                fullnametxt.Text = _user.FullName;
                niclbl.Text = _user.NIC.ToString();
                phonetxt.Text = _user.Phone.ToString();
                emailtxt.Text = _user.Email;
                addresstxt.Text = _user.Address;
                doblbl.Text = _user.DOB;
                rolelbl.Text = _user.Role;
                usernametxt.Text = _user.Username;
                passwordtxt.Text = _user.Password;

                
                if (_user.ProfilePic != null && _user.ProfilePic.Length > 0)
                {
                    using (var ms = new MemoryStream(_user.ProfilePic))
                    {
                        profilepicturebox.Image = Image.FromStream(ms);
                    }
                }
            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                _user.FullName = fullnametxt.Text.Trim();
                _user.Phone = int.TryParse(phonetxt.Text.Trim(), out int phone) ? phone : 0;
                _user.Email = emailtxt.Text.Trim();
                _user.Address = addresstxt.Text.Trim();
                _user.Username = usernametxt.Text.Trim();
                _user.Password = passwordtxt.Text.Trim();

                
                if (profilepicturebox.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        profilepicturebox.Image.Save(ms, profilepicturebox.Image.RawFormat);
                        _user.ProfilePic = ms.ToArray();
                    }
                }

                bool success = UMS.Controller.UserProfileController.UpdateUserProfile(_user);
                if (success)
                {
                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
