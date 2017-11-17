using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LicensePlateApp.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LicensePlateApp.Controllers
{
    public class LicencePlateController : Controller
    {
        LicencePlateService LicencePlateService;

        public LicencePlateController(LicencePlateService licencePlateService)
        {
            LicencePlateService = licencePlateService;
        }
        [Route("")]
        public IActionResult Index()
        {
            return View(LicencePlateService.GetAllLicencePlates());
        }
        [HttpGet]
        [Route("/search")]
        public IActionResult Search(string licenceplate)
        {
            return View(LicencePlateService.CheckInputPlate(licenceplate));
        }
        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult Index(string brand)
        {
            return View(LicencePlateService.GetAllFromeSpecifiedBrand(brand));
        }
        [HttpGet]
        [Route("api/search/{brand}")]
        public IActionResult GetAllLicenceFromSpecifiedBrandInJson(string brand)
        {
            return Json(new { result = "ok", data = LicencePlateService.GetAllLicenceFromSpecifiedBrandJson(brand) });
        }
    }
}
