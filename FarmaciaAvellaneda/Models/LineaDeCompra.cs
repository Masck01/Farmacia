using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class LineaDeCompra
    {
        public int IdLineadecompra { get; set; }
        public double? Subtotal { get; set; }
        public int? Cantidad { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
