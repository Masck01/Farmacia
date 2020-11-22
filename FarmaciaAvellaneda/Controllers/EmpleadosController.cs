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
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace FarmaciaAvellaneda.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;
        private readonly UsersServices _users;

        public EmpleadosController(FarmaciaAvellanedaContext context,
            UsersServices users)
        {
            _context = context;
            _users = users;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var farmaciaAvellanedaContext = _context.Empleado.Include(e => e.User);
            return View(await farmaciaAvellanedaContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            //ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] EmpleadoViewModel empleado)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    IdentityResult result = await _users.CreateUserAsync(empleado.Email, empleado.Password);
                    if (result.Succeeded)
                    {
                        string userId = await _users.UserIdAsync(empleado.Email);
                        int cols = await _context.Database.ExecuteSqlInterpolatedAsync(
                            $@"Exec CreateEmployee 
                            @Nombre={empleado.Nombre},
	                        @Apellido={empleado.Apellido},
	                        @Domicilio={empleado.Domicilio},
	                        @Cuit={empleado.Cuit},
	                        @Email={empleado.Email},
	                        @Celular={empleado.Celular},
	                        @Telefono={empleado.Telefono},
	                        @Estado={empleado.Estado},
	                        @UserId={userId}");
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        _users.Errors(result, ModelState);
                }
                catch
                {
                    throw;
                }
            }
            //ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", empleado.UserId);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", empleado.UserId);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apellido,Nombre,Cuit,Email,Celular,Telefono,Domicilio,Estado,UserId")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", empleado.UserId);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.Id == id);
        }
    }
}
