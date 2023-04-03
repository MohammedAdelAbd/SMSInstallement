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
    public partial class frmAccountType : Form
    {
        DbSchool db = new DbSchool();
        int id;
        public frmAccountType()
        {
            InitializeComponent();
            db = new DbSchool();
        }
        //Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAccountType.Text == "")
                {
                    MessageBox.Show("يرجى ادخال اسم صنف الحساب", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var accountType = new tbAccountType
                    {
                        Name = txtAccountType.Text.Trim(),
                        Description = txtAccountDesc.Text.Trim()
                    };
                    db.AccountTypes.Add(accountType);
                    db.SaveChanges();
                    MessageBox.Show("تم اضافة صنف حساب جديد!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtAccountType.Text = "";
                    txtAccountDesc.Text = "";
                    LoadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        //Function Load Data
        private void LoadData()
        {
            using (DbSchool db = new DbSchool())
            {
                var accountTypes = db.AccountTypes.ToList();
                dgvAccountTypes.DataSource = accountTypes;
            }
        }
        //Load
        private void frmAccountType_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        //Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvAccountTypes.CurrentRow.Cells[0].Value);
                if (txtAccountType.Text != "" && id != null)
                {
                    using (var db = new DbSchool())
                    {
                        var AccountType = db.AccountTypes.Where(x => x.Id == id).FirstOrDefault();
                        if (AccountType != null)
                        {
                            AccountType.Name = txtAccountType.Text.Trim();
                            AccountType.Description = txtAccountDesc.Text.Trim();
                            db.AccountTypes.Update(AccountType);
                            db.SaveChanges();
                            MessageBox.Show("تم التعديل الصنف بنجاح");
                            txtAccountType.Text = "";
                            txtAccountDesc.Text = "";
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("يرجى تحديد الصنف");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Cell Double Click Event
        private void dgvAccountTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvAccountTypes.CurrentRow.Cells[0].Value);
                using (var db = new DbSchool())
                {
                    var AccountType = db.AccountTypes.Where(x => x.Id == id).FirstOrDefault();
                    if (AccountType != null)
                    {
                        txtAccountType.Text = AccountType.Name;
                        txtAccountDesc.Text = AccountType.Description;
                        
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //TextChange Event To Search Account Type Name
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (db = new DbSchool())
            {
                if (txtSearch.Text == "")
                {

                }
                else
                {
                    var _Search = txtSearch.Text.Trim();
                    dgvAccountTypes.DataSource = db.AccountTypes.Where(x => x.Name.Contains(_Search)).ToList();
                }
            }  
        }
        //Search
        private void btn_Search_Click(object sender, EventArgs e)
        {
            using (db = new DbSchool())
            {
                if (txtSearch.Text == "")
                {

                }
                else
                {
                    var _Search = txtSearch.Text.Trim();
                    dgvAccountTypes.DataSource = db.AccountTypes.Where(x => x.Name.Contains(_Search)).ToList();
                }
            }
        }
        //Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvAccountTypes.CurrentRow.Cells[0].Value);
                if (txtAccountType.Text != "" && id != null)
                {
                    using (var db = new DbSchool())
                    {
                        var AccountType = db.AccountTypes.Where(x => x.Id == id).FirstOrDefault();
                        if (AccountType != null)
                        {
                            db.AccountTypes.Remove(AccountType);
                            db.SaveChanges();
                            MessageBox.Show("تم حذف الصنف بنجاح");
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("يرجى تحديد الصنف");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
