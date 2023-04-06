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
    public class CennikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CennikController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cennik
        public async Task<IActionResult> Index()
        {
              return _context.Cennik != null ? 
                          View(await _context.Cennik.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cennik'  is null.");
        }

        // GET: Cennik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cennik == null)
            {
                return NotFound();
            }

            var cennik = await _context.Cennik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennik == null)
            {
                return NotFound();
            }

            return View(cennik);
        }

        // GET: Cennik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cennik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,Cena,CzyAktywny")] Cennik cennik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cennik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cennik);
        }

        // GET: Cennik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cennik == null)
            {
                return NotFound();
            }

            var cennik = await _context.Cennik.FindAsync(id);
            if (cennik == null)
            {
                return NotFound();
            }
            return View(cennik);
        }

        // POST: Cennik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,Cena,CzyAktywny")] Cennik cennik)
        {
            if (id != cennik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cennik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CennikExists(cennik.Id))
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
            return View(cennik);
        }

        // GET: Cennik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cennik == null)
            {
                return NotFound();
            }

            var cennik = await _context.Cennik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cennik == null)
            {
                return NotFound();
            }

            return View(cennik);
        }

        // POST: Cennik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cennik == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cennik'  is null.");
            }
            var cennik = await _context.Cennik.FindAsync(id);
            if (cennik != null)
            {
                _context.Cennik.Remove(cennik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CennikExists(int id)
        {
          return (_context.Cennik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
