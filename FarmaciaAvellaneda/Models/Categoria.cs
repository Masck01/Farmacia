using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
            SubCategoria = new HashSet<SubCategoria>();
        }
        [Key]
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public byte? Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<SubCategoria> SubCategoria { get; set; }
    }
}
