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
    public class ONasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ONasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ONas
        public async Task<IActionResult> Index()
        {
              return _context.ONas != null ? 
                          View(await _context.ONas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ONas'  is null.");
        }

        // GET: ONas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // GET: ONas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ONas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,CzyAktywny")] ONas oNas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oNas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oNas);
        }

        // GET: ONas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas.FindAsync(id);
            if (oNas == null)
            {
                return NotFound();
            }
            return View(oNas);
        }

        // POST: ONas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,CzyAktywny")] ONas oNas)
        {
            if (id != oNas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oNas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ONasExists(oNas.Id))
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
            return View(oNas);
        }

        // GET: ONas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // POST: ONas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ONas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ONas'  is null.");
            }
            var oNas = await _context.ONas.FindAsync(id);
            if (oNas != null)
            {
                _context.ONas.Remove(oNas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ONasExists(int id)
        {
          return (_context.ONas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
