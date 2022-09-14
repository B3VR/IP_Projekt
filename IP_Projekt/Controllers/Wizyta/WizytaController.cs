using IP_Projekt.DB;
using IP_Projekt.DB.Models;
using IP_Projekt.DB.Repositories.WizytaRepositories;
using IP_Projekt.Views.Home.ViewModels;
using IP_Projekt.Views.Wizyta.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IP_Projekt.Controllers.NewFolder
{
    public class WizytaController : Controller
    {
        private IpprojContext _ipprojContext;
        private readonly UserManager<User> _userManager;
        private readonly IWizytaRepository _wizytaRepository;
        public WizytaController(IWizytaRepository wizytaRepository, UserManager<User> userManager, IpprojContext ipprojContext)
        {
            _wizytaRepository = wizytaRepository;
            _userManager = userManager;
            _ipprojContext = ipprojContext;
        }

        [HttpGet]
        public async Task<IActionResult> WizytaAsync(int id)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            User? user = await _userManager.FindByIdAsync(currentUserName);

            _wizytaRepository.rozpocznijWizyte(id);
            Wizyta wizyta = _wizytaRepository.pobierzWizyte(id);

            WizytaViewModel model = new WizytaViewModel()
            {
                wizyta = wizyta,
                Opis = wizyta.opisObjawow,
                wizyta_id = wizyta.id
            };

            model.user = user;

            return View(model);
        }

        public async Task<IActionResult> MojeWizytyAsync()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            User? user = await _userManager.FindByIdAsync(currentUserName);

            MojeWizytyViewModel model = new MojeWizytyViewModel();

            if (user != null)
            {
                if (user.Typ.Equals(user_type.lekarz))
                {
                    model.wizyty = _wizytaRepository.pobierzWizytyLekarza(user.Id).ToList();
                }
                else if (user.Typ.Equals(user_type.pacjent))
                {
                    model.wizyty = _wizytaRepository.pobierzWizytyPacjenta(user.Id).ToList();
                }
                model.currentUser = user;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult zakonczWizyte(WizytaViewModel model)
        {
            _wizytaRepository.zamknijWizyte(model.wizyta_id);

            RezultatWizyty rezultat = new RezultatWizyty()
            {
                wizytaId = model.wizyta_id,
                przebiegWizyty = model.Przebieg_wizyty,
                przepisaneLeki = model.Przepisane_leki,
                stwierdzonaChorobaId = model.Stwierdzona_choroba 
            };

            _ipprojContext.Add(rezultat);
            _ipprojContext.SaveChanges();

            return RedirectToAction("Welcome", "Home");
        }
    }
}
