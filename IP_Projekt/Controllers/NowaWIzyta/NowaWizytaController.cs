using IP_Projekt.DB;
using IP_Projekt.DB.Models;
using IP_Projekt.DB.Models.Enums;
using IP_Projekt.DB.Repositories.WizytaRepositories;
using IP_Projekt.Views.NowaWizyta.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace IP_Projekt.Controllers.NowaWIzyta
{
    public class NowaWizytaController : Controller
    {
        private readonly IWizytaRepository _wizytaRepository;
        private readonly UserManager<User> _userManager;
        private readonly IpprojContext _ipprojContext;

        public NowaWizytaController(IWizytaRepository wizytaRepository, UserManager<User> userManager, IpprojContext ipprojContext)
        {
            _wizytaRepository = wizytaRepository;
            _userManager = userManager;
            _ipprojContext = ipprojContext;
        }

        public IActionResult Index()
        {
            List<User> lekarze = _ipprojContext.users.Where(x => x.Typ == user_type.lekarz).ToList();
            ViewBag.listaLekarzy = lekarze;

            return View("/Views/NowaWizyta/NowaWizytaView.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> zapiszWizyte(NowaWizytaViewModel model)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            User? user = await _userManager.FindByIdAsync(currentUserName);

            User lekarz = await _ipprojContext.users.FindAsync(model.lekarzId);

            Wizyta wizyta = new Wizyta()
            {
                lekarzId = model.lekarzId,
                patientName = user.UserName,
                doctorName = lekarz.UserName,
                pacjentId = user.Id,
                opisObjawow = model.opisObjawow,
                data = model.dataWizyty,
                status = statusWizytyEnum.nieRozpoczeta
            };

            _wizytaRepository.Add(wizyta);
                    
            return RedirectToAction("Welcome", "Home");
        }
    }
}
