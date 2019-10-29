using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public HomeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        [Route("/")]
        [Route("")]
        public ViewResult Index()
        {
            var employeeLIst = _repository.GetAll();
            var employeesViewModel = new EmployeesViewModel { Employees = employeeLIst, PageTitle = "All Employees" };
            return View(employeesViewModel);
        }
        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            var employee = _repository.GetEmployee(id ?? 1);
            var detailsViewModel = new DetailsViewModel { Employee = employee, PageTitle = $"Details of {employee.Name}" };
            return View(detailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid){

            var newEmployee = _repository.Add(employee);
            return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }

    }
}