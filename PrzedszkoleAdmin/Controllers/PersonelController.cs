using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleAdmin.Services;
using PrzedszkoleData.Data;
using PrzedszkoleData.Data.CMS;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;

namespace PrzedszkoleAdmin.Controllers
{
    public class PersonelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;


        public PersonelController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        // GET: Personel
        public async Task<IActionResult> Index()
        {
            return _context.Personel != null ?
                View(await _context.Personel.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Personel'  is null.");
        }

        // GET: Personel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personel == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // GET: Personel/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Personel personel, IFormFile profilePicture)
        {
            if (ModelState.IsValid)
            {
                if (profilePicture != null && profilePicture.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(profilePicture.FileName)}";
                    var relativePath = Path.Combine("Data", "Personel", fileName);
                    var absolutePath = Path.Combine(@"C:\Users\dariu\Desktop\Przedszkole\Przedszkole\Przedszkole\PrzedszkoleData", relativePath);
                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await profilePicture.CopyToAsync(stream);
                    }

                    personel.ProfilePicture = fileName;
                    var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
                    if (!allowedTypes.Contains(profilePicture.ContentType))
                    {
                        ModelState.AddModelError("profilePicture", "Nieprawidłowy format pliku");
                        return View(personel);
                    }
                }

                _context.Add(personel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(personel);
        }


            // GET: Personel/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personel == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Stanowsiko,ProfilePicture")] Personel personel)
        {
            if (id != personel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelExists(personel.Id))
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
            return View(personel);
        }

        // GET: Personel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personel == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Personel'  is null.");
            }
            var personel = await _context.Personel.FindAsync(id);
            if (personel != null)
            {
                _context.Personel.Remove(personel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
            return (_context.Personel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
