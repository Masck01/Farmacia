using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class SubCategoria
    {
        public int IdSubcategoria { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
