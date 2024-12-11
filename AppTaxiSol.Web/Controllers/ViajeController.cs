using AppTaxiSol.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Web.Controllers
{
    public class ViajeController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<ViajeViewModel>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ViajeViewModel viaje)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        public IActionResult Edit(int id)
        {
            return View(new ViajeViewModel());
        }

        [HttpPost]
        public IActionResult Edit(ViajeViewModel viaje)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(viaje);
        }
    }
}
