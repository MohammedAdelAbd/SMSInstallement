using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System_by_AKMH
{
   public class DbSchool :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DbSchool;Integrated Security=True");
        }
        public DbSet <tbClasses>  tbClasses { get; set; }
        public DbSet<tbDivision> tbDivisions { get; set; }
        public DbSet <tbStudents> tbStudents { get; set; }
        public DbSet<tbAccountType> AccountTypes { get; set; }
        public DbSet<tbAccount> Accounts { get; set; }
    }
}
