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
    [Authorize]
    public class CajasController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;

        public CajasController(FarmaciaAvellanedaContext context)
        {
            _context = context;
        }

        // GET: Cajas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Caja.ToListAsync());
        }

        // GET: Cajas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caja = await _context.Caja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caja == null)
            {
                return NotFound();
            }

            return View(caja);
        }

        // GET: Cajas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado,Saldo")] Caja caja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caja);
        }

        // GET: Cajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caja = await _context.Caja.FindAsync(id);
            if (caja == null)
            {
                return NotFound();
            }
            return View(caja);
        }

        // POST: Cajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado,Saldo")] Caja caja)
        {
            if (id != caja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CajaExists(caja.Id))
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
            return View(caja);
        }

        // GET: Cajas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caja = await _context.Caja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caja == null)
            {
                return NotFound();
            }

            return View(caja);
        }

        // POST: Cajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caja = await _context.Caja.FindAsync(id);
            _context.Caja.Remove(caja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CajaExists(int id)
        {
            return _context.Caja.Any(e => e.Id == id);
        }
    }
}
