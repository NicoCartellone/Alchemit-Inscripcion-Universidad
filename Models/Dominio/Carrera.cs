using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Carrera : EntityBase
    {
        [Required]
        [Display(Name ="Nombre de Carrera")]
        public string NombreCarrera { get; set; }
        public virtual ICollection<Materia> Materia { get; set; }
    }
}