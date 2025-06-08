using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PangandusProjectv1.Models;

namespace PangandusProjectv1.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new DashboardViewModel
            {
                FullName = $"{user.FirstName} {user.LastName}",
                AccountBalance = user.AccountBalance,
                UserID = 15231251,
                Email = user.Email,
                MemberSince = user.DateOfBirth 
            };

            return View("~/Views/Account/Dashboard.cshtml", model);
        }
    }
}
