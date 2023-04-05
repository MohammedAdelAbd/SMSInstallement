using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System_by_AKMH
{
    public class tbAccountMovement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } //Date of Transaction
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsReconciled { get; set; }
        public string ReconciledBy { get; set; }
        public DateTime? ReconciledDate { get; set; }


        public int StudentId { get; set; } 
        public tbStudents Student { get; set; }
        public int AccountId { get; set; }
        public tbAccount Account { get; set; }
    }
}
