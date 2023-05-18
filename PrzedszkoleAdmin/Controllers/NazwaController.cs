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
    public class NazwaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NazwaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nazwa
        public async Task<IActionResult> Index()
        {
              return _context.Nazwa != null ? 
                          View(await _context.Nazwa.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Nazwa'  is null.");
        }

        // GET: Nazwa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nazwa == null)
            {
                return NotFound();
            }

            var nazwa = await _context.Nazwa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nazwa == null)
            {
                return NotFound();
            }

            return View(nazwa);
        }

        // GET: Nazwa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nazwa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,CzyAktywny")] Nazwa nazwa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nazwa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nazwa);
        }

        // GET: Nazwa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nazwa == null)
            {
                return NotFound();
            }

            var nazwa = await _context.Nazwa.FindAsync(id);
            if (nazwa == null)
            {
                return NotFound();
            }
            return View(nazwa);
        }

        // POST: Nazwa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,CzyAktywny")] Nazwa nazwa)
        {
            if (id != nazwa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nazwa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NazwaExists(nazwa.Id))
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
            return View(nazwa);
        }

        // GET: Nazwa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nazwa == null)
            {
                return NotFound();
            }

            var nazwa = await _context.Nazwa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nazwa == null)
            {
                return NotFound();
            }

            return View(nazwa);
        }

        // POST: Nazwa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nazwa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nazwa'  is null.");
            }
            var nazwa = await _context.Nazwa.FindAsync(id);
            if (nazwa != null)
            {
                _context.Nazwa.Remove(nazwa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NazwaExists(int id)
        {
          return (_context.Nazwa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
