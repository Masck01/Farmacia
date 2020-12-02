using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmaciaAvellaneda.Data;
using FarmaciaAvellaneda.Models;
using FarmaciaAvellaneda.ViewModels;
using FarmaciaAvellaneda.Services;
using Rotativa.AspNetCore;

namespace FarmaciaAvellaneda.Controllers
{
    public class LiquidacionesController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;
        private readonly UsersServices _users;

        public LiquidacionesController(FarmaciaAvellanedaContext context,
            UsersServices users)
        {
            _users = users;
            _context = context;
        }

        // GET: Liquidaciones
        public async Task<IActionResult> Index()
        {
            //LiquidacionViewModel model = new LiquidacionViewModel();
            //var farmaciaAvellanedaContext = _context.Liquidacion.Include(l => l.Empleado);
            //model.Empresa = _context.Empresa.First();
            return View(await _users.ListOfAsync<Empleado>());
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
        public async Task<IActionResult> CreateAsync(int? id)
        {
            List<string> detalles = new List<string> { "Vendedor", "Jubilacion", "OSDE" };
            LiquidacionViewModel model = new LiquidacionViewModel
            {
                Empresa = (await _users.ListOfAsync<Empresa>()).FirstOrDefault(),
                Empleado = await _context.Empleado.Include(l => l.CajaAhorro).FirstOrDefaultAsync(m => m.Id == id),
                Concepto = (await _users.ListOfAsync<Concepto>()).Find(c =>
                {

                    Func<Task<string>> myfunc = async () =>
                    {
                        string UserId = (await _users.ListOfAsync<Empleado>()).Find(m => m.Id == id).UserId;
                        List<string> names = await _users.GetUserInRolesAsync(UserId);
                        return String.Join("", names);

                    };
                    //string UserId = (await _users.ListOfAsync<Empleado>()).Find(m => m.Id == 2).UserId;
                    //List<string> names = await _users.GetUserInRolesAsync(UserId);
                    return c.Descripcion.Contains(myfunc().Result);
                }),
                Liquidacion = (await _users.ListOfAsync<Liquidacion>()).FirstOrDefault(l => l.EmpleadoId == id),
                Conceptos = (await _users.ListOfAsync<Concepto>()).Where(c => detalles.Any(d => c.Descripcion.Contains(d))).ToList()

            };

            //ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "Id", "UserId");
            return View(model);
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

        public async Task<IActionResult> IndexToPdf(int? id)
        {
            List<string> detalles = new List<string> { "Vendedor", "Jubilacion", "OSDE" };
            LiquidacionViewModel model = new LiquidacionViewModel
            {
                Empresa = (await _users.ListOfAsync<Empresa>()).FirstOrDefault(),
                Empleado = await _context.Empleado.Include(l => l.CajaAhorro).FirstOrDefaultAsync(m => m.Id == id),
                Concepto = (await _users.ListOfAsync<Concepto>()).Find(c =>
                {

                    Func<Task<string>> myfunc = async () =>
                    {
                        string UserId = (await _users.ListOfAsync<Empleado>()).Find(m => m.Id == id).UserId;
                        List<string> names = await _users.GetUserInRolesAsync(UserId);
                        return String.Join("", names);

                    };
                    //string UserId = (await _users.ListOfAsync<Empleado>()).Find(m => m.Id == 2).UserId;
                    //List<string> names = await _users.GetUserInRolesAsync(UserId);
                    return c.Descripcion.Contains(myfunc().Result);
                }),
                Liquidacion = (await _users.ListOfAsync<Liquidacion>()).FirstOrDefault(l => l.EmpleadoId == id),
                Conceptos = (await _users.ListOfAsync<Concepto>()).Where(c => detalles.Any(d => c.Descripcion.Contains(d))).ToList()

            };
            return new ViewAsPdf("ImpresionLiquidacion", model)
            {

            };
        }

        private bool LiquidacionExists(int id)
        {
            return _context.Liquidacion.Any(e => e.Id == id);
        }
    }
}
