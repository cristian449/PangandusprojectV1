using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PangandusProjectv1.Data;
using PangandusProjectv1.Models;

namespace PangandusProjectv1.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller

    {
        private readonly UserManager<User> _userManager;

        private readonly BankDbContext _context;

        private readonly ILogger<AdminController> _logger;

        public AdminController
            (
            UserManager<User> userManager,

            BankDbContext context,

            ILogger<AdminController> logger

            )
        {
            _userManager = userManager;

            _context = context;

            _logger = logger;
        }

        public async Task<IActionResult> AdminDashBoard()
        {
            var adminUser = await _userManager.GetUserAsync(User);
            if (adminUser == null || !adminUser.IsAdministrator)
            {
                return Forbid();

            }

            var model = new AdminDashBoardViewModel
            {
                AdminName = $"{adminUser.FirstName} {adminUser.LastName}",
                TotalUsers = await _userManager.Users.CountAsync(),
                
                ActiveUsersToday = await _userManager.Users
                    .Where(u => u.LastLoginDate >= DateTime.Today)
                    .CountAsync(),

                SystemLogsCount = await _context.Logs.CountAsync(),
                RecentUsers = await _userManager.Users
                    .OrderByDescending(u => u.DateJoined)
                    .Take(5)
                    .ToListAsync()   };



            return View("AdminDashboard", model);
        }

        public async Task<IActionResult> UserList()
        {

            var users = await _userManager.Users
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();

            return View(users);


        }
    }
}
