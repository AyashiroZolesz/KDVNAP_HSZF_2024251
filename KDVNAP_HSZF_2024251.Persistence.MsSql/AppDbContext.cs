using KDVNAP_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;

namespace KDVNAP_HSZF_2024251.Persistence.MsSql
{
    public class AppDbContext : DbContext
    {
        // Defining Tables
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // Base setting for the database, F.e.: set from "outer" code (Console project)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define Conenctions
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Factory)
                .WithMany(f => f.Departments)
                .HasForeignKey(d => d.Factory.Id);

            modelBuilder.Entity<Employee>() // N -> M connection, Many to many
                .HasMany(e => e.Departments)
                .WithMany(d => d.Employees);

            base.OnModelCreating(modelBuilder);

        }
    }
}
