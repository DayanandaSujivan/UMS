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
    public partial class TimetableForm : Form
    {

        private readonly MainDashboardForm _mainDashboard;
        private readonly string _userRole;
        private Dictionary<int, string> subjectMap;
        private Dictionary<int, string> roomMap;
        private int selectedTimetableId = -1;
        public TimetableForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _userRole = user.Role?.ToLower();
            ApplyRoleRestrictions();
            LoadSubjects();
            LoadRooms();
            LoadTimetables();
            dgv.CellClick += dgv_CellClick;
        }

        private void ApplyRoleRestrictions()
        {
            if (_userRole != "admin")
            {
                addbtn.Enabled = false;
                updatebtn.Enabled = false;
                deletebtn.Enabled = false;
                clearbtn.Enabled = false;
                subjectnamecombobox.Enabled = false;
                roomnamecombobox.Enabled = false;
                datetimepicker.Enabled = false;
            }
        }

        private void LoadSubjects()
        {
            subjectMap = TimetableController.GetSubjectList();
            subjectnamecombobox.Items.Clear();
            foreach (var item in subjectMap.Values)
                subjectnamecombobox.Items.Add(item);
        }

        private void LoadRooms()
        {
            roomMap = TimetableController.GetRoomList();
            roomnamecombobox.Items.Clear();
            foreach (var item in roomMap.Values)
                roomnamecombobox.Items.Add(item);
        }

        private void LoadTimetables()
        {
            dgv.DataSource = null;
            dgv.DataSource = TimetableController.GetAllTimetables();
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void backpicturebox_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new TimetableDashboardForm(_mainDashboard, new UserProfile { Role = _userRole }));
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (subjectnamecombobox.SelectedIndex == -1 || roomnamecombobox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(timetxt.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            string timeSlot = $"{datetimepicker.Value:yyyy-MM-dd} {timetxt.Text}";

            var timetable = new Timetable
            {
                SubjectID = subjectMap.First(x => x.Value == subjectnamecombobox.SelectedItem.ToString()).Key,
                RoomID = roomMap.First(x => x.Value == roomnamecombobox.SelectedItem.ToString()).Key,
                TimeSlot = timeSlot
            };

            if (TimetableController.AddTimetable(timetable))
            {
                MessageBox.Show("Timetable added.");
                LoadTimetables();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add timetable.");
            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId == -1)
            {
                MessageBox.Show("Select a timetable to update.");
                return;
            }

            string timeSlot = $"{datetimepicker.Value:yyyy-MM-dd} {timetxt.Text}";

            var timetable = new Timetable
            {
                TimetableID = selectedTimetableId,
                SubjectID = subjectMap.First(x => x.Value == subjectnamecombobox.SelectedItem.ToString()).Key,
                RoomID = roomMap.First(x => x.Value == roomnamecombobox.SelectedItem.ToString()).Key,
                TimeSlot = timeSlot
            };

            if (TimetableController.UpdateTimetable(timetable))
            {
                MessageBox.Show("Timetable updated.");
                LoadTimetables();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update.");
            }

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId == -1)
            {
                MessageBox.Show("Select a timetable to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (TimetableController.DeleteTimetable(selectedTimetableId))
                {
                    MessageBox.Show("Timetable deleted.");
                    LoadTimetables();
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
                selectedTimetableId = Convert.ToInt32(row.Cells["TimetableID"].Value);
                subjectnamecombobox.SelectedItem = row.Cells["SubjectName"].Value.ToString();
                roomnamecombobox.SelectedItem = row.Cells["RoomName"].Value.ToString();

                string[] dateTime = row.Cells["TimeSlot"].Value.ToString().Split(' ');
                datetimepicker.Value = DateTime.Parse(dateTime[0]);
                timetxt.Text = dateTime.Length > 1 ? dateTime[1] : "";
            }
        }

        private void ClearForm()
        {
            subjectnamecombobox.SelectedIndex = -1;
            roomnamecombobox.SelectedIndex = -1;
            datetimepicker.Value = DateTime.Now;
            timetxt.Clear();
            selectedTimetableId = -1;
            dgv.ClearSelection();
        }

    }
}
