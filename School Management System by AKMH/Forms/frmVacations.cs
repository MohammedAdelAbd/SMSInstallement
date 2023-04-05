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
    public partial class frmVacations : Form
    {
        DbSchool db;
        tbVacations add;
        int id,id2;
        string cls, div;
        public frmVacations()
        {
            InitializeComponent();
            dgv1.AutoGenerateColumns = false;
            dgv2.AutoGenerateColumns = false;
            loadData();
            loadCompoBox();
        }

        private void loadData()
        {
            try
            {
                db = new DbSchool();
                dgv2.DataSource = db.tbVacations.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadCompoBox()
        {
            db = new DbSchool();      
            comClass.DataSource = db.tbClasses.ToList();
            comClass.DisplayMember = "className";
            comClass.Invalidate();

            comDivisions.DataSource = db.tbDivisions.ToList();
            comDivisions.DisplayMember = "divisionName";
            comDivisions.Invalidate();
        }

        private void sort()
        {
            try
            {
                if (comClass.Text != "" && comDivisions.Text != "")
                {
                    using (db = new DbSchool())
                    {
                        dgv1.DataSource = db.tbStudents.Where(x => x.stClass.Contains(comClass.Text) && x.stDivision.Contains(comDivisions.Text) && x.State == false).ToList();
                    }
                }
                else
                {
                    //MessageBox.Show("الصف او الشعبة المدخل غير صالح او غير موجود","تنبية",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "لايمكن التصفية, هناك خطا");
            }
        }

        private void comClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort();
        }

        private void comDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    using (db = new DbSchool())
                    {
                        dgv1.DataSource = db.tbStudents.Where(x => x.stName.Contains(txtSearch.Text)).ToList();
                    }
                }
                else
                {
                    sort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgv1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgv1.CurrentRow.Cells[0].Value);
                using (var db = new DbSchool())
                {
                    var student = db.tbStudents.Where(s => s.id == id).FirstOrDefault();
                    if (student != null)
                    {
                        txtName.Text = student.stName;
                        cls = student.stClass;
                        div = student.stDivision;               
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    db = new DbSchool();
                    add = new tbVacations();
                    add.Name = txtName.Text.Trim();
                    add.Class  = cls;
                    add.Division  = div;
                    add.Type = txtType.Text;
                    add.Start = txtDateStart .Value.Date;
                    add.Expiry = txtDateExpiry.Value.Date;
                    add.Reason  = txtReason.Text.Trim();
                    add.sid = id ;
                    db.tbVacations.Add(add);
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
                if (dgv2.Rows.Count != 0)
                {
                    if (MessageBox.Show("هل انت متاكد من الحذف ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        id2 = Convert.ToInt32(dgv2.CurrentRow.Cells[0].Value);
                        add = db.tbVacations.SingleOrDefault(x => x.id == id2);
                        db.tbVacations.Remove(add);
                        db.SaveChanges();
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

        private void dgv2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                id2 = Convert.ToInt32(dgv2.CurrentRow.Cells[0].Value);
                using (var db = new DbSchool())
                {
                    var student = db.tbVacations.Where(s => s.id == id2).FirstOrDefault();
                    if (student != null)
                    {
                        txtName.Text = student.Name;
                        txtType.Text  = student.Type;
                        txtDateStart.Value  = student.Start;
                        txtDateExpiry.Value  = student.Expiry;
                        txtReason.Text = student.Reason;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    db = new DbSchool();
                    add = new tbVacations();
                    add = db.tbVacations.SingleOrDefault(x => x.id == id2);
                    add.Type = txtType.Text;
                    add.Start = txtDateStart.Value.Date;
                    add.Expiry = txtDateExpiry.Value.Date;
                    add.Reason = txtReason.Text.Trim();
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

        private void clearData()
        {
            txtName.Clear();
            txtType.Text = "";
            txtReason.Clear();        
        }

    }
}
