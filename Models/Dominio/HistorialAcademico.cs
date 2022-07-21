using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class HistorialAcademico :EntityBase
    {
        [ForeignKey("IdMateria")]
        [Display(Name = "Materia") ]
        public virtual Materia Materia { get; set; }
        public Guid? IdMateria { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaExamen { get; set; }
        [Display(Name = "Nota")]
        public decimal Nota { get; set; }
    }
}