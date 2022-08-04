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
    public class TipoLinhasController : Controller
    {
        private readonly ArthesContext _context;

        public TipoLinhasController(ArthesContext context)
        {
            _context = context;
        }

        // GET: TipoLinhas
        public async Task<IActionResult> Index()
        {
              return _context.TipoLinha != null ? 
                          View(await _context.TipoLinha.ToListAsync()) :
                          Problem("Entity set 'ArthesContext.TipoLinha'  is null.");
        }

        // GET: TipoLinhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoLinha == null)
            {
                return NotFound();
            }

            var tipoLinha = await _context.TipoLinha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoLinha == null)
            {
                return NotFound();
            }

            return View(tipoLinha);
        }

        // GET: TipoLinhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoLinhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TipoLinha tipoLinha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoLinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoLinha);
        }

        // GET: TipoLinhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoLinha == null)
            {
                return NotFound();
            }

            var tipoLinha = await _context.TipoLinha.FindAsync(id);
            if (tipoLinha == null)
            {
                return NotFound();
            }
            return View(tipoLinha);
        }

        // POST: TipoLinhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TipoLinha tipoLinha)
        {
            if (id != tipoLinha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoLinha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoLinhaExists(tipoLinha.Id))
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
            return View(tipoLinha);
        }

        // GET: TipoLinhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoLinha == null)
            {
                return NotFound();
            }

            var tipoLinha = await _context.TipoLinha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoLinha == null)
            {
                return NotFound();
            }

            return View(tipoLinha);
        }

        // POST: TipoLinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoLinha == null)
            {
                return Problem("Entity set 'ArthesContext.TipoLinha'  is null.");
            }
            var tipoLinha = await _context.TipoLinha.FindAsync(id);
            if (tipoLinha != null)
            {
                _context.TipoLinha.Remove(tipoLinha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoLinhaExists(int id)
        {
          return (_context.TipoLinha?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
