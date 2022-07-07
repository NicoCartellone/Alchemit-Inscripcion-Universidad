using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class MateriaPorCorrelativa : EntityBase
    {
        public int IdCarrera { get; set; }
        public int IdMateria { get; set; }
        public int IdPrimeraCorrelativa { get; set; }
        public int IdSegundaCorrelativa { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual Correlativa PrimeraCorrelativa { get; set; }
        public virtual Correlativa SegundaCorrelativa { get; set; }
    }
}