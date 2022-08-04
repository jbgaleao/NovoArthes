using Arthes.DATA.Data;
using Arthes.DATA.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Arthes.WEB.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly ArthesContext _context;

        public ReceitasController(ArthesContext context)
        {
            _context = context;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Receita, Revista>? arthesContext = _context.Receita.Include(r => r.IdRevistaNavigation);
            return View(await arthesContext.ToListAsync());
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receita == null)
            {
                return NotFound();
            }

            Receita? receita = await _context.Receita
                .Include(r => r.IdRevistaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            return receita == null ? NotFound() : View(receita);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            ViewData["IdRevista"] = new SelectList(_context.Revista, "Id", "Id");
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Altura,NivelDificuldade,IdRevista")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(receita);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRevista"] = new SelectList(_context.Revista, "Id", "Id", receita.IdRevista);
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receita == null)
            {
                return NotFound();
            }

            Receita? receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            ViewData["IdRevista"] = new SelectList(_context.Revista, "Id", "Id", receita.IdRevista);
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Altura,NivelDificuldade,IdRevista")] Receita receita)
        {
            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(receita);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
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
            ViewData["IdRevista"] = new SelectList(_context.Revista, "Id", "Id", receita.IdRevista);
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receita == null)
            {
                return NotFound();
            }

            Receita? receita = await _context.Receita
                .Include(r => r.IdRevistaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            return receita == null ? NotFound() : View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receita == null)
            {
                return Problem("Entity set 'ArthesContext.Receita'  is null.");
            }
            Receita? receita = await _context.Receita.FindAsync(id);
            if (receita != null)
            {
                _ = _context.Receita.Remove(receita);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return (_context.Receita?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
