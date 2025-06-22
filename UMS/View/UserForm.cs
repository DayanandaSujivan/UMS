using System;
using System.Windows.Forms;
using UMS.Controller;
using UMS.Model;

namespace UMS.View
{
    public partial class UserForm : Form
    {
        private CreateAdminHandleUserController controller = new CreateAdminHandleUserController();

        public UserForm()
        {
            InitializeComponent();
            LoadUsers();
            dgv.CellClick += userGridView_CellClick;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            var user = GetUserInput();
            if (user != null && controller.AddUser(user))
            {
                MessageBox.Show("User added successfully.");
                LoadUsers();
                ClearForm();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            var user = GetUserInput();
            if (user != null && controller.UpdateUser(user))
            {
                MessageBox.Show("User updated successfully.");
                LoadUsers();
                ClearForm();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(nictxt.Text.Trim(), out int nic) && controller.DeleteUser(nic))
            {
                MessageBox.Show("User deleted successfully.");
                LoadUsers();
                ClearForm();
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadUsers()
        {
            var users = controller.GetAllUsers();
            dgv.DataSource = null;
            dgv.DataSource = users;
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearForm()
        {
            nictxt.Clear();
            fullnametxt.Clear();
            phonetxt.Clear();
            emailtxt.Clear();
            addresstxt.Clear();
            dobtxt.Clear();
            adminradiobtn.Checked = false;
            staffradiobtn.Checked = false;
            studentradiobtn.Checked = false;
        }

        private CreateAdminHandleUser GetUserInput()
        {
            
            if (!int.TryParse(phonetxt.Text.Trim(), out int phone))
            {
                MessageBox.Show("Phone must be numeric.");
                return null;
            }

            string role = adminradiobtn.Checked ? "Admin"
                        : staffradiobtn.Checked ? "Staff"
                        : studentradiobtn.Checked ? "Student" : "";

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.");
                return null;
            }

            return new CreateAdminHandleUser
            {
                NIC = nictxt.Text.Trim(),
                FullName = fullnametxt.Text.Trim(),
                Phone = phone,
                Email = emailtxt.Text.Trim(),
                Address = addresstxt.Text.Trim(),
                DOB = dobtxt.Text.Trim(),
                Role = role,
                Status = "0"
            };
        }

        private void userGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv.Rows[e.RowIndex];
                nictxt.Text = row.Cells["NIC"].Value.ToString();
                fullnametxt.Text = row.Cells["FullName"].Value.ToString();
                phonetxt.Text = row.Cells["Phone"].Value.ToString();
                emailtxt.Text = row.Cells["Email"].Value.ToString();
                addresstxt.Text = row.Cells["Address"].Value.ToString();
                dobtxt.Text = row.Cells["DOB"].Value.ToString();

                string role = row.Cells["Role"].Value.ToString();
                adminradiobtn.Checked = role == "Admin";
                staffradiobtn.Checked = role == "Staff";
                studentradiobtn.Checked = role == "Student";
            }
        }
    }
}
