using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmaciaAvellaneda.Models;
using FarmaciaAvellaneda.Data;
using Microsoft.AspNetCore.Identity;

namespace FarmaciaAvellaneda.Controllers
{
    public class RolesController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(FarmaciaAvellanedaContext context, RoleManager<IdentityRole> role)
        {
            _context = context;
            roleManager = role;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await roleManager.Roles.ToListAsync<IdentityRole>());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetRoles = await _context.AspNetRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return View(aspNetRoles);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AspNetRoles aspNetRoles)
        public async Task<IActionResult> Create([Bind("Name")] AspNetRoles aspNetRoles)
        {
            if (ModelState.IsValid)
            {
                IdentityResult rol = await roleManager.CreateAsync(new IdentityRole(aspNetRoles.Name));
                //_context.Add(aspNetRoles);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (rol.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    Errors(rol);
            }
            return View(aspNetRoles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }
            return View(aspNetRoles);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AspNetRoles aspNetRoles)
        {
            if (id != aspNetRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetRolesExists(aspNetRoles.Id))
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
            return View(aspNetRoles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetRoles = await _context.AspNetRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return View(aspNetRoles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);
            _context.AspNetRoles.Remove(aspNetRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetRolesExists(string id)
        {
            return _context.AspNetRoles.Any(e => e.Id == id);
        }

        // HandleErrors
        private void Errors(IdentityResult rol)
        {
            foreach(IdentityError error in rol.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
