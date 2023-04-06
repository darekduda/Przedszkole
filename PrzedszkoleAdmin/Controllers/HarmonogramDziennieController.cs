using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleData.Data;
using PrzedszkoleData.Data.CMS;

namespace PrzedszkoleAdmin.Controllers
{
    public class HarmonogramDziennieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HarmonogramDziennieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HarmonogramDziennie
        public async Task<IActionResult> Index()
        {
              return _context.HarmonogramDzienny != null ? 
                          View(await _context.HarmonogramDzienny.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HarmonogramDzienny'  is null.");
        }

        // GET: HarmonogramDziennie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HarmonogramDzienny == null)
            {
                return NotFound();
            }

            var harmonogramDzienny = await _context.HarmonogramDzienny
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harmonogramDzienny == null)
            {
                return NotFound();
            }

            return View(harmonogramDzienny);
        }

        // GET: HarmonogramDziennie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HarmonogramDziennie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,GodzinaRozpoczecia,GodzinaZakonczenia,CzyAktywny")] HarmonogramDzienny harmonogramDzienny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harmonogramDzienny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(harmonogramDzienny);
        }

        // GET: HarmonogramDziennie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HarmonogramDzienny == null)
            {
                return NotFound();
            }

            var harmonogramDzienny = await _context.HarmonogramDzienny.FindAsync(id);
            if (harmonogramDzienny == null)
            {
                return NotFound();
            }
            return View(harmonogramDzienny);
        }

        // POST: HarmonogramDziennie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,GodzinaRozpoczecia,GodzinaZakonczenia,CzyAktywny")] HarmonogramDzienny harmonogramDzienny)
        {
            if (id != harmonogramDzienny.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harmonogramDzienny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarmonogramDziennyExists(harmonogramDzienny.Id))
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
            return View(harmonogramDzienny);
        }

        // GET: HarmonogramDziennie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HarmonogramDzienny == null)
            {
                return NotFound();
            }

            var harmonogramDzienny = await _context.HarmonogramDzienny
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harmonogramDzienny == null)
            {
                return NotFound();
            }

            return View(harmonogramDzienny);
        }

        // POST: HarmonogramDziennie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HarmonogramDzienny == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HarmonogramDzienny'  is null.");
            }
            var harmonogramDzienny = await _context.HarmonogramDzienny.FindAsync(id);
            if (harmonogramDzienny != null)
            {
                _context.HarmonogramDzienny.Remove(harmonogramDzienny);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarmonogramDziennyExists(int id)
        {
          return (_context.HarmonogramDzienny?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
