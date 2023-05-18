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
    public class GrupaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrupaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grupa
        public async Task<IActionResult> Index()
        {
              return _context.Grupa != null ? 
                          View(await _context.Grupa.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Grupa'  is null.");
        }

        // GET: Grupa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grupa == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupa == null)
            {
                return NotFound();
            }

            return View(grupa);
        }

        // GET: Grupa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CzyAktywny")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupa);
        }

        // GET: Grupa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grupa == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupa.FindAsync(id);
            if (grupa == null)
            {
                return NotFound();
            }
            return View(grupa);
        }

        // POST: Grupa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CzyAktywny")] Grupa grupa)
        {
            if (id != grupa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupaExists(grupa.Id))
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
            return View(grupa);
        }

        // GET: Grupa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grupa == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupa == null)
            {
                return NotFound();
            }

            return View(grupa);
        }

        // POST: Grupa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grupa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Grupa'  is null.");
            }
            var grupa = await _context.Grupa.FindAsync(id);
            if (grupa != null)
            {
                _context.Grupa.Remove(grupa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupaExists(int id)
        {
          return (_context.Grupa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
