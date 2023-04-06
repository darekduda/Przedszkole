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
    public class InformacjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InformacjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Informacje
        public async Task<IActionResult> Index()
        {
              return _context.Informacje != null ? 
                          View(await _context.Informacje.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Informacje'  is null.");
        }

        // GET: Informacje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Informacje == null)
            {
                return NotFound();
            }

            var informacje = await _context.Informacje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informacje == null)
            {
                return NotFound();
            }

            return View(informacje);
        }

        // GET: Informacje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Informacje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,CzyAktywny")] Informacje informacje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informacje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(informacje);
        }

        // GET: Informacje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Informacje == null)
            {
                return NotFound();
            }

            var informacje = await _context.Informacje.FindAsync(id);
            if (informacje == null)
            {
                return NotFound();
            }
            return View(informacje);
        }

        // POST: Informacje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,CzyAktywny")] Informacje informacje)
        {
            if (id != informacje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informacje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformacjeExists(informacje.Id))
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
            return View(informacje);
        }

        // GET: Informacje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Informacje == null)
            {
                return NotFound();
            }

            var informacje = await _context.Informacje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informacje == null)
            {
                return NotFound();
            }

            return View(informacje);
        }

        // POST: Informacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Informacje == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Informacje'  is null.");
            }
            var informacje = await _context.Informacje.FindAsync(id);
            if (informacje != null)
            {
                _context.Informacje.Remove(informacje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformacjeExists(int id)
        {
          return (_context.Informacje?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
