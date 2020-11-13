using System;
using System.Collections.Generic;

namespace FarmaciaAvellaneda.Models
{
    public partial class GrupoFamiliar
    {
        public int IdGrupofamiliar { get; set; }
        public int? Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Parentesco { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
