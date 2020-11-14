using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class Capacidad
    {
        [Key]
        public int IdCapacidad { get; set; }
        public int? Cantidad { get; set; }
        public byte? Estado { get; set; }
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
