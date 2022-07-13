using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Estudiante : EntityBase
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public Guid IdCarrera { get; set; }
        public Guid IdMateria { get; set; }
        public virtual Carrera Carrera { get; set; }
        public virtual Materia Materia { get; set; }
    }
}