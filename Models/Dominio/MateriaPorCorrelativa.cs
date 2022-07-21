using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class MateriaPorCorrelativa : EntityBase
    {
        [ForeignKey("Materia_Id")]
        [Display(Name = "Materia")]
        public virtual Materia Materia { get; set; }
        public Guid? Materia_Id { get; set; }

        [ForeignKey("PrimeraCorrelativa_Id")]
        [Display (Name = "Primera Materia Correlativa")]
        public virtual Correlativa PrimeraCorrelativa { get; set; }

        public Guid? PrimeraCorrelativa_Id { get; set; }

        [ForeignKey("SegundaCorrelativa_Id")]
        [Display(Name = "Segunda Materia Correlativa")]
        public virtual Correlativa SegundaCorrelativa { get; set; }
        public Guid? SegundaCorrelativa_Id { get; set; }
    }
}