using System;
using System.ComponentModel.DataAnnotations;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}