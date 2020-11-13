using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class MovimientoCaja
    {
        public int IdMovimientoCaja { get; set; }
        public string Descripcion { get; set; }
        public int CajaId { get; set; }
        public int CompraId { get; set; }
        public int VentaId { get; set; }

        public virtual Caja Caja { get; set; }
        public virtual Compra Compra { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
