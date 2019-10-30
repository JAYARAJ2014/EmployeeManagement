using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage = "Cannot skip Name")]
        [MaxLength(20, ErrorMessage = "Not more than 20 chars")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please select a department from the list")]
        public DepartmentEnum? Department { get; set; }
        [Required(ErrorMessage = "Cannot skip email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        [Display(Name = "Email Id")]
        [MaxLength(255, ErrorMessage = "Not more than 255 chars")]
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
    }
}