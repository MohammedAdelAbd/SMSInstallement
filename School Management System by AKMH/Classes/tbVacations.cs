using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System_by_AKMH
{
   public class tbVacations
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime Expiry { get; set; }
        public string Reason { get; set; }


        [NotMapped]
        public int sid { get; set; }
        [ForeignKey(nameof(sid))]
        public tbStudents tbStudents { get; set; }

    }
}
