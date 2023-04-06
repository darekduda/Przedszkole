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
    public class ZajeciaDodatkoweController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZajeciaDodatkoweController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZajeciaDodatkowe
        public async Task<IActionResult> Index()
        {
              return _context.ZajeciaDodatkowe != null ? 
                          View(await _context.ZajeciaDodatkowe.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ZajeciaDodatkowe'  is null.");
        }

        // GET: ZajeciaDodatkowe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ZajeciaDodatkowe == null)
            {
                return NotFound();
            }

            var zajeciaDodatkowe = await _context.ZajeciaDodatkowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zajeciaDodatkowe == null)
            {
                return NotFound();
            }

            return View(zajeciaDodatkowe);
        }

        // GET: ZajeciaDodatkowe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZajeciaDodatkowe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,Cena,CzyAktywny")] ZajeciaDodatkowe zajeciaDodatkowe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zajeciaDodatkowe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zajeciaDodatkowe);
        }

        // GET: ZajeciaDodatkowe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ZajeciaDodatkowe == null)
            {
                return NotFound();
            }

            var zajeciaDodatkowe = await _context.ZajeciaDodatkowe.FindAsync(id);
            if (zajeciaDodatkowe == null)
            {
                return NotFound();
            }
            return View(zajeciaDodatkowe);
        }

        // POST: ZajeciaDodatkowe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,Cena,CzyAktywny")] ZajeciaDodatkowe zajeciaDodatkowe)
        {
            if (id != zajeciaDodatkowe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zajeciaDodatkowe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZajeciaDodatkoweExists(zajeciaDodatkowe.Id))
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
            return View(zajeciaDodatkowe);
        }

        // GET: ZajeciaDodatkowe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ZajeciaDodatkowe == null)
            {
                return NotFound();
            }

            var zajeciaDodatkowe = await _context.ZajeciaDodatkowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zajeciaDodatkowe == null)
            {
                return NotFound();
            }

            return View(zajeciaDodatkowe);
        }

        // POST: ZajeciaDodatkowe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ZajeciaDodatkowe == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ZajeciaDodatkowe'  is null.");
            }
            var zajeciaDodatkowe = await _context.ZajeciaDodatkowe.FindAsync(id);
            if (zajeciaDodatkowe != null)
            {
                _context.ZajeciaDodatkowe.Remove(zajeciaDodatkowe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZajeciaDodatkoweExists(int id)
        {
          return (_context.ZajeciaDodatkowe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
