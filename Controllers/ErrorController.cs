using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly Dictionary<int, string> codeMessageTable;
        public ErrorController()
        {
            codeMessageTable = new Dictionary<int, string>();
            codeMessageTable.Add(0, "Sorry! We dont know what you really mean");
            codeMessageTable.Add(404, "Sorry the resquested resource could not be found");
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            string message;
            ViewBag.ErrorMessage= (codeMessageTable.TryGetValue(statusCode, out message))?message:codeMessageTable[0];
            return View("NotFound");
        }


        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = ex.Path; 
            ViewBag.ExceptionMessage= ex.Error.Message;
            ViewBag.StackTrace = ex.Error.StackTrace;


            return View("Error");
        }
    }
}