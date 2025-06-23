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

    public partial class ExamForm : Form
    {
        private readonly MainDashboardForm _mainDashboard;
        private readonly string _userRole;
        private Dictionary<int, string> subjectMap;
        private int selectedExamId = -1;

        public ExamForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _userRole = user.Role?.ToLower();

            LoadSubjectsToComboBox();
            LoadExams();
            dgv.CellClick += dgv_CellClick;
        }

        private void backpicturebox_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new ExamDashboardForm(_mainDashboard, new UserProfile { Role = _userRole }));
        }

        private void LoadSubjectsToComboBox()
        {
            subjectMap = ExamController.GetSubjectList();
            subjectcombobox.Items.Clear();
            foreach (var item in subjectMap)
                subjectcombobox.Items.Add(item.Value);
        }

        private void LoadExams()
        {
            dgv.DataSource = null;
            dgv.DataSource = ExamController.GetAllExams();
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(examtxt.Text) || subjectcombobox.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter exam name and select subject.");
                return;
            }

            var exam = new Exam
            {
                ExamName = examtxt.Text.Trim(),
                SubjectID = GetSelectedSubjectID()
            };

            if (ExamController.AddExam(exam))
            {
                MessageBox.Show("Exam added.");
                LoadExams();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add exam.");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an exam to update.");
                return;
            }

            var exam = new Exam
            {
                ExamID = selectedExamId,
                ExamName = examtxt.Text.Trim(),
                SubjectID = GetSelectedSubjectID()
            };

            if (ExamController.UpdateExam(exam))
            {
                MessageBox.Show("Exam updated.");
                LoadExams();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update exam.");
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an exam to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure to delete this exam?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ExamController.DeleteExam(selectedExamId))
                {
                    MessageBox.Show("Exam deleted.");
                    LoadExams();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete exam.");
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
                selectedExamId = Convert.ToInt32(row.Cells["ExamID"].Value);
                examtxt.Text = row.Cells["ExamName"].Value.ToString();
                subjectcombobox.SelectedItem = row.Cells["SubjectName"].Value.ToString();
            }
        }

        private int GetSelectedSubjectID()
        {
            string selectedSubject = subjectcombobox.SelectedItem?.ToString();
            foreach (var pair in subjectMap)
            {
                if (pair.Value == selectedSubject)
                    return pair.Key;
            }

            MessageBox.Show("Invalid subject selected.");
            return -1;
        }

        private void ClearForm()
        {
            examtxt.Clear();
            subjectcombobox.SelectedIndex = -1;
            selectedExamId = -1;
            dgv.ClearSelection();
        }
    }

}
