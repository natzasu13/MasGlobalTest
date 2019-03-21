namespace MasGlobalTest.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Cellphone)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Employee>()
                .Property(e => e.C_created)
                .IsFixedLength();

            modelBuilder.Entity<Salary>()
                .Property(e => e.Value)
                .HasPrecision(18, 0);
        }
    }
}
