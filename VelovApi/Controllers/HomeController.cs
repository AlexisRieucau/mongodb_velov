using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VelovApi.Models;
using VelovApi.Services;

namespace VelovApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly VelovService _velovService;

        public HomeController(VelovService velovService)
        {
            _velovService = velovService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PushPins()
        {
            ViewData["Title"] = "Carte";
            var bdd = _velovService.Get();
            int nbPins = 0;// bdd.Count();

            foreach (var velo in bdd)
            {
                nbPins++;
                ViewData["pinLat(" + nbPins + ")"] = velo.properties.lattitude;
                ViewData["pinLong(" + nbPins + ")"] = velo.properties.longitude;
                ViewData["pinName(" + nbPins + ")"] = velo.properties.name;
                ViewData["pinAddress(" + nbPins + ")"] = velo.properties.address;
            }
            ViewData["nbPins"] = nbPins;
            ViewData["velov"] = bdd;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
