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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnClassAndDiv_Click(object sender, EventArgs e)
        {
            if (pan1.Size == new Size(230, 10))
            {
                pan1.Size = new Size(230, 87);
            }
            else
            {
                pan1.Size = new Size(230, 10);
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            var frm = new frmClasses();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(frm);    
            frm.Show();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            var frm = new frmDivinsion();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new frmStudents();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void btn_Accounts_Click(object sender, EventArgs e)
        {
            if (pn_Account.Size == new Size(230, 10))
            {
                pn_Account.Size = new Size(230, 193);
            }
            else
            {
                pn_Account.Size = new Size(230, 10);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //frmMain frmMain = new frmMain();
            //var frm = new frmAccountType();
            //if (frmMain.WindowState == FormWindowState.Maximized)
            //{
            //    frm.TopLevel = false;
            //    frm.WindowState = FormWindowState.Maximized;
            //    frm.Anchor = AnchorStyles.None;
            //    pnlMain.Controls.Add(frm);
            //    frm.Show();
            //}
            //else if(frmMain.WindowState == FormWindowState.Normal)
            //{
            //    frm.TopLevel = false;
            //    frm.WindowState = FormWindowState.Normal;
            //    frm.Anchor = AnchorStyles.None;
            //    pnlMain.Controls.Add(frm);
            //    frm.Show();
            //}
            var frm = new frmAccountType();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new frmAccount();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(frm);
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new frmAccountMovement();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(frm);
            frm.Show();
        }
    }
}
