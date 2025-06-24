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
    public partial class RoomForm : Form
    {
        private readonly MainDashboardForm _mainDashboard;
        private readonly string _userRole;
        private int selectedRoomId = -1;

        public RoomForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _userRole = user.Role?.ToLower();
            LoadRooms();
            dgv.CellClick += Dgv_CellClick;
        }

        private void LoadRooms()
        {
            dgv.DataSource = null;
            dgv.DataSource = RoomController.GetAllRooms();
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roomnametxt.Text) || string.IsNullOrWhiteSpace(roomtypetxt.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            var room = new Room
            {
                RoomName = roomnametxt.Text.Trim(),
                RoomType = roomtypetxt.Text.Trim()
            };

            if (RoomController.AddRoom(room))
            {
                MessageBox.Show("Room added.");
                LoadRooms();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add room.");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Select a room to update.");
                return;
            }

            var room = new Room
            {
                RoomID = selectedRoomId,
                RoomName = roomnametxt.Text.Trim(),
                RoomType = roomtypetxt.Text.Trim()
            };

            if (RoomController.UpdateRoom(room))
            {
                MessageBox.Show("Room updated.");
                LoadRooms();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update room.");
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Select a room to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (RoomController.DeleteRoom(selectedRoomId))
                {
                    MessageBox.Show("Room deleted.");
                    LoadRooms();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete room.");
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
                selectedRoomId = Convert.ToInt32(row.Cells["RoomID"].Value);
                roomnametxt.Text = row.Cells["RoomName"].Value.ToString();
                roomtypetxt.Text = row.Cells["RoomType"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            roomnametxt.Clear();
            roomtypetxt.Clear();
            selectedRoomId = -1;
            dgv.ClearSelection();
        }

        private void backpicturebox_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new TimetableDashboardForm(_mainDashboard, new UserProfile { Role = _userRole }));
        }
    }
}
