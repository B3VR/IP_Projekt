﻿
using IP_Projekt.DB.Models;
using IP_Projekt.Views.Home.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace IP_Projekt.Controllers.AccountController
{
    public class AccountController : Controller
    {
        //--------------------------------------------
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        

        public AccountController(UserManager<User> userManager,
                                      SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            
        }
        //--------------------------------------------
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RejestracjaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View("~/Views/Home/Rejestracja.cshtml", model);
        }
        //--------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogowanieViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View("~/Views/Home/Index.cshtml", user);
        }
        //--------------------------------------------
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
        //--------------------------------------------

    }
}
