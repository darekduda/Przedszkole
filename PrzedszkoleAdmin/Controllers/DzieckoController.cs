using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleAdmin.Models;
using PrzedszkoleData.Data;
using PrzedszkoleData.Data.Manage;

namespace PrzedszkoleAdmin.Controllers
{
    public class DzieckoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DzieckoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dziecko
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dziecko.Include(d => d.Grupa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dziecko/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dziecko == null)
            {
                return NotFound();
            }

            var dziecko = await _context.Dziecko
                .Include(d => d.Grupa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dziecko == null)
            {
                return NotFound();
            }

            return View(dziecko);
        }

        // GET: Dziecko/Create
        public IActionResult Create()
        {
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "Name");
            return View();
        }

        // POST: Dziecko/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,DataUrodzenia,CzyAktywny,GrupaId")] Dziecko dziecko)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dziecko);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "Name", dziecko.GrupaId);
            return View(dziecko);
        }

        // GET: Dziecko/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dziecko == null)
            {
                return NotFound();
            }

            var dziecko = await _context.Dziecko.FindAsync(id);
            if (dziecko == null)
            {
                return NotFound();
            }
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "Name", dziecko.GrupaId);
            return View(dziecko);
        }

        // POST: Dziecko/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,DataUrodzenia,CzyAktywny,GrupaId")] Dziecko dziecko)
        {
            if (id != dziecko.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dziecko);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DzieckoExists(dziecko.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "Name", dziecko.GrupaId);
            return View(dziecko);
        }

        // GET: Dziecko/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dziecko == null)
            {
                return NotFound();
            }

            var dziecko = await _context.Dziecko
                .Include(d => d.Grupa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dziecko == null)
            {
                return NotFound();
            }

            return View(dziecko);
        }

        // POST: Dziecko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dziecko == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dziecko'  is null.");
            }
            var dziecko = await _context.Dziecko.FindAsync(id);
            if (dziecko != null)
            {
                _context.Dziecko.Remove(dziecko);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Oplaty (int id, int rok, int miesiac)
        {
            var dziecko = _context.Dziecko.Include(d => d.Grupa).FirstOrDefault(d => d.Id == id);

            if (dziecko == null)
            {
                return NotFound();
            }

            var obecnosci = _context.Obecnosc
                .Where(o => o.DzieckoId == dziecko.Id && o.Data.Year == rok && o.Data.Month == miesiac)
                .ToList();

            int sumaObecnosci = obecnosci.Count(o => o.CzyObecne);

            var cennik2 = _context.Cennik.FirstOrDefault(c => c.Id == 2);
            if (cennik2 == null)
            {
                return NotFound();
            }

            var cennik1 = _context.Cennik.FirstOrDefault(c => c.Id == 1);
            if (cennik1 == null)
            {
                return NotFound();
            }

            decimal naleznosc = sumaObecnosci * cennik2.Cena.Value + cennik1.Cena.Value;
            decimal WyliczCeneObesnosci = sumaObecnosci * cennik2.Cena.Value;

            var viewModel = new NaleznoscViewModel
            {
                Dziecko = dziecko,
                Rok = rok,
                Miesiac = miesiac,
                SumaObecnosci = sumaObecnosci,
                CenaObecnosci = WyliczCeneObesnosci,
                CenaDodatkowa = cennik1.Cena.Value,
                Naleznosc = naleznosc
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ZapiszNaleznosci(int dzieckoId, int rok, int miesiac)
        {
            var dziecko = await _context.Dziecko.FindAsync(dzieckoId);

            if (dziecko == null)
            {
                return NotFound();
            }

            var obecnosci = _context.Obecnosc
                .Where(o => o.DzieckoId == dziecko.Id && o.Data.Year == rok && o.Data.Month == miesiac)
                .ToList();

            int sumaObecnosci = obecnosci.Count(o => o.CzyObecne);

            var cennik2 = _context.Cennik.FirstOrDefault(c => c.Id == 2);
            if (cennik2 == null)
            {
                return NotFound();
            }

            var cennik1 = _context.Cennik.FirstOrDefault(c => c.Id == 1);
            if (cennik1 == null)
            {
                return NotFound();
            }

            decimal naleznosc = sumaObecnosci * cennik2.Cena.Value + cennik1.Cena.Value;

            var naleznoscEntity = new Naleznosci
            {
                DzieckoId = dziecko.Id,
                Rok = rok,
                Miesiac = miesiac,
                Kwota = naleznosc
            };

            _context.Naleznosci.Add(naleznoscEntity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ListaObecnosci(int? id, DateTime? fromDate, DateTime? toDate)
        {
            if (id == null || _context.Dziecko == null)
            {
                return NotFound();
            }

            var dziecko = await _context.Dziecko
                .Include(d => d.Grupa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dziecko == null)
            {
                return NotFound();
            }

            var obecnosciQuery = _context.Obecnosc.Where(o => o.DzieckoId == dziecko.Id);

            if (fromDate != null)
            {
                obecnosciQuery = obecnosciQuery.Where(o => o.Data >= fromDate);
            }

            if (toDate != null)
            {
                obecnosciQuery = obecnosciQuery.Where(o => o.Data <= toDate);
            }

            var obecnosci = await obecnosciQuery.ToListAsync();

            var viewModel = new ListaObecnosciViewModel
            {
                Dziecko = dziecko,
                Obecnosci = obecnosci
            };

            ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
            ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

            return View(viewModel);
        }

        private bool DzieckoExists(int id)
        {
          return (_context.Dziecko?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
