using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NT_TECH.Data;
using NT_TECH.Models.Veiculos;

namespace NT_TECH.Controllers
{
    public class PlacasCadastradasController : Controller
    {
        private readonly NT_TECHContext _context;

        public PlacasCadastradasController(NT_TECHContext context)
        {
            _context = context;
        }

        // GET: PlacasCadastradas
        public async Task<IActionResult> Index()
        {
              return _context.PlacasCadastradas != null ? 
                          View(await _context.PlacasCadastradas.ToListAsync()) :
                          Problem("Entity set 'NT_TECHContext.PlacasCadastradas'  is null.");
        }

        // GET: PlacasCadastradas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PlacasCadastradas == null)
            {
                return NotFound();
            }

            var placasCadastradas = await _context.PlacasCadastradas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placasCadastradas == null)
            {
                return NotFound();
            }

            return View(placasCadastradas);
        }

        // GET: PlacasCadastradas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlacasCadastradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlacasCadastrada,ChavesAtivas,NaoAtivas")] PlacasCadastradas placasCadastradas)
        {
            if (ModelState.IsValid)
            {
                placasCadastradas.Id = Guid.NewGuid();
                _context.Add(placasCadastradas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placasCadastradas);
        }

        // GET: PlacasCadastradas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PlacasCadastradas == null)
            {
                return NotFound();
            }

            var placasCadastradas = await _context.PlacasCadastradas.FindAsync(id);
            if (placasCadastradas == null)
            {
                return NotFound();
            }
            return View(placasCadastradas);
        }

        // POST: PlacasCadastradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PlacasCadastrada,ChavesAtivas,NaoAtivas")] PlacasCadastradas placasCadastradas)
        {
            if (id != placasCadastradas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placasCadastradas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacasCadastradasExists(placasCadastradas.Id))
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
            return View(placasCadastradas);
        }

        // GET: PlacasCadastradas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PlacasCadastradas == null)
            {
                return NotFound();
            }

            var placasCadastradas = await _context.PlacasCadastradas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placasCadastradas == null)
            {
                return NotFound();
            }

            return View(placasCadastradas);
        }

        // POST: PlacasCadastradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PlacasCadastradas == null)
            {
                return Problem("Entity set 'NT_TECHContext.PlacasCadastradas'  is null.");
            }
            var placasCadastradas = await _context.PlacasCadastradas.FindAsync(id);
            if (placasCadastradas != null)
            {
                _context.PlacasCadastradas.Remove(placasCadastradas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacasCadastradasExists(Guid id)
        {
          return (_context.PlacasCadastradas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
