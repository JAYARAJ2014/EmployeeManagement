using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                 new Employee() { Id = 1, Name = "Jayaraj", Department = DepartmentEnum.IT, Email = "jay.raj@gmail.com" },
                new Employee() { Id = 2, Name = "Manoj", Department = DepartmentEnum.Finance, Email = "man.menon@gmail.com" },
                new Employee() { Id = 3, Name = "Vipin", Department = DepartmentEnum.IT, Email = "vip.panic@gmail.com" },
                new Employee() { Id = 4, Name = "Anoop", Department = DepartmentEnum.IT, Email = "anu.nair@gmail.com" },
                new Employee() { Id = 5, Name = "Mithun", Department = DepartmentEnum.HR, Email = "m.o@gmail.com" },
                new Employee() { Id = 6, Name = "Prasad", Department = DepartmentEnum.IT, Email = "masad.prani@gmail.com" }
            );
        }
        public DbSet<Employee> Employees { get; set; }
    }
}