using FarmaciaAvellaneda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaAvellaneda.ViewModels
{
    public class LiquidacionViewModel
    {
        public Empresa Empresa { get; set; }
        public Empleado Empleado { get; set; }
        public Concepto Concepto { get; set; }
        public Liquidacion Liquidacion { get; set; }
        public ICollection<Concepto> Conceptos { get; set; }
    }
}
