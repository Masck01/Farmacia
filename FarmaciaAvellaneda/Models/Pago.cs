using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public double? Monto { get; set; }
        public double? Vuelto { get; set; }
        public int VentaId { get; set; }

        public virtual Venta Venta { get; set; }
    }
}
