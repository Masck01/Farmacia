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
        public string SalarioDescripto { get; set; }
        public string LugarPago { get; set; }
        public string PeriodoLiquidacion { get; set; }
        public byte? Estado { get; set; }
        public double? TotalRemunerado { get; set; }
        public double? TotalDeduccion { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<DetalleLiquidacion> DetalleLiquidacion { get; set; }
    }
}
