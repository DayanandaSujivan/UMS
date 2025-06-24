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

    public partial class MarksForm : Form
    {
        private readonly MainDashboardForm _mainDashboard;
        private readonly string _userRole;
        private Dictionary<int, string> studentMap;
        private Dictionary<int, string> examMap;
        private int selectedMarkId = -1;

        public MarksForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _userRole = user.Role?.ToLower();

            if (_userRole == "student")
            {
                ApplyStudentRestrictions(user);
            }
            else
            {
                LoadStudents();
                LoadMarks();
            }

            LoadExams();
            dgv.CellClick += Dgv_CellClick;
        }

        private void LoadStudents()
        {
            studentMap = MarkController.GetStudentList();
            studentnamecombobox.Items.Clear();
            foreach (var s in studentMap)
                studentnamecombobox.Items.Add(s.Value);
        }

        private void LoadExams()
        {
            examMap = MarkController.GetExamList();
            examidcombobox.Items.Clear();
            foreach (var e in examMap)
                examidcombobox.Items.Add(e.Value);
        }

        private void LoadMarks()
        {
            dgv.DataSource = null;
            dgv.DataSource = MarkController.GetAllMarks();
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private int GetSelectedStudentID()
        {
            string name = studentnamecombobox.SelectedItem?.ToString();
            return studentMap.FirstOrDefault(x => x.Value == name).Key;
        }

        private int GetSelectedExamID()
        {
            string name = examidcombobox.SelectedItem?.ToString();
            return examMap.FirstOrDefault(x => x.Value == name).Key;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (studentnamecombobox.SelectedIndex == -1 || examidcombobox.SelectedIndex == -1 || !int.TryParse(markstxt.Text, out int score))
            {
                MessageBox.Show("Select student, exam and enter valid score.");
                return;
            }

            var mark = new Mark
            {
                StudentID = GetSelectedStudentID(),
                ExamID = GetSelectedExamID(),
                Score = score
            };

            if (MarkController.AddMark(mark))
            {
                MessageBox.Show("Mark added.");
                LoadMarks();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add mark.");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == -1)
            {
                MessageBox.Show("Select a mark to update.");
                return;
            }

            var mark = new Mark
            {
                MarkID = selectedMarkId,
                StudentID = GetSelectedStudentID(),
                ExamID = GetSelectedExamID(),
                Score = int.Parse(markstxt.Text)
            };

            if (MarkController.UpdateMark(mark))
            {
                MessageBox.Show("Mark updated.");
                LoadMarks();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update mark.");
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == -1)
            {
                MessageBox.Show("Select a mark to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MarkController.DeleteMark(selectedMarkId))
                {
                    MessageBox.Show("Mark deleted.");
                    LoadMarks();
                    ClearForm();
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv.Rows[e.RowIndex];
                selectedMarkId = Convert.ToInt32(row.Cells["MarkID"].Value);
                studentnamecombobox.SelectedItem = row.Cells["StudentName"].Value.ToString();
                examidcombobox.SelectedItem = row.Cells["ExamName"].Value.ToString();
                markstxt.Text = row.Cells["Score"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            studentnamecombobox.SelectedIndex = -1;
            examidcombobox.SelectedIndex = -1;
            markstxt.Clear();
            selectedMarkId = -1;
            dgv.ClearSelection();
        }

        private void backpicturebox_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new ExamDashboardForm(_mainDashboard, new UserProfile { Role = _userRole }));
        }

        private void ApplyStudentRestrictions(UserProfile user)
        {
            
            addbtn.Enabled = false;
            updatebtn.Enabled = false;
            deletebtn.Enabled = false;
            clearbtn.Enabled = false;

            studentnamecombobox.Enabled = false;
            examidcombobox.Enabled = false;
            markstxt.ReadOnly = true;

            
            int studentId = MarkController.GetStudentIdByUserId(user.UserID);
            if (studentId != -1)
            {
                var allStudents = MarkController.GetStudentList();
                string studentName = allStudents.ContainsKey(studentId) ? allStudents[studentId] : "You";

                studentMap = new Dictionary<int, string> { { studentId, studentName } };
                studentnamecombobox.Items.Clear();
                studentnamecombobox.Items.Add(studentName);
                studentnamecombobox.SelectedIndex = 0;

                LoadMarksForStudent(studentId);
            }
            else
            {
                MessageBox.Show("Student record not found.");
            }
        }

        private void LoadMarksForStudent(int studentId)
        {
            dgv.DataSource = null;
            dgv.DataSource = MarkController.GetMarksByStudentID(studentId);
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

}
