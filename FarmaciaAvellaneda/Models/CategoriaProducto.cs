using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Producto = new HashSet<Producto>();
            SubCategoriaProducto = new HashSet<SubCategoriaProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte? Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<SubCategoriaProducto> SubCategoriaProducto { get; set; }
    }
}
