using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Liquidacion
    {
        public Liquidacion()
        {
            DetalleLiquidacion = new HashSet<DetalleLiquidacion>();
        }

        public int Id { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public double? SalarioNeto { get; set; }
        public DateTime? PeriodoLiquidacion { get; set; }
        public byte? Estado { get; set; }
        public double? Retenciones { get; set; }
        public double? SalarioBruto { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<DetalleLiquidacion> DetalleLiquidacion { get; set; }
    }
}
