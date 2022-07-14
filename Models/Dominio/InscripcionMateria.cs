using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class InscripcionMateria : EntityBase
    {
        public Guid IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public Guid IdMateria { get; set; }
        public string NombreMateria { get; set; }
    }
}