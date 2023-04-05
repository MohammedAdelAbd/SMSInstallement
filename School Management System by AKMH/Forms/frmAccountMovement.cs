using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management_System_by_AKMH
{
    public partial class frmAccountMovement : Form
    {
        DbSchool db = new DbSchool();
        public frmAccountMovement()
        {
            InitializeComponent();
        }

        private void LoadAccountMovement()
        {
            string searchName = cmbStudent.Text.Trim();
            string searchAcc = cmbStudent.Text.Trim();
            // Populate the student combo box
            var students = db.tbStudents.Where(s => s.stName.Contains(searchName)).ToList();
            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "stName";
            cmbStudent.ValueMember = "Id";

            // Populate the account combo box
            var accounts = db.Accounts.Where(s => s.Code.Contains(searchAcc)).ToList();
            cmbAccount.DataSource = accounts;
            cmbAccount.DisplayMember = "code";
            cmbAccount.ValueMember = "Id";
        }

        private void frmAccountMovement_Load(object sender, EventArgs e)
        {
            LoadAccountMovement();
        }
    }
}
