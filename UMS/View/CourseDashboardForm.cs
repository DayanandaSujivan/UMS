using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS.View
{
    public partial class CourseDashboardForm : Form
    {
        private MainDashboardForm _mainDashboard;
        public CourseDashboardForm(MainDashboardForm mainDashboard)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
        }

        private void coursebtn_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new CourseForm(_mainDashboard));
        }
    }
}
