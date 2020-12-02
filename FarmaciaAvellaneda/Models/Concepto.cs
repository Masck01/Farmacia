using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Concepto
    {
        public Concepto()
        {
            DetalleLiquidacion = new HashSet<DetalleLiquidacion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte? Tipo { get; set; }
        public double? Monto { get; set; }
        public bool? Exento { get; set; }
        public int? Unidad { get; set; }

        public virtual ICollection<DetalleLiquidacion> DetalleLiquidacion { get; set; }
    }
}
