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
    public partial class frmDivinsion : Form
    {
        DbSchool db;
        tbDivision add;
        public frmDivinsion()
        {
            InitializeComponent();
            loadData();
        }

        private void frmDivinsion_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnAdd;
        }

        private void loadData()
        {
            db = new DbSchool();
            dgv.DataSource = db.tbDivisions.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDivName.Text != "")
                {
                    db = new DbSchool();
                    add = new tbDivision ();
                    add.divisionName  = txtDivName.Text.Trim();
                    db.tbDivisions.Add(add);
                    db.SaveChanges();
                    loadData();
                    txtDivName.Clear();                }
                else
                {
                    MessageBox.Show("قم بادخال كافة البيانات اولا", "هناك خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.Rows.Count != 0)
                {
                    if (MessageBox.Show("هل انت متاكد من الحذف ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                        add = db.tbDivisions.SingleOrDefault(x => x.id == id);
                        db.tbDivisions.Remove(add);
                        db.SaveChanges();
                        loadData();
                    }
                }
                else
                {
                    MessageBox.Show("قم بتحديد الحقل اولا", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
