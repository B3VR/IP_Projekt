
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
        public void Bag(User user)
        {
            TempData["UserName"] = user.UserName;
        }

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
                    UserName = model.FirstName +' ' + model.LastName,
                    Email = model.Email,
                };
                


                var result = await _userManager.CreateAsync(user, model.Password);

                //if (model.loc_typ == "lekarz")  { user.Typ = user_type.lekarz; }
                //if (model.loc_typ == "pacjent") { user.Typ = user_type.pacjent; }
                user.Typ = user_type.pacjent;
                await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //return RedirectToAction("index", "Home");
                    Bag(user);

                    if(user.Typ == user_type.administrator) { return RedirectToAction("Welcome2", "Home");}
                    else
                    { return RedirectToAction("Welcome", "Home"); }
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
            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogowanieViewModel user)
        {
            if (ModelState.IsValid)
            {

                //var user2 = await _userManager.FindByEmailAsync(user.Email);
                //var result = await _userManager.CreateAsync(user2, user.Password);

                //if (result.Succeeded)
                //{
                //    await _signInManager.SignInAsync(user2, isPersistent: false);

                //    return RedirectToAction("index", "Home");
                //}

                //var user2 = _signInManager.UserManager.Users.Where(u=>u.Email == user.Email).FirstOrDefault();
                var user2 = await _userManager.FindByEmailAsync(user.Email);
                var result = await _signInManager.PasswordSignInAsync(user2.UserName, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    Bag(user2);

                    if (user2.Typ == user_type.administrator) { return RedirectToAction("Welcome2", "Home"); }
                    else
                    { return RedirectToAction("Welcome", "Home"); }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View("~/Views/Home/Index.cshtml", user);
        }
        //--------------------------------------------
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
        //--------------------------------------------
        public async Task<IActionResult> Zmiana(WelcomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (model.loc_typ == "lekarz") { user.Typ = user_type.lekarz; }
                if (model.loc_typ == "pacjent") { user.Typ = user_type.pacjent; }

                await _userManager.UpdateAsync(user);
                return RedirectToAction("Welcome2", "Home");

                ModelState.AddModelError(string.Empty, "Podaj adres email i wybierz funkcję.");
            }
            return RedirectToAction("Funkcje", "Home");
        }

    }
}
