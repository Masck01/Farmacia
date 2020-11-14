using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class Concepto
    {
        public Concepto()
        {
            DetalleLiquidacion = new HashSet<DetalleLiquidacion>();
        }
        [Key]
        public int IdConcepto { get; set; }
        public string Descripcion { get; set; }
        public byte? Tipo { get; set; }
        public double? MontoFijo { get; set; }
        public double? MontoVariable { get; set; }

        public virtual ICollection<DetalleLiquidacion> DetalleLiquidacion { get; set; }
    }
}
