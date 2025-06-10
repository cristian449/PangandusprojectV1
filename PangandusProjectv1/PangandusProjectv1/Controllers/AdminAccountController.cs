using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PangandusProjectv1.Models;

namespace PangandusProjectv1.Controllers
{
    [AllowAnonymous]


    //For logging in as Admin
    //Brooxsed@gmail.com
    //fssd!A2
    //adminseceretkey4321
    public class AdminAccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        private readonly IConfiguration _configuration;

        public AdminAccountController(
            UserManager<User> userManager,

            SignInManager<User> signInManager,

             RoleManager<IdentityRole<Guid>> roleManager,

            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View("~/Views/Admin/AdminRegister.cshtml");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(AdminRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.AdminSecretKey != _configuration["AdminSettings:AdminSecretKey"])
                {
                    ModelState.AddModelError("", "Invalid admin registration key");
                    return View("~/Views/Admin/AdminRegister.cshtml", model);
                }

                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = DateTime.Parse(model.DateOfBirth),
                    PhoneNumber = model.PhoneNumber,
                    IsAdministrator = true,
                    AdminSince = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("~/Views/Admin/AdminRegister.cshtml", model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Admin/AdminLogin.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null || !user.IsAdministrator)
                {
                    ModelState.AddModelError("", "Admin login attempt failed");
                    return View("~/Views/Admin/AdminLogin.cshtml", model);
                }

                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Invalid admin login attempt");
            }
            return View("~/Views/Admin/AdminLogin.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
