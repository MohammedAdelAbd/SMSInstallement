using Microsoft.EntityFrameworkCore;
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
    public partial class frmAccount : Form
    {
        DbSchool db = new DbSchool();
        
        int id;
        public frmAccount()
        {
            InitializeComponent();
            db = new DbSchool();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        //Load
        private void LoadData()
        {
            tbAccount tbAccount = new tbAccount();

            var accountTypes = db.AccountTypes.ToList();
            cmbAccountType.DisplayMember = "Name";
            cmbAccountType.ValueMember = "Id";
            cmbAccountType.DataSource = accountTypes;

            using (DbSchool db = new DbSchool())
            {
                var accounts = db.Accounts
                .Include(a => a.AccountType)
                .Select(a => new {
                    a.Id,
                    a.Code,
                    a.Balance,
                    a.Description,
                    a.CreatedDate,
                    a.LastModifiedDate,
                    IsActiveString = a.IsActiveString,
                    AccountTypeName = a.AccountType.Name
                })
                .ToList();

                dgvAccountTypes.DataSource = accounts;
            }
        }
        //Add
        private void btnAdd_Click(object sender, EventArgs e)
        {

            // Get selected Account Type Id
            int accountTypeId = (int)cmbAccountType.SelectedValue;

            if (id == 0)
            {
                // Create new Account
                var account = new tbAccount()
                {
                    Code = txtCode.Text,
                    Balance = nudBalance.Value,
                    Description = txtDescription.Text,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,

                    IsActived = chkIsActive.Checked,
                    AccountTypeId = accountTypeId // Set Account Type Id
                };

                // Add the new Account to the database
                db.Accounts.Add(account);
                db.SaveChanges();
                MessageBox.Show("تم اضافة الحساب");
                LoadData();
            }
            else
            {
                using(DbSchool db = new DbSchool())
                {
                    // Create new Account
                    tbAccount TbAccount = new tbAccount();

                    TbAccount.Code = txtCode.Text.Trim();
                    TbAccount.Balance = nudBalance.Value;
                    TbAccount.Description = txtDescription.Text.Trim();
                    TbAccount.CreatedDate = DateTime.Now;
                    TbAccount.LastModifiedDate = DateTime.Now;

                    TbAccount.IsActived = chkIsActive.Checked;
                    TbAccount.AccountTypeId = accountTypeId; // Set Account Type Id
                    TbAccount.Id = id;

                    // Add the new Account to the database
                    db.Accounts.Update(TbAccount);
                    db.SaveChanges();
                    MessageBox.Show("تم تحديث الحساب");
                    LoadData();
                }
                
            }
        }
        //Cell Double Click
        private void dgvAccountTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
            {
                
                    id = Convert.ToInt32(dgvAccountTypes.CurrentRow.Cells[0].Value);
                    using (var db = new DbSchool())
                    {
                        var Account = db.Accounts.Where(x => x.Id == id).FirstOrDefault();
                        if (Account != null)
                        {
                            txtCode.Text = Account.Code;
                            cmbAccountType.SelectedValue =Account.AccountTypeId;
                            nudBalance.Value = Account.Balance;
                            dtCreated.Value = Account.CreatedDate;
                            dtLastUpdate.Value = Account.LastModifiedDate;
                            chkIsActive.Checked = Account.IsActived;
                            txtDescription.Text = Account.Description;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
        
            }
        }
        //Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0)
                {
                    int accountTypeId = (int)cmbAccountType.SelectedValue;
                    using (DbSchool db = new DbSchool())
                    {
                        // Create new Account
                        tbAccount TbAccount = new tbAccount();

                        TbAccount.Code = txtCode.Text.Trim();
                        TbAccount.Balance = nudBalance.Value;
                        TbAccount.Description = txtDescription.Text.Trim();
                        TbAccount.CreatedDate = DateTime.Now;
                        TbAccount.LastModifiedDate = DateTime.Now;
                        TbAccount.IsActived = chkIsActive.Checked;
                        TbAccount.AccountTypeId = accountTypeId; // Set Account Type Id
                        TbAccount.Id = id;

                        // Add the new Account to the database
                        db.Accounts.Update(TbAccount);
                        db.SaveChanges();
                        MessageBox.Show("تم تعديل الحساب");
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("يرجى تحديد الصف المراد تعديله");
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
                    if (id != 0)
                    {
                    var MessOK = MessageBox.Show("هل انت متأكد من عملية الحذف", "تحذير", MessageBoxButtons.OK);
                    if (MessOK == DialogResult.OK)
                    {
                            int accountTypeId = (int)cmbAccountType.SelectedValue;
                            using (DbSchool db = new DbSchool())
                            {
                                // Create new Account
                                tbAccount TbAccount = new tbAccount();

                                TbAccount.Code = txtCode.Text.Trim();
                                TbAccount.Balance = nudBalance.Value;
                                TbAccount.Description = txtDescription.Text.Trim();
                                TbAccount.CreatedDate = DateTime.Now;
                                TbAccount.LastModifiedDate = DateTime.Now;
                                TbAccount.IsActived = chkIsActive.Checked;
                                TbAccount.AccountTypeId = accountTypeId; // Set Account Type Id
                                TbAccount.Id = id;

                                // Add the new Account to the database
                                db.Accounts.Remove(TbAccount);
                                db.SaveChanges();
                                LoadData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("يرجى تحديد الصف المراد حذفه");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
