using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class InscripcionMateria : EntityBase
    {
        [ForeignKey("Materia_Id")]
        [Display(Name ="Materia")]
        public virtual Materia Materia { get; set; }
        public Guid? Materia_Id { get; set; }

        [ForeignKey("Estudiante_Id")]

        public virtual Estudiante Estudiante { get; set; }
        public Guid? Estudiante_Id { get; set; }
    }
}