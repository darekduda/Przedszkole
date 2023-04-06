using Microsoft.AspNetCore.Mvc;
using Przedszkole.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleData.Data;
using PrzedszkoleData.Data.CMS;
using PrzedszkoleData.Data.Account;

namespace Przedszkole.Controllers
{
    public class HomeController : DbController
    {
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context) : base(logger, _context)
        {
        }

        public IActionResult Index()
        {
            WywolajViewBagi();
            return View();
        }
        public IActionResult ONas()
        {
            WywolajViewBagiONas();
            return View();
        }

        public IActionResult Zajecia()
        {
            WywolajViewBagiZajecia();
            return View();
        }

        public IActionResult Cennik()
        {
            WywolajViewBagiCennik();
            return View();
        }

        public IActionResult Kontakt()
        {
            WywolajViewBagiKontakt();
            return View();
        }
        public IActionResult Kadra()
        {
            WywolajViewBagiPersonel();
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