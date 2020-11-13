﻿using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public int? Cuit { get; set; }
        public string Telefono { get; set; }
        public int CompraId { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
