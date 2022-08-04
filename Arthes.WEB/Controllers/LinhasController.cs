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
    public class LinhasController : Controller
    {
        private readonly ArthesContext _context;

        public LinhasController(ArthesContext context)
        {
            _context = context;
        }

        // GET: Linhas
        public async Task<IActionResult> Index()
        {
            var arthesContext = _context.Linha.Include(l => l.Fabricante).Include(l => l.TipoLinha);
            return View(await arthesContext.ToListAsync());
        }

        // GET: Linhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Linha == null)
            {
                return NotFound();
            }

            var linha = await _context.Linha
                .Include(l => l.Fabricante)
                .Include(l => l.TipoLinha)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linha == null)
            {
                return NotFound();
            }

            return View(linha);
        }

        // GET: Linhas/Create
        public IActionResult Create()
        {
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id");
            ViewData["TipoLinhaId"] = new SelectList(_context.TipoLinha, "Id", "Id");
            return View();
        }

        // POST: Linhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodLinha,NomeCor,TipoLinhaId,FabricanteId")] Linha linha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id", linha.FabricanteId);
            ViewData["TipoLinhaId"] = new SelectList(_context.TipoLinha, "Id", "Id", linha.TipoLinhaId);
            return View(linha);
        }

        // GET: Linhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Linha == null)
            {
                return NotFound();
            }

            var linha = await _context.Linha.FindAsync(id);
            if (linha == null)
            {
                return NotFound();
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id", linha.FabricanteId);
            ViewData["TipoLinhaId"] = new SelectList(_context.TipoLinha, "Id", "Id", linha.TipoLinhaId);
            return View(linha);
        }

        // POST: Linhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodLinha,NomeCor,TipoLinhaId,FabricanteId")] Linha linha)
        {
            if (id != linha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaExists(linha.Id))
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
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id", linha.FabricanteId);
            ViewData["TipoLinhaId"] = new SelectList(_context.TipoLinha, "Id", "Id", linha.TipoLinhaId);
            return View(linha);
        }

        // GET: Linhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Linha == null)
            {
                return NotFound();
            }

            var linha = await _context.Linha
                .Include(l => l.Fabricante)
                .Include(l => l.TipoLinha)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linha == null)
            {
                return NotFound();
            }

            return View(linha);
        }

        // POST: Linhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Linha == null)
            {
                return Problem("Entity set 'ArthesContext.Linha'  is null.");
            }
            var linha = await _context.Linha.FindAsync(id);
            if (linha != null)
            {
                _context.Linha.Remove(linha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaExists(int id)
        {
          return (_context.Linha?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
