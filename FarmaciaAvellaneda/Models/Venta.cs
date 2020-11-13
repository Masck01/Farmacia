using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Venta
    {
        public Venta()
        {
            LineaDeVenta = new HashSet<LineaDeVenta>();
            MovimientoCaja = new HashSet<MovimientoCaja>();
        }

        public int IdVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public double? Total { get; set; }
        public byte? Estado { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual Pago Pago { get; set; }
        public virtual ICollection<LineaDeVenta> LineaDeVenta { get; set; }
        public virtual ICollection<MovimientoCaja> MovimientoCaja { get; set; }
    }
}
