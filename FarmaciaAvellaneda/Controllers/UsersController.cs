using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmaciaAvellaneda.Models;
using Microsoft.AspNetCore.Identity;

namespace FarmaciaAvellaneda.Controllers
{
    public class UsersController : Controller
    {
        private readonly FarmaciaAvellanedaContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _hasher;

        public UsersController(
            FarmaciaAvellanedaContext context,
            UserManager<IdentityUser> usrMngr,
            IPasswordHasher<IdentityUser> passwordHasher)
        {
            _context = context;
            _userManager = usrMngr;
            _hasher = passwordHasher;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync<IdentityUser>());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var aspNetUsers = await _context.AspNetUsers
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var aspNetUsers = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return View(aspNetUsers);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,PasswordHash")] AspNetUsers aspNetUsers)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(new IdentityUser
                {
                    UserName = aspNetUsers.Email,
                    Email = aspNetUsers.Email
                }, aspNetUsers.PasswordHash);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    Errors(result);
                //_context.Add(aspNetUsers);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(aspNetUsers);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IdentityUser aspNetUsers = await _userManager.FindByIdAsync(id);

            if (aspNetUsers == null)
            {
                return NotFound();
            }
            return View(aspNetUsers);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,EmailConfirmed,PasswordHash")] IdentityUser aspNetUsers)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(aspNetUsers.UserName))
                        user.Email = aspNetUsers.UserName;
                    else
                        ModelState.AddModelError("", "Email vacio");
                    if (!string.IsNullOrEmpty(aspNetUsers.PasswordHash))
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, aspNetUsers.PasswordHash);
                    }
                    else
                        ModelState.AddModelError("", "Contraseña vacia");
                    if (!string.IsNullOrEmpty(aspNetUsers.UserName) && !string.IsNullOrEmpty(aspNetUsers.PasswordHash))
                    {
                        //await _userManager.RemovePasswordAsync(user);
                        //await _userManager.AddPasswordAsync(user, aspNetUsers.PasswordHash);
                        user.EmailConfirmed = aspNetUsers.EmailConfirmed;
                        IdentityResult result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                            return RedirectToAction(nameof(Index));
                        else
                            Errors(result);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUsersExists(aspNetUsers.Id))
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
            else
                ModelState.AddModelError("", "Usuario no encontrado");
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUsers = await _context.AspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return View(aspNetUsers);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);
            _context.AspNetUsers.Remove(aspNetUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUsersExists(string id)
        {
            return _context.AspNetUsers.Any(e => e.Id == id);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

        }
    }
}
