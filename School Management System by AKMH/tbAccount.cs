using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System_by_AKMH
{
    public class tbAccount
    {
        public int Id { get; set; }

        [Display(Name = "الرمز")]
        public string Code { get; set; }

        [Display(Name = "الرصيد")]
        public decimal Balance { get; set; }

        [Display(Name = "الوصف")]
        public string Description { get; set; }

        [Display(Name = "تاريخ الإنشاء")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "تاريخ آخر تعديل")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "نشط")]
        public bool IsActived { get; set; }

        [Display(Name = "نوع الحساب")]
        public int AccountTypeId { get; set; }

        public tbAccountType AccountType { get; set; }

        public List<tbAccountMovement> AccountMovements { get; set; }

        [NotMapped]
        public string IsActiveString
        {
            get => IsActived ? "نشط" : "غيرنشط";
            set => IsActived = value == "نشط";
        }
    }
}
