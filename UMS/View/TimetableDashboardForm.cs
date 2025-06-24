using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS.Model;

namespace UMS.View
{
    public partial class TimetableDashboardForm : Form
    {

        private readonly UserProfile _user;
        private MainDashboardForm _mainDashboard;
        public TimetableDashboardForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _user = user;
            _mainDashboard = mainDashboard;
            if (_user.Role?.ToLower() == "student")
            {
                roombtn.Visible = false;
            }

        }

        private void roombtn_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new RoomForm(_mainDashboard, _user));
        }

        private void timetablebtn_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new TimetableForm(_mainDashboard, _user));
        }
    }
}
