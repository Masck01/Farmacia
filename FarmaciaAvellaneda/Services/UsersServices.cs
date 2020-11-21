using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FarmaciaAvellaneda.ViewModels;
using FarmaciaAvellaneda.Data;
using FarmaciaAvellaneda.Models;

namespace FarmaciaAvellaneda.Services
{
    public class UsersServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly FarmaciaAvellanedaContext _context;
        public UsersServices(UserManager<IdentityUser> userManager,
            FarmaciaAvellanedaContext context)
        {
            _userManager = userManager;
            _context = context;

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
    }
}
