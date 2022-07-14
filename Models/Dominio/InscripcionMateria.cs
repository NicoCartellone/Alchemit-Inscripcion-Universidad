using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class InscripcionMateria : EntityBase
    {
        [ForeignKey("Materia_Id")]
        public virtual Materia Materia { get; set; }
        public Guid? Materia_Id { get; set; }

        [ForeignKey("Estudiante_Id")]
        public virtual Estudiante Estudiante { get; set; }
        public Guid? Estudiante_Id { get; set; }



    }
}