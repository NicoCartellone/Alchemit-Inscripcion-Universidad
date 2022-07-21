using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Materia : EntityBase
    {
        [Required]
        [Display(Name = "Nombre De Materia")]
        public string NombreMateria { get; set; }

        public virtual ICollection<MateriaPorCorrelativa> MateriaPorCorrelativas { get; set; }

        [ForeignKey("Carrera_Id")]
        [Display(Name ="Carrera")]
        public virtual Carrera Carrera { get; set; }
        public Guid? Carrera_Id { get; set; }
    }
}