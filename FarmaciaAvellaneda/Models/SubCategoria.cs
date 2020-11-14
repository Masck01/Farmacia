using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAvellaneda.Models
{
    public partial class SubCategoria
    {
        [Key]
        public int IdSubcategoria { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
