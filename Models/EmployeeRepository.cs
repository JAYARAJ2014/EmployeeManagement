using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
          
        }

        public Employee Add(Employee employee)
        {
              _context.Employees.Add(employee);
              _context.SaveChanges();
              return employee;
        }

        public Employee Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if(employee!=null) {

                _context.Employees.Remove(employee);
                _context.SaveChanges ();
            }
            return employee; 
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _context.Employees.Attach(updatedEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges ();

            return updatedEmployee;

        }
    }
}