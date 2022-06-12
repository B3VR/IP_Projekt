using IP_Projekt.DB.Models;
using IP_Projekt.DB.Repositories.ChatRepositories;
using IP_Projekt.DB.Repositories.DLoginRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IP_Projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDLoginRepository _iDLoginRepository;
        private readonly IChatRepository _chatRepository;

        public HomeController(ILogger<HomeController> logger, IDLoginRepository iDLoginRepository, IChatRepository chatRepository)
        {
            _logger = logger;
            _iDLoginRepository = iDLoginRepository;
            _chatRepository = chatRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Rejestracja()
        {
            return View();
        }
    }
}