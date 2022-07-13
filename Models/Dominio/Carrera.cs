using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Carrera : EntityBase
    {
        [Required]
        public string NombreCarrera { get; set; }
        public virtual ICollection<Materia> Materia { get; set; }
    }
}