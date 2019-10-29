using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cannot skip Name")]
        [MaxLength(20, ErrorMessage = "Not more than 20 chars")]
        public string Name { get; set; }
        public DepartmentEnum Department { get; set; }
        [Required(ErrorMessage = "Cannot skip email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        [Display(Name = "Email Id")]
        [MaxLength(255, ErrorMessage = "Not more than 255 chars")]
        public string Email { get; set; }
    }
}