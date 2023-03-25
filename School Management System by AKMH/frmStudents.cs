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
    public partial class frmStudents : Form
    {
        DbSchool db;
        tbStudents add;
        int id;
        public frmStudents()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            loadData();
            loadClass();
        }
        private void loadData()
        {
            db = new DbSchool();
            dgv.DataSource = db.tbStudents.ToList();
           
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnAdd;
        }

        private void loadClass()
        {
            db = new DbSchool();
            txtClass.DataSource = db.tbClasses.ToList();
            txtClass.DisplayMember = "className";
            txtClass.Invalidate();

            txtDivision.DataSource = db.tbDivisions.ToList();
            txtDivision.DisplayMember = "divisionName";
            txtDivision.Invalidate();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    db = new DbSchool();
                    add = new tbStudents();
                    add.stName = txtName.Text.Trim();
                    add.dateBirth = txtDateBirth.Value;
                    add.stGender = txtGender.Text.Trim();
                    add.stClass = txtClass.Text.Trim();
                    add.stDivision = txtDivision.Text.Trim();
                    add.lastSchool = txtLastSchool.Text.Trim();
                    add.dateRegistration = txtDataReg.Value;
                    add.stPhone = (int)Convert.ToInt64(txtPhone.Text.Trim());
                    add.stAddress = txtAddress.Text.Trim();
                    db.tbStudents.Add(add);
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

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                using (var db = new DbSchool())
                {
                    var student = db.tbStudents.Where(s => s.id == id).FirstOrDefault();
                    if (student != null)
                    {
                        txtName.Text = student.stName;
                        txtDateBirth.Value = student.dateBirth;
                        txtGender.Text = student.stGender;
                        txtClass.Text = student.stClass;
                        txtDivision.Text = student.stDivision;
                        txtLastSchool.Text = student.lastSchool;
                        txtDataReg.Value = student.dateRegistration;
                        txtPhone.Text = student.stPhone.ToString();
                        txtAddress.Text = student.stAddress;
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
                if (txtName.Text != "" )
                {
                    db = new DbSchool();
                    add = new tbStudents();
                    add = db.tbStudents.SingleOrDefault(x => x.id == id);
                    add.stName = txtName.Text.Trim();
                    add.dateBirth = txtDateBirth.Value;
                    add.stGender = txtGender.Text.Trim();
                    add.stClass = txtClass.Text.Trim();
                    add.stDivision = txtDivision.Text.Trim();
                    add.lastSchool = txtLastSchool.Text.Trim();
                    add.dateRegistration = txtDataReg.Value;
                    add.stPhone = (int)Convert.ToInt64(txtPhone.Text.Trim());
                    add.stAddress = txtAddress.Text.Trim();
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
            txtClass.Text = "";
            txtGender.Text = "";
            txtDivision.Text = "";
            txtPhone.Clear();
            txtAddress.Clear();
            txtLastSchool.Clear();
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
                        add = db.tbStudents.SingleOrDefault(x => x.id == id);
                        db.tbStudents.Remove(add);
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
