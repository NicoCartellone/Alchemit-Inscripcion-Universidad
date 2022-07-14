using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class HistorialAcademico : EntityBase
    {
        [ForeignKey("IdMateria")]
        public virtual Materia Materia { get; set; }

        public Guid? IdMateria { get; set; }

        public DateTime FechaExamen { get; set; }
        public decimal Nota { get; set; }
    }
}