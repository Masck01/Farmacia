using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Empleado = new HashSet<Empleado>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
