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
    public class KontaktController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KontaktController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kontakt
        public async Task<IActionResult> Index()
        {
              return _context.Kontakt != null ? 
                          View(await _context.Kontakt.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Kontakt'  is null.");
        }

        // GET: Kontakt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kontakt == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }

        // GET: Kontakt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kontakt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TytułKontakt,NumerTelefonu,NazwaTelefonu,CzyAktywny")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontakt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontakt);
        }

        // GET: Kontakt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kontakt == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakt.FindAsync(id);
            if (kontakt == null)
            {
                return NotFound();
            }
            return View(kontakt);
        }

        // POST: Kontakt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TytułKontakt,NumerTelefonu,NazwaTelefonu,CzyAktywny")] Kontakt kontakt)
        {
            if (id != kontakt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontakt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontaktExists(kontakt.Id))
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
            return View(kontakt);
        }

        // GET: Kontakt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kontakt == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }

        // POST: Kontakt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kontakt == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kontakt'  is null.");
            }
            var kontakt = await _context.Kontakt.FindAsync(id);
            if (kontakt != null)
            {
                _context.Kontakt.Remove(kontakt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontaktExists(int id)
        {
          return (_context.Kontakt?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
