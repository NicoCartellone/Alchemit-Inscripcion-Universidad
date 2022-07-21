using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Estudiante : EntityBase
    {
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [ForeignKey("Carrera_Id")]
        [Display(Name = "Carrera")]
        public virtual Carrera Carrera { get; set; }
        public Guid? Carrera_Id { get; set; }

        [ForeignKey("Materia_Id")]
        [Display(Name = "Materia")]
        public virtual Materia Materia { get; set; }
        public Guid? Materia_Id { get; set; }

        [ForeignKey("HistorialAcademico_Id")]
        public virtual HistorialAcademico HistorialAcademico { get; set; }
        public Guid? HistorialAcademico_Id { get; set; }
    }
}