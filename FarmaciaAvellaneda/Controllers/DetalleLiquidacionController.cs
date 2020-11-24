using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmaciaAvellaneda.Data;
using FarmaciaAvellaneda.Models;

namespace FarmaciaAvellaneda.Controllers
{
    public class DetalleLiquidacionController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;

        public DetalleLiquidacionController(FarmaciaAvellanedaContext context)
        {
            _context = context;
        }

        // GET: DetalleLiquidacion
        public async Task<IActionResult> Index()
        {
            var farmaciaAvellanedaContext = _context.DetalleLiquidacion.Include(d => d.Concepto).Include(d => d.Liquidacion);
            return View(await farmaciaAvellanedaContext.ToListAsync());
        }

        // GET: DetalleLiquidacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleLiquidacion = await _context.DetalleLiquidacion
                .Include(d => d.Concepto)
                .Include(d => d.Liquidacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleLiquidacion == null)
            {
                return NotFound();
            }

            return View(detalleLiquidacion);
        }

        // GET: DetalleLiquidacion/Create
        public IActionResult Create()
        {
            ViewData["ConceptoId"] = new SelectList(_context.Concepto, "Id", "Id");
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidacion, "Id", "Id");
            return View();
        }

        // POST: DetalleLiquidacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Unidad,Haber,ConceptoId,LiquidacionId")] DetalleLiquidacion detalleLiquidacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleLiquidacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConceptoId"] = new SelectList(_context.Concepto, "Id", "Id", detalleLiquidacion.ConceptoId);
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidacion, "Id", "Id", detalleLiquidacion.LiquidacionId);
            return View(detalleLiquidacion);
        }

        // GET: DetalleLiquidacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleLiquidacion = await _context.DetalleLiquidacion.FindAsync(id);
            if (detalleLiquidacion == null)
            {
                return NotFound();
            }
            ViewData["ConceptoId"] = new SelectList(_context.Concepto, "Id", "Id", detalleLiquidacion.ConceptoId);
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidacion, "Id", "Id", detalleLiquidacion.LiquidacionId);
            return View(detalleLiquidacion);
        }

        // POST: DetalleLiquidacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Unidad,Haber,ConceptoId,LiquidacionId")] DetalleLiquidacion detalleLiquidacion)
        {
            if (id != detalleLiquidacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleLiquidacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleLiquidacionExists(detalleLiquidacion.Id))
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
            ViewData["ConceptoId"] = new SelectList(_context.Concepto, "Id", "Id", detalleLiquidacion.ConceptoId);
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidacion, "Id", "Id", detalleLiquidacion.LiquidacionId);
            return View(detalleLiquidacion);
        }

        // GET: DetalleLiquidacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleLiquidacion = await _context.DetalleLiquidacion
                .Include(d => d.Concepto)
                .Include(d => d.Liquidacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleLiquidacion == null)
            {
                return NotFound();
            }

            return View(detalleLiquidacion);
        }

        // POST: DetalleLiquidacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleLiquidacion = await _context.DetalleLiquidacion.FindAsync(id);
            _context.DetalleLiquidacion.Remove(detalleLiquidacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleLiquidacionExists(int id)
        {
            return _context.DetalleLiquidacion.Any(e => e.Id == id);
        }
    }
}
