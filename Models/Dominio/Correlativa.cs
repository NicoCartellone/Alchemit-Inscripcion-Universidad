using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Correlativa : EntityBase
    {
        [Required]
        public string NombreCorrelativa { get; set; }
        public int IdCarrera { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<MateriaPorCorrelativa> MateriaPorCorrelativas { get; set; }
    }
}