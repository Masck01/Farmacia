using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmaciaAvellaneda.Data;
using FarmaciaAvellaneda.Models;
using FarmaciaAvellaneda.Services;
using FarmaciaAvellaneda.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FarmaciaAvellaneda.Controllers
{
    [Authorize]
    public class ConceptosController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;
        private readonly UsersServices _users;

        public ConceptosController(FarmaciaAvellanedaContext context, UsersServices users)
        {
            _users = users;
            _context = context;
        }

        // GET: Conceptos
        public async Task<IActionResult> Index()
        {
            return View(await _users.ListOfAsync<Concepto>());
        }

        // GET: Conceptos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Concepto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concepto == null)
            {
                return NotFound();
            }

            return View(concepto);
        }

        // GET: Conceptos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conceptos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConceptoViewModel concepto)
        {
            if (ModelState.IsValid)
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($@"
                        EXEC sp_create_deduccion
                        @Descipcion={concepto.Descripcion},
                        @Tipo={concepto.Tipo},
                        @Monto={concepto.Monto},
                        @Exento={concepto.Exento}");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concepto);
        }

        // GET: Conceptos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Concepto.FindAsync(id);
            if (concepto == null)
            {
                return NotFound();
            }
            return View(concepto);
        }

        // POST: Conceptos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Tipo,Monto,Unidad")] Concepto concepto)
        {
            if (id != concepto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concepto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConceptoExists(concepto.Id))
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
            return View(concepto);
        }

        // GET: Conceptos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Concepto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concepto == null)
            {
                return NotFound();
            }

            return View(concepto);
        }

        // POST: Conceptos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concepto = await _context.Concepto.FindAsync(id);
            _context.Concepto.Remove(concepto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConceptoExists(int id)
        {
            return _context.Concepto.Any(e => e.Id == id);
        }
    }
}
