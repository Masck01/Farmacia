using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class CajaAhorro
    {
        public Guid Id { get; set; }
        public string Cbu { get; set; }
        public string Cuenta { get; set; }
        public string Banco { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
