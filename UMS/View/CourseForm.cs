using System;
using System.Windows.Forms;
using UMS.Controller;
using UMS.Model;

namespace UMS.View
{
    public partial class CourseForm : Form
    {
        private readonly MainDashboardForm _mainDashboard;
        private readonly string _userRole;
        private int selectedCourseId = -1;

        public CourseForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _userRole = user.Role?.ToLower();

            LoadCourses();
            dgv.CellClick += dgv_CellClick;
            ApplyRoleRestrictions();
        }

        private void ApplyRoleRestrictions()
        {
            if (_userRole != "admin")
            {
                addbtn.Enabled = false;
                updatebtn.Enabled = false;
                deletebtn.Enabled = false;
                clearbtn.Enabled = false;
                coursetxt.Enabled = false;
            }
        }

        private void backpicturebox_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new CourseDashboardForm(_mainDashboard, new UserProfile { Role = _userRole }));
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(coursetxt.Text))
            {
                MessageBox.Show("Please enter a course name.");
                return;
            }

            var course = new Course { CourseName = coursetxt.Text.Trim() };

            if (CourseController.AddCourse(course))
            {
                MessageBox.Show("Course added successfully.");
                LoadCourses();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add course.");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course from the list to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(coursetxt.Text))
            {
                MessageBox.Show("Course name cannot be empty.");
                return;
            }

            var course = new Course
            {
                CourseID = selectedCourseId,
                CourseName = coursetxt.Text.Trim()
            };

            if (CourseController.UpdateCourse(course))
            {
                MessageBox.Show("Course updated successfully.");
                LoadCourses();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update course.");
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (CourseController.DeleteCourse(selectedCourseId))
                {
                    MessageBox.Show("Course deleted successfully.");
                    LoadCourses();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete course.");
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadCourses()
        {
            var courses = CourseController.GetAllCourses();
            dgv.DataSource = null;
            dgv.DataSource = courses;
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv.Rows[e.RowIndex];
                selectedCourseId = Convert.ToInt32(row.Cells["CourseID"].Value);
                coursetxt.Text = row.Cells["CourseName"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            coursetxt.Clear();
            selectedCourseId = -1;
            dgv.ClearSelection();
        }
    }
}
