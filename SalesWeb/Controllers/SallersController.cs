using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Models;
using SalesWeb.Services;

namespace SalesWeb.Controllers
{
    public class SallersController : Controller
    {
        private readonly SallerServices _sallerServices;
       

        public SallersController (SallerServices sallerServices)
        {
            _sallerServices = sallerServices;
        }
        public IActionResult Index()
        {
            var list = _sallerServices.FindAll();
            return View(list);

        }

        public IActionResult Create()
        {
            return View();
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller saller)
        {
            _sallerServices.Insert(saller);
            return RedirectToAction(nameof(Index));
        }
    }
}