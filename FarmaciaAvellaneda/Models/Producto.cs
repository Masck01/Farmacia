using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Capacidad = new HashSet<Capacidad>();
            LineaCompra = new HashSet<LineaCompra>();
            LineaVenta = new HashSet<LineaVenta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public int? Stock { get; set; }
        public double? PrecioCompra { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public double? PrecioVenta { get; set; }
        public byte? Estado { get; set; }
        public int CategoriaProductoId { get; set; }
        public int MarcaId { get; set; }
        public int ProveedorId { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<Capacidad> Capacidad { get; set; }
        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
        public virtual ICollection<LineaVenta> LineaVenta { get; set; }
    }
}
