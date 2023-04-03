using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System_by_AKMH
{
    public class tbAccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public List<tbAccount> Accounts { get; set; }

    }
}
