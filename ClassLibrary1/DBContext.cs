using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary1
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Faculty> Faculties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .Property(e => e.Full_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Faculty>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }
    }
}
