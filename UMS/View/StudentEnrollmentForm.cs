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
using UMS.Model;

namespace UMS.View
{
    public partial class StudentEnrollmentForm : Form
    {
        private Dictionary<int, string> studentMap;
        private Dictionary<int, string> courseMap;
        private int selectedEnrollmentId = -1;

        public StudentEnrollmentForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadEnrollments();
            dgv.CellClick += dgv_CellClick;
        }

        private void LoadComboBoxes()
        {
            studentMap = StudentEnrollmentController.GetStudentList();
            studentcombobox.Items.Clear();
            foreach (var pair in studentMap)
                studentcombobox.Items.Add(pair.Value);

            courseMap = StudentEnrollmentController.GetCourseList();
            coursecombobox.Items.Clear();
            foreach (var pair in courseMap)
                coursecombobox.Items.Add(pair.Value);
        }

        private void LoadEnrollments()
        {
            dgv.DataSource = StudentEnrollmentController.GetAllEnrollments();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            int studentId = GetSelectedStudentId();
            int courseId = GetSelectedCourseId();

            if (studentId == -1 || courseId == -1)
            {
                MessageBox.Show("Please select both student and course.");
                return;
            }

            var enrollment = new StudentEnrollment
            {
                StudentID = studentId,
                CourseID = courseId,
                EnrollmentDate = DateTime.Now.ToString("yyyy-MM-dd")
            };

            if (StudentEnrollmentController.EnrollStudent(enrollment))
            {
                MessageBox.Show("Enrollment successful.");
                LoadEnrollments();
                ClearForm();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedEnrollmentId == -1)
            {
                MessageBox.Show("Please select an enrollment to update.");
                return;
            }

            int studentId = GetSelectedStudentId();
            int courseId = GetSelectedCourseId();

            if (studentId == -1 || courseId == -1) return;

            var enrollment = new StudentEnrollment
            {
                EnrollmentID = selectedEnrollmentId,
                StudentID = studentId,
                CourseID = courseId,
                EnrollmentDate = DateTime.Now.ToString("yyyy-MM-dd")
            };

            if (StudentEnrollmentController.UpdateEnrollment(enrollment))
            {
                MessageBox.Show("Enrollment updated.");
                LoadEnrollments();
                ClearForm();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedEnrollmentId == -1)
            {
                MessageBox.Show("Please select an enrollment to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (StudentEnrollmentController.DeleteEnrollment(selectedEnrollmentId))
                {
                    MessageBox.Show("Enrollment deleted.");
                    LoadEnrollments();
                    ClearForm();
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv.Rows[e.RowIndex];
                selectedEnrollmentId = Convert.ToInt32(row.Cells["EnrollmentID"].Value);
                studentcombobox.SelectedItem = row.Cells["StudentName"].Value.ToString();
                coursecombobox.SelectedItem = row.Cells["CourseName"].Value.ToString();
            }
        }

        private int GetSelectedStudentId()
        {
            string selected = studentcombobox.SelectedItem?.ToString();
            foreach (var pair in studentMap)
                if (pair.Value == selected)
                    return pair.Key;
            return -1;
        }

        private int GetSelectedCourseId()
        {
            string selected = coursecombobox.SelectedItem?.ToString();
            foreach (var pair in courseMap)
                if (pair.Value == selected)
                    return pair.Key;
            return -1;
        }

        private void ClearForm()
        {
            studentcombobox.SelectedIndex = -1;
            coursecombobox.SelectedIndex = -1;
            selectedEnrollmentId = -1;
            dgv.ClearSelection();
        }
    }
}
