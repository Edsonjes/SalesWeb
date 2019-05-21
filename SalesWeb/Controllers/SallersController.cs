using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Models;
using SalesWeb.Models.ViewModels;
using SalesWeb.Services;
using SalesWeb.Services.Excepitions;

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
            return RedirectToAction(nameof(Index)); 
        }
        public IActionResult Deteails( int? id)
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

        public IActionResult Edit(int? id)
        {
            if ( id == null)
            {
                return NotFound();
            }
            var obj = _sallerServices.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            List<Departament> departaments = _derpartamentService.FindAll();
            SallerFormViewModel viewModel = new SallerFormViewModel { Saller = obj, Departaments = departaments };
            return View(viewModel);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit (int id , Saller saller)
        {
            
            if(id != saller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sallerServices.Update(saller);
            return RedirectToAction(nameof(Index));
            }
            catch ( NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
                      
    }
}