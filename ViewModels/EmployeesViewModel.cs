using System.Collections.Generic;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public string PageTitle { get; set; }
    }
}