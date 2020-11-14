using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            GrupoFamiliar = new HashSet<GrupoFamiliar>();
            Liquidacion = new HashSet<Liquidacion>();
            Venta = new HashSet<Venta>();
        }
        [Key]
        public int IdEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int? Cuit { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public byte? Estado { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<GrupoFamiliar> GrupoFamiliar { get; set; }
        public virtual ICollection<Liquidacion> Liquidacion { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
