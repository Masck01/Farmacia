using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class LineaVenta
    {
        public int Id { get; set; }
        public double? Subtotal { get; set; }
        public int? Cantidad { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
