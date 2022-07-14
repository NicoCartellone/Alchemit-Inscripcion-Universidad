using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Carrera_Id")]
        public virtual Carrera Carrera { get; set; }

        public Guid? Carrera_Id { get; set; }

        [ForeignKey("Materia_Id")]
        public virtual Materia Materia { get; set; }
        public Guid? Materia_Id { get; set; }

        [ForeignKey("HistorialAcademico_Id")]
        public virtual HistorialAcademico HistorialAcademico { get; set; }
        public Guid? HistorialAcademico_Id { get; set; }

    }
}