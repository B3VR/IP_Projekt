using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using IP_Projekt.DB.Models;

namespace IP_Projekt.Controllers.ListaBadan
{
    public class ListaBadanController : Controller
    {

        private static IList<Badania> Listabadan = new List<Badania>()

        {
            new Badania(){BadanieId=1,Nazwa="USG",Lekarz="Dr. Kowalski",Pacjent="Jan Nowak",Godzina="13:45",Sala="001",Opis="USG jamy brzusznej", Done=false},
            new Badania(){BadanieId=2,Nazwa="MR",Lekarz="Dr. Marciniak",Pacjent="Adam Miller",Godzina="14:15",Sala="123",Opis="MR głowy", Done=false}
        };
        // GET: ListaBadanController
        public ActionResult Index()
        {
            return View(Listabadan.Where(x => !x.Done));
        }

        // GET: ListaBadanController/Details/5
        public ActionResult Details(int id)
        {
            return View(Listabadan.FirstOrDefault(x => x.BadanieId == id));
        }

        // GET: ListaBadanController/Create
        public ActionResult Create()
        {
            return View(new Badania());
        }

        // POST: ListaBadanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Badania badanieModel)
        {
            badanieModel.BadanieId = Listabadan.Count + 1;
            Listabadan.Add(badanieModel);
                return RedirectToAction(nameof(Index));
        }

        // GET: ListaBadanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Listabadan.FirstOrDefault(x => x.BadanieId == id));
        }

        // POST: ListaBadanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Badania badanieModel)
        {
            Badania badanie = Listabadan.FirstOrDefault(x => x.BadanieId == id);
            badanie.Nazwa = badanieModel.Nazwa;
            badanie.Sala = badanieModel.Sala;
            badanie.Lekarz = badanieModel.Lekarz;
            badanie.Godzina = badanieModel.Godzina;
            badanie.Opis = badanieModel.Opis;
            return RedirectToAction(nameof(Index));
            
           
        }

        // GET: ListaBadanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Listabadan.FirstOrDefault(x => x.BadanieId == id));
        }

        // POST: ListaBadanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Badania badanieModel)
        {
            Badania badanie = Listabadan.FirstOrDefault(x => x.BadanieId == id);
            Listabadan.Remove(badanie);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Done(int id)
        {
            Badania badanie = Listabadan.FirstOrDefault(x => x.BadanieId == id);
            badanie.Done = true;
            return RedirectToAction(nameof(Index));
        }
    }
}
