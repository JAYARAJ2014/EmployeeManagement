using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {


        // #This is the extension method used to avoid clutter inside AppDbContext OnModelCreating Method. All seeding has been moved here

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                            new Employee() { Id = 1, Name = "Jayaraj", Department = DepartmentEnum.IT, Email = "jay.raj@gmail.com" },
                           new Employee() { Id = 2, Name = "Manoj", Department = DepartmentEnum.Finance, Email = "man.menon@gmail.com" },
                           new Employee() { Id = 3, Name = "Vipin", Department = DepartmentEnum.IT, Email = "vip.panic@gmail.com" },
                           new Employee() { Id = 4, Name = "Anoop", Department = DepartmentEnum.IT, Email = "anu.nair@gmail.com" },
                           new Employee() { Id = 5, Name = "Mithun", Department = DepartmentEnum.HR, Email = "mithun.o@gmail.com" },
                           new Employee() { Id = 6, Name = "Prasad", Department = DepartmentEnum.IT, Email = "masad.prani@gmail.com" },
                           new Employee() { Id = 7, Name = "Priya", Department = DepartmentEnum.IT, Email = "pri.ya@gmail.com" }
                       );
        }
    }
}