using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnalyzesWebApplication.Data;
using AnalyzesWebApplication.Models;

namespace AnalyzesWebApplication.Controllers
{
    public class AnalyzController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnalyzController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Analyz
        public async Task<IActionResult> Index()
        {
              return _context.Analyzes != null ? 
                          View(await _context.Analyzes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Analyz'  is null.");
        }

        // GET: Analyz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Norms == null)
            {
                return NotFound();
            }

            var analyz = await _context.Norms
                .Where(x => x.AnalyzId == id).ToListAsync();
            if (analyz == null)
            {
                return NotFound();
            }

            return View(analyz);
        }

        // GET: Analyz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Analyz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ManMin,ManMax,WManMin,WManMax,AnalyzId")] Norm norms, int? id)
        {
            if (ModelState.IsValid)
            {
                _context.Add(norms);
                DropDownList(id);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(norms);
        }

        private void DropDownList(int? id)
        {
            var list = _context.Analyzes;
            ViewBag.AnalyzId = new SelectList(list.AsNoTracking(), "Id", "Name");
        }

        // GET: Analyz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Analyzes == null)
            {
                return NotFound();
            }

            var analyz = await _context.Analyzes.FindAsync(id);
            if (analyz == null)
            {
                return NotFound();
            }
            return View(analyz);
        }

        // POST: Analyz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Analyz analyz)
        {
            if (id != analyz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analyz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalyzExists(analyz.Id))
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
            return View(analyz);
        }

        // GET: Analyz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Analyzes == null)
            {
                return NotFound();
            }

            var analyz = await _context.Analyzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analyz == null)
            {
                return NotFound();
            }

            return View(analyz);
        }

        // POST: Analyz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Analyzes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Analyz'  is null.");
            }
            var analyz = await _context.Analyzes.FindAsync(id);
            if (analyz != null)
            {
                _context.Analyzes.Remove(analyz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalyzExists(int id)
        {
          return (_context.Analyzes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
