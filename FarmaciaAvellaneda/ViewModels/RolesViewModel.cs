using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaAvellaneda.ViewModels
{
    public class RolesViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float Monto { get; set; }
    }
}
