namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DepartmentEnum Department { get; set; }
        public string Email { get; internal set; }
    }
}