using HrMatching_HW.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrMatching_HW.DbContexts
{
    class HrMatchingContext : DbContext
    {

        public HrMatchingContext()
            :base("Server=DESKTOP-CMJP8T1\\SQLEXPRESS;Database=HrMatching;Trusted_Connection=True;")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
