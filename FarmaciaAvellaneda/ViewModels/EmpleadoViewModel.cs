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
        public int Cuit { get; set; }
        [Required]
        public Estados Estado { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public enum Estados
    {
        inactivo,
        activo
    }
}
