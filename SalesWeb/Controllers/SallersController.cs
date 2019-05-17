using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Models;
using SalesWeb.Models.ViewModels;
using SalesWeb.Services;

namespace SalesWeb.Controllers
{
    public class SallersController : Controller
    {
        private readonly SallerServices _sallerServices;
        private readonly DerpartamentService _derpartamentService;

        public SallersController (SallerServices sallerServices, DerpartamentService derpartamentService)
        {
            _sallerServices = sallerServices;
            _derpartamentService = derpartamentService;
        }
        public IActionResult Index()
        {
            var list = _sallerServices.FindAll();
            return View(list);

        }

        public IActionResult Create()
        {
            var departaments = _derpartamentService.FindAll();
            var viewModel = new SallerFormViewModel { Departaments = departaments };
            return View(viewModel);
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller saller)
        {
            _sallerServices.Insert(saller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sallerServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete( int id)
        {
            _sallerServices.Remove(id);
            return RedirectToAction(); 
        }
    }
}