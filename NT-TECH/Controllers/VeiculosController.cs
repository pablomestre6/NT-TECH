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
    public class VeiculosController : Controller
    {
        private readonly NT_TECHContext _context;

        public VeiculosController(NT_TECHContext context)
        {
            _context = context;
        }

        // GET: Veiculos
        public async Task<IActionResult> Index()
        {
              return _context.Veiculos != null ? 
                          View(await _context.Veiculos.ToListAsync()) :
                          Problem("Entity set 'NT_TECHContext.Veiculos'  is null.");
        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Veiculos == null)
            {
                return NotFound();
            }

            var veiculos = await _context.Veiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlacadoVeiculo,ModelodoVeiculo,DateTime")] Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                veiculos.Id = Guid.NewGuid();
                _context.Add(veiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculos);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Veiculos == null)
            {
                return NotFound();
            }

            var veiculos = await _context.Veiculos.FindAsync(id);
            if (veiculos == null)
            {
                return NotFound();
            }
            return View(veiculos);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PlacadoVeiculo,ModelodoVeiculo,DateTime")] Veiculos veiculos)
        {
            if (id != veiculos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculosExists(veiculos.Id))
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
            return View(veiculos);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Veiculos == null)
            {
                return NotFound();
            }

            var veiculos = await _context.Veiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Veiculos == null)
            {
                return Problem("Entity set 'NT_TECHContext.Veiculos'  is null.");
            }
            var veiculos = await _context.Veiculos.FindAsync(id);
            if (veiculos != null)
            {
                _context.Veiculos.Remove(veiculos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculosExists(Guid id)
        {
          return (_context.Veiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
