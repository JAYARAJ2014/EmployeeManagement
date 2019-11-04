using System.Threading.Tasks;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    [Route("[controller]/[action]")]

    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = vm.Email, Email = vm.Email };
                var result = await _userManager.CreateAsync(user, vm.Password);

                if(result.Succeeded) {
                    await _signInManager.SignInAsync (user, isPersistent: false );
                    return RedirectToAction ("index", "home");
                }

                foreach(var error in result.Errors){
                    ModelState.AddModelError ("", error.Description);
                }
            }
            return View(vm);
        }
    }
}