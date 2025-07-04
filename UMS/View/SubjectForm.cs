﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UMS.Controller;
using UMS.Model;

namespace UMS.View
{
    public partial class SubjectForm : Form
    {
        private readonly MainDashboardForm _mainDashboard;
        private readonly string _userRole;
        private int selectedSubjectId = -1;
        private Dictionary<int, string> courseMap;

        public SubjectForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _userRole = user.Role?.ToLower();

            LoadCoursesToComboBox();
            LoadSubjects();
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
                subjecttxt.Enabled = false;
                coursecombobox.Enabled = false;
            }
        }

        private void backpicturebox_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new CourseDashboardForm(_mainDashboard, new UserProfile { Role = _userRole }));
        }

        private void LoadCoursesToComboBox()
        {
            courseMap = SubjectController.GetCourseList();
            coursecombobox.Items.Clear();
            foreach (var pair in courseMap)
            {
                coursecombobox.Items.Add(pair.Value);
            }
        }

        private void LoadSubjects()
        {
            dgv.DataSource = null;
            dgv.DataSource = SubjectController.GetAllSubjects();
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(subjecttxt.Text) || coursecombobox.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter subject name and select a course.");
                return;
            }

            int courseId = GetSelectedCourseID();
            if (courseId == -1) return;

            var subject = new Subject
            {
                SubjectName = subjecttxt.Text.Trim(),
                CourseID = courseId
            };

            if (SubjectController.AddSubject(subject))
            {
                MessageBox.Show("Subject added successfully.");
                LoadSubjects();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add subject.");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject from the list to update.");
                return;
            }

            int courseId = GetSelectedCourseID();
            if (courseId == -1) return;

            var subject = new Subject
            {
                SubjectID = selectedSubjectId,
                SubjectName = subjecttxt.Text.Trim(),
                CourseID = courseId
            };

            if (SubjectController.UpdateSubject(subject))
            {
                MessageBox.Show("Subject updated.");
                LoadSubjects();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update subject.");
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this subject?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SubjectController.DeleteSubject(selectedSubjectId))
                {
                    MessageBox.Show("Subject deleted.");
                    LoadSubjects();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete subject.");
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
                selectedSubjectId = Convert.ToInt32(row.Cells["SubjectID"].Value);
                subjecttxt.Text = row.Cells["SubjectName"].Value.ToString();
                coursecombobox.SelectedItem = row.Cells["CourseName"].Value.ToString();
            }
        }

        private int GetSelectedCourseID()
        {
            string selectedCourse = coursecombobox.SelectedItem?.ToString();
            foreach (var pair in courseMap)
            {
                if (pair.Value == selectedCourse)
                    return pair.Key;
            }

            MessageBox.Show("Invalid course selected.");
            return -1;
        }

        private void ClearForm()
        {
            subjecttxt.Clear();
            coursecombobox.SelectedIndex = -1;
            selectedSubjectId = -1;
            dgv.ClearSelection();
        }
    }
}
