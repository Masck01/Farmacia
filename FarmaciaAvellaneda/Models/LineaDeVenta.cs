using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class LineaDeVenta
    {
        [Key]
        public int IdLineadeventa { get; set; }
        public double? Subtotal { get; set; }
        public int? Cantidad { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
