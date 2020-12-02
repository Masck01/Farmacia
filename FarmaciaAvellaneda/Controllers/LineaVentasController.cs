using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmaciaAvellaneda.Data;
using FarmaciaAvellaneda.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmaciaAvellaneda.Controllers
{
    [Authorize]
    public class LineaVentasController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;

        public LineaVentasController(FarmaciaAvellanedaContext context)
        {
            _context = context;
        }

        // GET: LineaVentas
        public async Task<IActionResult> Index()
        {
            var farmaciaAvellanedaContext = _context.LineaVenta.Include(l => l.Producto).Include(l => l.Venta);
            return View(await farmaciaAvellanedaContext.ToListAsync());
        }

        // GET: LineaVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaVenta = await _context.LineaVenta
                .Include(l => l.Producto)
                .Include(l => l.Venta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineaVenta == null)
            {
                return NotFound();
            }

            return View(lineaVenta);
        }

        // GET: LineaVentas/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id");
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id");
            return View();
        }

        // POST: LineaVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subtotal,Cantidad,VentaId,ProductoId")] LineaVenta lineaVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineaVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", lineaVenta.ProductoId);
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id", lineaVenta.VentaId);
            return View(lineaVenta);
        }

        // GET: LineaVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaVenta = await _context.LineaVenta.FindAsync(id);
            if (lineaVenta == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", lineaVenta.ProductoId);
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id", lineaVenta.VentaId);
            return View(lineaVenta);
        }

        // POST: LineaVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subtotal,Cantidad,VentaId,ProductoId")] LineaVenta lineaVenta)
        {
            if (id != lineaVenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineaVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineaVentaExists(lineaVenta.Id))
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
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", lineaVenta.ProductoId);
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id", lineaVenta.VentaId);
            return View(lineaVenta);
        }

        // GET: LineaVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaVenta = await _context.LineaVenta
                .Include(l => l.Producto)
                .Include(l => l.Venta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineaVenta == null)
            {
                return NotFound();
            }

            return View(lineaVenta);
        }

        // POST: LineaVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineaVenta = await _context.LineaVenta.FindAsync(id);
            _context.LineaVenta.Remove(lineaVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineaVentaExists(int id)
        {
            return _context.LineaVenta.Any(e => e.Id == id);
        }
    }
}
