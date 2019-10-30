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
            var employee = _repository.GetEmployee(id.Value);
            if(employee==null){
                Response.StatusCode =404;
                return View("EmployeeNotFound", id.Value);
            }

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

                string uniqueFileName = ProcessUploadedFile(model);
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

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var employee = _repository.GetEmployee(id);
            var editViewModel = new EditEmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {

            if (ModelState.IsValid)
            {
                var employee = _repository.GetEmployee(model.Id);
                employee.Id = model.Id;
                employee.Name = model.Name;
                employee.Department = model.Department;
                employee.Email = model.Email;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string path = Path.Combine(_environment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(path);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                var updatedEmployee = _repository.Update(employee);
                return RedirectToAction("index");
            };
            return View();
        }

        private string ProcessUploadedFile(CreateEmployeeViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileSream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileSream);
                }
            }

            return uniqueFileName;
        }
    }
}