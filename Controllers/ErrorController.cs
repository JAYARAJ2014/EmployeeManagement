using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {

        private readonly Dictionary<int, string> codeMessageTable;
        private ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
            codeMessageTable = new Dictionary<int, string>();
            codeMessageTable.Add(0, "Sorry! We dont know what you really mean");
            codeMessageTable.Add(404, "Sorry the resquested resource could not be found");
        }
        
            
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            //   string message;

            //   ViewBag.ErrorMessage = (codeMessageTable.TryGetValue(statusCode, out message)) ? message : codeMessageTable[0];

            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    _logger.LogWarning($"404 Error. Path = {statusCodeResult.OriginalPath} and QueryString= {statusCodeResult.OriginalQueryString}");
                    ViewBag.ErrorMessage = "Sorry the resquested resource could not be found";
                    break;
            }
            return View("NotFound");
        }


        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            _logger.LogError("Exception handler is used. But I am confused about the view");
            var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = ex.Path;
            ViewBag.ExceptionMessage = ex.Error.Message;
            ViewBag.StackTrace = ex.Error.StackTrace;
            _logger.LogError($"The Path {ex.Path} threw an exception. \n {ex.Error.Message} \n {ex.Error.StackTrace}");

            return View("Error");
        }
    }
}