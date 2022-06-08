using IP_Projekt.DB.Models;
using IP_Projekt.DB.Repositories.DLoginRepositories;
using Microsoft.AspNetCore.Mvc;

namespace IP_Projekt.Controllers.Pulpit
{
    public class PulpitController : Controller
    {
        private readonly IDLoginRepository _dLoginRepository;

        public PulpitController(IDLoginRepository dLoginRepository)
        {
            _dLoginRepository = dLoginRepository;
        }
        
        public IActionResult Pulpit()
        {
            return View();
        }
    }
}
