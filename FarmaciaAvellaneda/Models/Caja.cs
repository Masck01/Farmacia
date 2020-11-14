using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class Caja
    {
        public Caja()
        {
            MovimientoCaja = new HashSet<MovimientoCaja>();
        }
        [Key]
        public int IdCaja { get; set; }
        public string Nombre { get; set; }
        public byte? Estado { get; set; }
        public double? Saldo { get; set; }

        public virtual ICollection<MovimientoCaja> MovimientoCaja { get; set; }
    }
}
