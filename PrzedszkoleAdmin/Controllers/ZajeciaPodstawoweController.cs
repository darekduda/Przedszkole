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
    public class ZajeciaPodstawoweController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZajeciaPodstawoweController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZajeciaPodstawowe
        public async Task<IActionResult> Index()
        {
              return _context.ZajeciaPodstawowe != null ? 
                          View(await _context.ZajeciaPodstawowe.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ZajeciaPodstawowe'  is null.");
        }

        // GET: ZajeciaPodstawowe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ZajeciaPodstawowe == null)
            {
                return NotFound();
            }

            var zajeciaPodstawowe = await _context.ZajeciaPodstawowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zajeciaPodstawowe == null)
            {
                return NotFound();
            }

            return View(zajeciaPodstawowe);
        }

        // GET: ZajeciaPodstawowe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZajeciaPodstawowe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,CzyAktywny")] ZajeciaPodstawowe zajeciaPodstawowe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zajeciaPodstawowe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zajeciaPodstawowe);
        }

        // GET: ZajeciaPodstawowe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ZajeciaPodstawowe == null)
            {
                return NotFound();
            }

            var zajeciaPodstawowe = await _context.ZajeciaPodstawowe.FindAsync(id);
            if (zajeciaPodstawowe == null)
            {
                return NotFound();
            }
            return View(zajeciaPodstawowe);
        }

        // POST: ZajeciaPodstawowe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,CzyAktywny")] ZajeciaPodstawowe zajeciaPodstawowe)
        {
            if (id != zajeciaPodstawowe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zajeciaPodstawowe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZajeciaPodstawoweExists(zajeciaPodstawowe.Id))
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
            return View(zajeciaPodstawowe);
        }

        // GET: ZajeciaPodstawowe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ZajeciaPodstawowe == null)
            {
                return NotFound();
            }

            var zajeciaPodstawowe = await _context.ZajeciaPodstawowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zajeciaPodstawowe == null)
            {
                return NotFound();
            }

            return View(zajeciaPodstawowe);
        }

        // POST: ZajeciaPodstawowe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ZajeciaPodstawowe == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ZajeciaPodstawowe'  is null.");
            }
            var zajeciaPodstawowe = await _context.ZajeciaPodstawowe.FindAsync(id);
            if (zajeciaPodstawowe != null)
            {
                _context.ZajeciaPodstawowe.Remove(zajeciaPodstawowe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZajeciaPodstawoweExists(int id)
        {
          return (_context.ZajeciaPodstawowe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
