using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System_by_AKMH
{
   public class tbStudents
    {
        public int id { get; set; }
        public string  stName { get; set; }
        public DateTime dateBirth { get; set; }
        public string  stGender { get; set; }
        public string  stClass  { get; set; }
        public string  stDivision { get; set; }
        public string  lastSchool { get; set; }
        public DateTime  dateRegistration { get; set; }
        public int stPhone { get; set; }
        public string  stAddress { get; set; }

        public List<tbAccountMovement> AccountMovements { get; set; }
    }
}
