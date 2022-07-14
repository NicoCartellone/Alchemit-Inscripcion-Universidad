using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class MateriaPorCorrelativa : EntityBase
    {
        [ForeignKey("Materia_Id")]
        public virtual Materia Materia { get; set; }
        public Guid? Materia_Id { get; set; }

        [ForeignKey("PrimeraCorrelativa_Id")]
        public virtual Correlativa PrimeraCorrelativa { get; set; }

        public Guid? PrimeraCorrelativa_Id { get; set; }

        [ForeignKey("SegundaCorrelativa_Id")]
        public virtual Correlativa SegundaCorrelativa { get; set; }

        public Guid? SegundaCorrelativa_Id { get; set; }





    }
}