using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arthes.DATA.Data;
using Arthes.DATA.Models;

namespace Arthes.WEB.Controllers
{
    public class RevistasController : Controller
    {
        private readonly ArthesContext _context;

        public RevistasController(ArthesContext context)
        {
            _context = context;
        }

        // GET: Revistas
        public async Task<IActionResult> Index()
        {
              return _context.Revista != null ? 
                          View(await _context.Revista.ToListAsync()) :
                          Problem("Entity set 'ArthesContext.Revista'  is null.");
        }

        // GET: Revistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Revista == null)
            {
                return NotFound();
            }

            var revista = await _context.Revista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revista == null)
            {
                return NotFound();
            }

            return View(revista);
        }

        // GET: Revistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Revistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tema,NumEdicao,MesEdicao,AnoEdicao")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(revista);
        }

        // GET: Revistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Revista == null)
            {
                return NotFound();
            }

            var revista = await _context.Revista.FindAsync(id);
            if (revista == null)
            {
                return NotFound();
            }
            return View(revista);
        }

        // POST: Revistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tema,NumEdicao,MesEdicao,AnoEdicao")] Revista revista)
        {
            if (id != revista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevistaExists(revista.Id))
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
            return View(revista);
        }

        // GET: Revistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Revista == null)
            {
                return NotFound();
            }

            var revista = await _context.Revista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revista == null)
            {
                return NotFound();
            }

            return View(revista);
        }

        // POST: Revistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Revista == null)
            {
                return Problem("Entity set 'ArthesContext.Revista'  is null.");
            }
            var revista = await _context.Revista.FindAsync(id);
            if (revista != null)
            {
                _context.Revista.Remove(revista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevistaExists(int id)
        {
          return (_context.Revista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
