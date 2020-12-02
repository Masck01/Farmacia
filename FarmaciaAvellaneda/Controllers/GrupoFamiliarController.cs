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
    public class GrupoFamiliarController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;

        public GrupoFamiliarController(FarmaciaAvellanedaContext context)
        {
            _context = context;
        }

        // GET: GrupoFamiliar
        public async Task<IActionResult> Index()
        {
            var farmaciaAvellanedaContext = _context.GrupoFamiliar.Include(g => g.Empleado);
            return View(await farmaciaAvellanedaContext.ToListAsync());
        }

        // GET: GrupoFamiliar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoFamiliar = await _context.GrupoFamiliar
                .Include(g => g.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoFamiliar == null)
            {
                return NotFound();
            }

            return View(grupoFamiliar);
        }

        // GET: GrupoFamiliar/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId");
            return View();
        }

        // POST: GrupoFamiliar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dni,Apellido,Nombre,FechaNacimiento,Parentesco,EmpleadoId")] GrupoFamiliar grupoFamiliar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoFamiliar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId", grupoFamiliar.EmpleadoId);
            return View(grupoFamiliar);
        }

        // GET: GrupoFamiliar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoFamiliar = await _context.GrupoFamiliar.FindAsync(id);
            if (grupoFamiliar == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId", grupoFamiliar.EmpleadoId);
            return View(grupoFamiliar);
        }

        // POST: GrupoFamiliar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dni,Apellido,Nombre,FechaNacimiento,Parentesco,EmpleadoId")] GrupoFamiliar grupoFamiliar)
        {
            if (id != grupoFamiliar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoFamiliar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoFamiliarExists(grupoFamiliar.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId", grupoFamiliar.EmpleadoId);
            return View(grupoFamiliar);
        }

        // GET: GrupoFamiliar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoFamiliar = await _context.GrupoFamiliar
                .Include(g => g.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoFamiliar == null)
            {
                return NotFound();
            }

            return View(grupoFamiliar);
        }

        // POST: GrupoFamiliar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoFamiliar = await _context.GrupoFamiliar.FindAsync(id);
            _context.GrupoFamiliar.Remove(grupoFamiliar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoFamiliarExists(int id)
        {
            return _context.GrupoFamiliar.Any(e => e.Id == id);
        }
    }
}
