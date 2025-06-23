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
    public partial class CourseDashboardForm : Form
    {
        private readonly UserProfile _user;
        private MainDashboardForm _mainDashboard;
        public CourseDashboardForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _user = user;
        }

        private void coursebtn_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new CourseForm(_mainDashboard, _user));
        }

        private void subjectbtn_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new SubjectForm(_mainDashboard, _user));
        }
    }
}
