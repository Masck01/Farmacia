using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class SubCategoriaProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaProductoId { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
    }
}
