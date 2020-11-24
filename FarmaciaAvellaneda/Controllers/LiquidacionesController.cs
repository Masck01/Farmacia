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
    public class LiquidacionesController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;

        public LiquidacionesController(FarmaciaAvellanedaContext context)
        {
            _context = context;
        }

        // GET: Liquidaciones
        public async Task<IActionResult> Index()
        {
            var farmaciaAvellanedaContext = _context.Liquidacion.Include(l => l.Empleado);
            return View(await farmaciaAvellanedaContext.ToListAsync());
        }

        // GET: Liquidaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquidacion = await _context.Liquidacion
                .Include(l => l.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liquidacion == null)
            {
                return NotFound();
            }

            return View(liquidacion);
        }

        // GET: Liquidaciones/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId");
            return View();
        }

        // POST: Liquidaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaDesde,FechaHasta,SalarioNeto,PeriodoLiquidacion,Estado,TotalRemunerado,TotalDeduccion,EmpleadoId")] Liquidacion liquidacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liquidacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId", liquidacion.EmpleadoId);
            return View(liquidacion);
        }

        // GET: Liquidaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquidacion = await _context.Liquidacion.FindAsync(id);
            if (liquidacion == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId", liquidacion.EmpleadoId);
            return View(liquidacion);
        }

        // POST: Liquidaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaDesde,FechaHasta,SalarioNeto,PeriodoLiquidacion,Estado,TotalRemunerado,TotalDeduccion,EmpleadoId")] Liquidacion liquidacion)
        {
            if (id != liquidacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liquidacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiquidacionExists(liquidacion.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId", liquidacion.EmpleadoId);
            return View(liquidacion);
        }

        // GET: Liquidaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquidacion = await _context.Liquidacion
                .Include(l => l.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liquidacion == null)
            {
                return NotFound();
            }

            return View(liquidacion);
        }

        // POST: Liquidaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liquidacion = await _context.Liquidacion.FindAsync(id);
            _context.Liquidacion.Remove(liquidacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiquidacionExists(int id)
        {
            return _context.Liquidacion.Any(e => e.Id == id);
        }
    }
}
