
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaAvellaneda.ViewModels
{
    public class EmpleadoViewModel
    {
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Domicilio { get; set; }
        [Required]
        [RegularExpression(@"^[20|23|24|27|30|33|34]+\d{8}.\d$", ErrorMessage = "Cuit Invalido")]
        public string Cuit { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [Required]
        public Estados Estado { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string CBU { get; set; }
        [Required]
        public string Cuenta { get; set; }
        [Required]
        public string Banco { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string roles { get; set; }

    }
    public enum Estados
    {
        inactivo,
        activo
    }
}
