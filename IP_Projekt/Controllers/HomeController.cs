using IP_Projekt.DB.Models;
using IP_Projekt.DB.Repositories.ChatRepositories;
using IP_Projekt.DB.Repositories.DLoginRepositories;
using IP_Projekt.Views.Home.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace IP_Projekt.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rejestracja()
        {
            return View();
        }

        public async Task<IActionResult> Welcome()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            User? user = await _userManager.FindByIdAsync(currentUserName);

            WelcomeViewModel model = new WelcomeViewModel()
            {
                currentUser = user
            };

            return View(model);
        }

        public IActionResult Welcome2()
        {
            return View();
        }

        public IActionResult Funkcje()
        {
            return View();
        }

    }
}