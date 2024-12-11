using AppTaxiSol.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<UsuarioViewModel>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Edit(int id)
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public IActionResult Edit(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
    }
}
