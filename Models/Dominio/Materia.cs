using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Materia : EntityBase
    {
        [Required]
        public string NombreMateria { get; set; }
        public Guid IdCarrera { get; set; }
        [Required]
        public bool Semestre { get; set; }
        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<MateriaPorCorrelativa> MateriaPorCorrelativas { get; set; }
    }
}