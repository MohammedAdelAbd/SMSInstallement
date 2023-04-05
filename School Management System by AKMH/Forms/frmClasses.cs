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
    public partial class frmClasses : Form
    {
        DbSchool db;
        tbClasses add;
        int id;
        public frmClasses()
        {
            InitializeComponent();
            loadData();
        }

       private void loadData()
        {
            db = new DbSchool();
            dgv.DataSource = db.tbClasses.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClassName .Text !="" && txtPrice .Text !="" )
                {
                    db = new DbSchool();
                    add = new tbClasses();
                    add.className = txtClassName.Text.Trim();
                    add.price = Convert.ToInt32(txtPrice.Text.Trim());
                    db.tbClasses.Add(add);
                    db.SaveChanges();
                    loadData();
                    clearData();
                }
                else
                {
                    MessageBox.Show("قم بادخال كافة البيانات اولا","هناك خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearData()
        {
            txtClassName.Clear();
            txtPrice.Clear();
        }

        private void frmClasses_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnAdd;
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id= Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
            txtClassName.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            txtPrice.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClassName.Text != "" && txtPrice.Text != "")
                {
                    db = new DbSchool();
                    add = new tbClasses();
                    add=db.tbClasses.SingleOrDefault(x => x.id == id);
                    add.className = txtClassName.Text.Trim();
                    add.price = Convert.ToInt32(txtPrice.Text.Trim());
                    db.SaveChanges();
                    loadData();
                    clearData();
                }
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
                if (dgv .Rows .Count != 0)
                {
                    if (MessageBox.Show("هل انت متاكد من الحذف ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                        add = db.tbClasses.SingleOrDefault(x => x.id == id);
                        db.tbClasses.Remove(add);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClassName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
