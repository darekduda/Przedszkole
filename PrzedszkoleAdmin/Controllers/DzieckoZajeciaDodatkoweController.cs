using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleAdmin.Models;
using PrzedszkoleData.Data;
using PrzedszkoleData.Data.CMS;
using PrzedszkoleData.Data.Manage;

namespace PrzedszkoleAdmin.Controllers
{
    public class DzieckoZajeciaDodatkoweController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DzieckoZajeciaDodatkoweController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dzieci = _context.Dziecko.Include(d => d.ZajeciaDodatkowe).ToList();

            var viewModelList = new List<DzieckoZajeciaViewModel>();

            foreach (var dziecko in dzieci)
            {
                var viewModel = new DzieckoZajeciaViewModel
                {
                    DzieckoId = dziecko.Id,
                    Imie = dziecko.Imie,
                    Nazwisko = dziecko.Nazwisko,
                    PrzypisaneZajecia = dziecko.ZajeciaDodatkowe.Select(z => z.ZajeciaDodatkowe).ToList()
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }

        

        [HttpGet]
        public IActionResult PrzypiszZajeciaDodatkowe(int dzieckoId)
        {
            var dziecko = _context.Dziecko.Include(d => d.ZajeciaDodatkowe).FirstOrDefault(d => d.Id == dzieckoId);

            if (dziecko == null)
            {
                return NotFound();
            }

            var viewModel = new PrzypiszZajeciaDodatkoweViewModel
            {
                DzieckoId = dziecko.Id,
                Imie = dziecko.Imie,
                Nazwisko = dziecko.Nazwisko,
                DostepneZajecia = _context.ZajeciaDodatkowe.ToList(),
                WybraneZajecia = dziecko.ZajeciaDodatkowe.Select(z => z.ZajeciaDodatkoweId).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PrzypiszZajeciaDodatkowe(PrzypiszZajeciaDodatkoweViewModel viewModel)
        {
            var dziecko = _context.Dziecko.Include(d => d.ZajeciaDodatkowe).FirstOrDefault(d => d.Id == viewModel.DzieckoId);

            if (dziecko == null)
            {
                return NotFound();
            }

            // Usuwanie poprzednich przypisanych zajęć dla dziecka
            dziecko.ZajeciaDodatkowe.Clear();

            if (viewModel.WybraneZajecia != null)
            {
                // Dodawanie nowych przypisanych zajęć dla dziecka
                foreach (var zajecieId in viewModel.WybraneZajecia)
                {
                    var zajecie = _context.ZajeciaDodatkowe.Find(zajecieId);
                    if (zajecie != null)
                    {
                        dziecko.ZajeciaDodatkowe.Add(new DzieckoZajeciaDodatkowe
                        {
                            ZajeciaDodatkowe = zajecie,
                            Data = DateTime.Now // Ustawianie aktualnej daty
                        });
                    }
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult ListaDzieci()
        {
            List<Dziecko> dzieci = _context.Dziecko.OrderBy(d => d.Nazwisko).ToList();

            List<ListaDzieciViewModel> viewModelList = new List<ListaDzieciViewModel>();

            foreach (var dziecko in dzieci)
            {
                var przypisaneZajecia = _context.DzieckoZajeciaDodatkowe
                    .Where(dz => dz.DzieckoId == dziecko.Id)
                    .Select(dz => dz.ZajeciaDodatkowe)
                    .ToList();

                List<ZajeciaDodatkoweViewModel> przypisaneZajeciaViewModel = przypisaneZajecia
                    .Select(z => new ZajeciaDodatkoweViewModel
                    {
                        ZajecieId = z.Id,
                        Tytul = z.Tytul,
                        Opis = z.Opis,
                        Cena = z.Cena,
                    })
                    .ToList();

                decimal lacznyKosztZajec = przypisaneZajecia.Sum(z => z.Cena ?? 0); // Obliczanie łącznego kosztu zajęć

                ListaDzieciViewModel viewModel = new ListaDzieciViewModel
                {
                    DzieckoId = dziecko.Id,
                    Imie = dziecko.Imie,
                    Nazwisko = dziecko.Nazwisko,
                    PrzypisaneZajecia = przypisaneZajeciaViewModel,
                    LacznyKosztZajec = lacznyKosztZajec // Przypisanie wartości łącznego kosztu do właściwości
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }
    }
}


