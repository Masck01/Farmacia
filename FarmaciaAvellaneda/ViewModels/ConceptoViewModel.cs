using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaAvellaneda.ViewModels
{
    public class ConceptoViewModel
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public Tipos Tipo { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Monto { get; set; }
        [Required]
        public bool Exento { get; set; }
    }
    public enum Tipos
    {
        Haber = 1,
        Deduccion = 0
    }
}
