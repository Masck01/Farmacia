using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Capacidad
    {
        public int IdCapacidad { get; set; }
        public int? Cantidad { get; set; }
        public byte? Estado { get; set; }
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
