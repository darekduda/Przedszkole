using Microsoft.AspNetCore.Mvc;
using PrzedszkoleData.Data.Manage;
using PrzedszkoleData.Data;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleAdmin.Models;


namespace PrzedszkoleAdmin.Controllers
{
    public class ObecnoscController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObecnoscController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(DateTime data)
        {
            if (data == DateTime.MinValue)
            {
                data = DateTime.Now.Date;
            }

            var dzieci = _context.Dziecko.Include(d => d.Grupa)
                                         .Where(d => d.CzyAktywny)
                                         .OrderBy(d => d.Nazwisko  )
                                         .ToList();

            var obecnosc = _context.Obecnosc.Include(o => o.Dziecko)
                                                    .Where(o => o.Data == data)
                                                    .ToDictionary(o => o.DzieckoId, o => o.CzyObecne);

            var viewModel = new ObecnoscViewModel
            {
                Data = data,
                Dzieci = dzieci,
                Obecnosci = obecnosc
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Zapisz(DateTime data, Dictionary<int, bool> obecnosci)
        {
            foreach (var dziecko in _context.Dziecko)
            {
                var dzieckoId = dziecko.Id;
                var czyObecny = false;

                if (obecnosci.ContainsKey(dzieckoId))
                {
                    czyObecny = obecnosci[dzieckoId];
                }

                var obecnosc = _context.Obecnosc.FirstOrDefault(o => o.DzieckoId == dzieckoId && o.Data == data);

                if (obecnosc == null)
                {
                    obecnosc = new Obecnosc { DzieckoId = dzieckoId, Data = data };
                    _context.Obecnosc.Add(obecnosc);
                }

                obecnosc.CzyObecne = czyObecny;
            }

            _context.SaveChanges();

            TempData["Komunikat"] = "Obecność została zapisana.";

            return RedirectToAction("Index", new { data = data });
        }

        [HttpPost]
        public IActionResult Update(DateTime data, Dictionary<int, bool> obecnosci)
        {
            foreach (var dziecko in _context.Dziecko)
            {
                var dzieckoId = dziecko.Id;
                var czyObecny = false;

                if (obecnosci.ContainsKey(dzieckoId))
                {
                    czyObecny = obecnosci[dzieckoId];
                }

                var obecnosc = _context.Obecnosc.FirstOrDefault(o => o.DzieckoId == dzieckoId && o.Data == data);

                if (obecnosc == null)
                {
                    obecnosc = new Obecnosc { DzieckoId = dzieckoId, Data = data };
                    _context.Obecnosc.Add(obecnosc);
                }

                obecnosc.CzyObecne = czyObecny;
            }

            _context.SaveChanges();

            TempData["Komunikat"] = "Obecność została zaktualizowana.";

            return RedirectToAction("Index", new { data = data });
        }

        [HttpPost]
        public IActionResult Usun(DateTime data, int dzieckoId)
        {
            var obecnosc = _context.Obecnosc.FirstOrDefault(o => o.DzieckoId == dzieckoId && o.Data == data);
            if (obecnosc != null)
            {
                _context.Obecnosc.Remove(obecnosc);
                _context.SaveChanges();
                TempData["Komunikat"] = "Obecność została usunięta.";
            }
            else
            {
                TempData["Komunikat"] = "Nie znaleziono obecności do usunięcia.";
            }

            return RedirectToAction("Index", new { data = data });
        }

    }
}

