using Arthes.DATA.Data;
using Arthes.DATA.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Arthes.WEB.Controllers
{
    public class LinhaReceitasController : Controller
    {
        private readonly ArthesContext _context;

        public LinhaReceitasController(ArthesContext context)
        {
            _context = context;
        }

        // GET: LinhaReceitas
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<LinhaReceita, Receita>? arthesContext = _context.LinhaReceita.Include(l => l.Linha).Include(l => l.Receita);
            return View(await arthesContext.ToListAsync());
        }

        // GET: LinhaReceitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LinhaReceita == null)
            {
                return NotFound();
            }

            LinhaReceita? linhaReceita = await _context.LinhaReceita
                .Include(l => l.Linha)
                .Include(l => l.Receita)
                .FirstOrDefaultAsync(m => m.Id == id);
            return linhaReceita == null ? NotFound() : View(linhaReceita);
        }

        // GET: LinhaReceitas/Create
        public IActionResult Create()
        {
            ViewData["LinhaId"] = new SelectList(_context.Linha, "Id", "Id");
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Id");
            return View();
        }

        // POST: LinhaReceitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceitaId,LinhaId")] LinhaReceita linhaReceita)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(linhaReceita);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LinhaId"] = new SelectList(_context.Linha, "Id", "Id", linhaReceita.LinhaId);
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Id", linhaReceita.ReceitaId);
            return View(linhaReceita);
        }

        // GET: LinhaReceitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LinhaReceita == null)
            {
                return NotFound();
            }

            LinhaReceita? linhaReceita = await _context.LinhaReceita.FindAsync(id);
            if (linhaReceita == null)
            {
                return NotFound();
            }
            ViewData["LinhaId"] = new SelectList(_context.Linha, "Id", "Id", linhaReceita.LinhaId);
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Id", linhaReceita.ReceitaId);
            return View(linhaReceita);
        }

        // POST: LinhaReceitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceitaId,LinhaId")] LinhaReceita linhaReceita)
        {
            if (id != linhaReceita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(linhaReceita);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaReceitaExists(linhaReceita.Id))
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
            ViewData["LinhaId"] = new SelectList(_context.Linha, "Id", "Id", linhaReceita.LinhaId);
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Id", linhaReceita.ReceitaId);
            return View(linhaReceita);
        }

        // GET: LinhaReceitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LinhaReceita == null)
            {
                return NotFound();
            }

            LinhaReceita? linhaReceita = await _context.LinhaReceita
                .Include(l => l.Linha)
                .Include(l => l.Receita)
                .FirstOrDefaultAsync(m => m.Id == id);
            return linhaReceita == null ? NotFound() : View(linhaReceita);
        }

        // POST: LinhaReceitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LinhaReceita == null)
            {
                return Problem("Entity set 'ArthesContext.LinhaReceita'  is null.");
            }
            LinhaReceita? linhaReceita = await _context.LinhaReceita.FindAsync(id);
            if (linhaReceita != null)
            {
                _ = _context.LinhaReceita.Remove(linhaReceita);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaReceitaExists(int id)
        {
            return (_context.LinhaReceita?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
