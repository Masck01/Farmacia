using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Compra
    {
        public Compra()
        {
            LineaCompra = new HashSet<LineaCompra>();
            MovimientoCaja = new HashSet<MovimientoCaja>();
            Proveedor = new HashSet<Proveedor>();
        }

        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Total { get; set; }

        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
        public virtual ICollection<MovimientoCaja> MovimientoCaja { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
