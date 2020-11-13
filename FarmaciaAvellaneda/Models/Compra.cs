﻿using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Compra
    {
        public Compra()
        {
            LineaDeCompra = new HashSet<LineaDeCompra>();
            MovimientoCaja = new HashSet<MovimientoCaja>();
            Proveedor = new HashSet<Proveedor>();
        }

        public int IdCompra { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Total { get; set; }

        public virtual ICollection<LineaDeCompra> LineaDeCompra { get; set; }
        public virtual ICollection<MovimientoCaja> MovimientoCaja { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
