using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Producto = new HashSet<Producto>();
        }
        [Key]
        public int IdMarca { get; set; }
        public int? Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
