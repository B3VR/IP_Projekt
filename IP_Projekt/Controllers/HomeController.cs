using IP_Projekt.DB.Models;
using IP_Projekt.DB.Repositories.DLoginRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IP_Projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDLoginRepository _iDLoginRepository;

        public HomeController(ILogger<HomeController> logger, IDLoginRepository iDLoginRepository)
        {
            _logger = logger;
            _iDLoginRepository = iDLoginRepository;
        }

        public IActionResult Index()
        {
            // przykład edytowania rekordu i wykorzystania repozytorium
            DLogin dLogin = new DLogin() {
                D_log = "test",
                D_pass = "test",
            };
            _iDLoginRepository.Update(1, dLogin);

            return View();
        }
        
        public IActionResult Rejestracja()
        {
            return View();
        }
    }
}