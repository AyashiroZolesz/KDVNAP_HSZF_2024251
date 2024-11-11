using KDVNAP_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KDVNAP_HSZF_2024251.Persistence.MsSql
{
    public class AppDbContext : DbContext
    {
        // Defining Tables
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured != true)
            {
                optionsBuilder.UseInMemoryDatabase("Company").UseLazyLoadingProxies();
            }
            base.OnConfiguring(optionsBuilder);
        }

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

            if (File.Exists("factories.json"))
            {
                try
                {
                    var factories = JsonConvert.DeserializeObject<Factory[]>(File.ReadAllText("factories.json"));
                    modelBuilder.Entity<Factory>().HasData(factories);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (File.Exists("employees.json"))
            {
                try
                {
                    var employees = JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText("employees.json"));
                    modelBuilder.Entity<Employee>().HasData(employees);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (File.Exists("departments.json"))
            {
                try
                {
                    var departments = JsonConvert.DeserializeObject<Department[]>(File.ReadAllText("departments.json"));
                    modelBuilder.Entity<Department>().HasData(departments);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
