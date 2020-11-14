using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Capacidad = new HashSet<Capacidad>();
            LineaDeCompra = new HashSet<LineaDeCompra>();
            LineaDeVenta = new HashSet<LineaDeVenta>();
        }
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public int? Stock { get; set; }
        public double? PrecioCompra { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public double? PrecioVenta { get; set; }
        public byte? Estado { get; set; }
        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public int ProveedorId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<Capacidad> Capacidad { get; set; }
        public virtual ICollection<LineaDeCompra> LineaDeCompra { get; set; }
        public virtual ICollection<LineaDeVenta> LineaDeVenta { get; set; }
    }
}
