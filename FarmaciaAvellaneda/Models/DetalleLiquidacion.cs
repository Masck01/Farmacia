using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class DetalleLiquidacion
    {
        public int Id { get; set; }
        public int? Unidad { get; set; }
        public string Haber { get; set; }
        public string Deduccion { get; set; }
        public int ConceptoId { get; set; }
        public int LiquidacionId { get; set; }

        public virtual Concepto Concepto { get; set; }
        public virtual Liquidacion Liquidacion { get; set; }
    }
}
