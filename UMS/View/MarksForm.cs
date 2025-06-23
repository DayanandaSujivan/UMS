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
    public partial class MarksForm : Form
    {
        private readonly MainDashboardForm _mainDashboard;
        private readonly string _userRole;
        public MarksForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _userRole = user.Role?.ToLower();
        }

        private void MarksForm_Load(object sender, EventArgs e)
        {

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
