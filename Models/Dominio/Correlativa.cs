using System.ComponentModel.DataAnnotations;

namespace Inscripcion_Universidad.Models.Dominio
{
    public class Correlativa : EntityBase
    {
        [Required]
        [Display(Name = "Nombre de Correlativa")]
        public string NombreCorrelativa { get; set; }
    }
}