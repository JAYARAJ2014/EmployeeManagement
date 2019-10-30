using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee () {Id = 1, Name = "Jayaraj" , Department =DepartmentEnum.IT, Email = "jay.raj@gmail.com"},
                new Employee () {Id = 2, Name = "Manoj" , Department =DepartmentEnum.Finance, Email = "man.menon@gmail.com"},
                new Employee () {Id = 3, Name = "Vipin" , Department =DepartmentEnum.IT, Email = "vip.panic@gmail.com"},
                new Employee () {Id = 4, Name = "Anoop" , Department =DepartmentEnum.IT, Email = "anu.nair@gmail.com"},
                new Employee () {Id = 5, Name = "Mithun" , Department =DepartmentEnum.HR, Email = "m.o@gmail.com"},
                new Employee () {Id = 6, Name = "Prasad" , Department =DepartmentEnum.IT, Email = "masad.prani@gmail.com"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeList.AsEnumerable<Employee>();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
            }
            _employeeList.Remove(employee);
            return employee;
        }
    }
}