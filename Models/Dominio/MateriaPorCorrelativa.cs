using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class MateriaPorCorrelativa : EntityBase
    {
        public Guid IdCarrera { get; set; }
        public Guid IdMateria { get; set; }
        public Guid IdPrimeraCorrelativa { get; set; }
        public Guid IdSegundaCorrelativa { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual Correlativa PrimeraCorrelativa { get; set; }
        public virtual Correlativa SegundaCorrelativa { get; set; }
    }
}