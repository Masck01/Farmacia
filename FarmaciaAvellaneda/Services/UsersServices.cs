using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FarmaciaAvellaneda.ViewModels;
using FarmaciaAvellaneda.Models;
using FarmaciaAvellaneda.Data;

namespace FarmaciaAvellaneda.Services
{
    public class UsersServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly FarmaciaAvellanedaContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersServices(UserManager<IdentityUser> userManager,
            FarmaciaAvellanedaContext context,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(string email, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = email,
                Email = email
            }, password);

            return result;
            //if (result.Succeeded)
            //{
            //    IdentityUser user = await _userManager.FindByNameAsync(email);
            //    return user.Id;
            //}
            //else
            //    return result.Errors.ToString();
        }

        public void Errors(IdentityResult result, ModelStateDictionary ModelState)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<string> UserIdAsync(string email)
        {

            IdentityUser userId = await _userManager.FindByNameAsync(email);
            return userId.Id;

        }

        public string EmpleadoName(string UserId)
        {
            Empleado empleado = _context.Empleado.FirstOrDefault(b => b.UserId == UserId);
            if (empleado == null)
            {
                return "Sin Asignar";
            }
            return $"{empleado.Nombre} {empleado.Apellido}";

        }

        public string UserName(string UserId)
        {
            return _context.AspNetUsers.FirstOrDefault(b => b.Id == UserId).UserName;
        }

        public UserViewModel ToUserViewModel(IdentityUser identityUser)
        {
            UserViewModel user = new UserViewModel(identityUser.Email, identityUser.PasswordHash, identityUser.EmailConfirmed);
            return user;
        }

        public async Task<IdentityResult> AddUserToRolAsync(string RolId, string UserId)
        {
            IdentityUser user = await _userManager.FindByIdAsync(UserId);
            string rolName = _context.AspNetRoles.FirstOrDefault(b => b.Id == RolId).Name;
            IdentityResult result = await _userManager.AddToRoleAsync(user, rolName);
            return result;
        }

        public async Task<List<string>> GetUserInRolesAsync(string UserId)
        {
            List<string> names = new List<string>();
            IdentityUser user = await _userManager.FindByIdAsync(UserId);
            IQueryable<IdentityRole> roles = _roleManager.Roles;
            foreach (var rol in roles.ToList())
            {
                if(await _userManager.IsInRoleAsync(user, rol.Name))
                {
                    names.Add(rol.Name);
                }
            }
            return names;
        }
    }
}
