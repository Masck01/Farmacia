using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Caja
    {
        public Caja()
        {
            MovimientoCaja = new HashSet<MovimientoCaja>();
        }

        public int IdCaja { get; set; }
        public string Nombre { get; set; }
        public byte? Estado { get; set; }
        public double? Saldo { get; set; }

        public virtual ICollection<MovimientoCaja> MovimientoCaja { get; set; }
    }
}
