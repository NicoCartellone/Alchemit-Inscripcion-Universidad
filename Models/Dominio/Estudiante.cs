using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Estudiante : EntityBase
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }


        [ForeignKey("Carrera_Id")]
        public virtual Carrera Carrera { get; set; }

        public Guid? Carrera_Id { get; set; }

    }
}