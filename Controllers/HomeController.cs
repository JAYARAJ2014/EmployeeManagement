using System;
using System.IO;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IHostingEnvironment _environment;

        public HomeController(IEmployeeRepository repository, IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _environment = hostingEnvironment;
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
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = null;
                if (model.Photo!= null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                var newRow = _repository.Add(newEmployee);
                return RedirectToAction("details", new { id = newRow.Id });
            }
            return View();
        }

    }
}