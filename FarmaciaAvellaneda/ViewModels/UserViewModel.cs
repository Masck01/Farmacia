using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaAvellaneda.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserViewModel()
        {

        }

        public UserViewModel(string email, string password, bool emailConfirmed)
        {
            Email = email;
            Password = password;
            EmailConfirmed = emailConfirmed;

        }
    }
}
