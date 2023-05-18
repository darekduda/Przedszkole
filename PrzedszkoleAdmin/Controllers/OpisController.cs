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
    public class OpisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opis
        public async Task<IActionResult> Index()
        {
              return _context.Opis != null ? 
                          View(await _context.Opis.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Opis'  is null.");
        }

        // GET: Opis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Opis == null)
            {
                return NotFound();
            }

            var opis = await _context.Opis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opis == null)
            {
                return NotFound();
            }

            return View(opis);
        }

        // GET: Opis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Nazwa,CzyAktywny")] Opis opis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opis);
        }

        // GET: Opis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Opis == null)
            {
                return NotFound();
            }

            var opis = await _context.Opis.FindAsync(id);
            if (opis == null)
            {
                return NotFound();
            }
            return View(opis);
        }

        // POST: Opis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Nazwa,CzyAktywny")] Opis opis)
        {
            if (id != opis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpisExists(opis.Id))
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
            return View(opis);
        }

        // GET: Opis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Opis == null)
            {
                return NotFound();
            }

            var opis = await _context.Opis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opis == null)
            {
                return NotFound();
            }

            return View(opis);
        }

        // POST: Opis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Opis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Opis'  is null.");
            }
            var opis = await _context.Opis.FindAsync(id);
            if (opis != null)
            {
                _context.Opis.Remove(opis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpisExists(int id)
        {
          return (_context.Opis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
