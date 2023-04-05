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
        private bool isFormLoaded = false;

        public frmStudents()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }
    
        private void frmStudents_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnAdd;
            loadCompoBox();
            txtClass.Text = "";
            txtDivision.Text = "";
            isFormLoaded = true;
        }

        private void loadCompoBox()
        {
            db = new DbSchool();
            txtClass.DataSource = db.tbClasses.ToList();
            txtClass.DisplayMember = "className";
            txtClass.Invalidate();

            comClass.DataSource = db.tbClasses.ToList();
            comClass.DisplayMember = "className";
            comClass.Invalidate();

            txtDivision.DataSource = db.tbDivisions.ToList();
            txtDivision.DisplayMember = "divisionName";
            txtDivision.Invalidate();

            comDivisions.DataSource = db.tbDivisions.ToList();
            comDivisions.DisplayMember = "divisionName";
            comDivisions.Invalidate();
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
                    add.dateBirth = txtDateBirth.Value.Date ;
                    add.stGender = txtGender.Text.Trim();
                    add.stClass = txtClass.Text.Trim();
                    add.stDivision = txtDivision.Text.Trim();
                    add.lastSchool = txtLastSchool.Text.Trim();
                    add.dateRegistration = txtDataReg.Value.Date;
                    add.stPhone = (int)Convert.ToInt64(txtPhone.Text.Trim());
                    add.stAddress = txtAddress.Text.Trim();
                    add.State = false;
                    db.tbStudents.Add(add);
                    db.SaveChanges();
                    sort();
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
                    add.dateBirth = txtDateBirth.Value.Date;
                    add.stGender = txtGender.Text.Trim();
                    add.stClass = txtClass.Text.Trim();
                    add.stDivision = txtDivision.Text.Trim();
                    add.lastSchool = txtLastSchool.Text.Trim();
                    add.dateRegistration = txtDataReg.Value.Date;
                    add.stPhone = (int)Convert.ToInt64(txtPhone.Text.Trim());
                    add.stAddress = txtAddress.Text.Trim();
                    add.State = false;
                    db.SaveChanges();
                    sort();
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
            txtDateBirth.Value = DateTime.Now;
            txtDataReg.Value = DateTime.Now;
        }
     
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    using (db = new DbSchool())
                    {
                        dgv.DataSource = db.tbStudents.Where(x => x.stName.Contains(txtSearch.Text)).ToList();
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

        private void sort()
        {
            try
            {
                if (comClass.Text != "" && comDivisions.Text != "")
                {
                    using (db = new DbSchool())
                    {
                        dgv.DataSource = db.tbStudents.Where(x => x.stClass.Contains(comClass.Text) && x.stDivision.Contains(comDivisions.Text) && x.State == false ).ToList();
                    }
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message ,"لايمكن التصفية, هناك خطا");
            }
        }

        private void comClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort();
            dgvCount();
        }

        private void comDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort();
            dgvCount();
        }


        private void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.Rows.Count != 0)
                {
                    if (MessageBox.Show("هل انت متاكد من الحذف ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db = new DbSchool();
                        add = new tbStudents();
                        int id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                        add = db.tbStudents.SingleOrDefault(x => x.id == id);
                        add.State = true;
                        db.SaveChanges();
                        sort();
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


        private void txtDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoaded)
            {
                cheackDivCount();
            }
        }

        private void cheackDivCount()
        {
            try
            {
                if (txtClass.Text != "")
                {
                    db = new DbSchool();
                    var student = db.tbDivisions.Where(s => s.divisionName == txtDivision.Text.Trim()).FirstOrDefault();
                    int divCount = student.studentNum;

                    string division = txtDivision.Text.Trim();
                    string className = txtClass.Text.Trim();
                    int count = db.tbStudents.Count(s => s.stDivision.Equals(division, StringComparison.OrdinalIgnoreCase)
                                                        && s.stClass.Equals(className, StringComparison.OrdinalIgnoreCase)
                                                        && s.State == false);
                    if (count >= divCount)
                    {
                        MessageBox.Show($"الشعبة التي قمت بتحديدها ممتالة, عدد الطلبة في هذة الشعبة:{count}", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCount()
        {
            int rowCount = dgv.RowCount;
            txtClassCount.Text = rowCount.ToString();
        }
    }
}
