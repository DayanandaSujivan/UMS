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
    public partial class ExamDashboardForm : Form
    {
        private readonly UserProfile _user;
        private MainDashboardForm _mainDashboard;
        public ExamDashboardForm(MainDashboardForm mainDashboard, UserProfile user)
        {
            InitializeComponent();
            _mainDashboard = mainDashboard;
            _user = user;
        }

        private void exambtn_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new ExamForm(_mainDashboard, _user));
        }

        private void markbtn_Click(object sender, EventArgs e)
        {
            _mainDashboard.LoadForm(new MarksForm(_mainDashboard, _user));
        }
    }
}
