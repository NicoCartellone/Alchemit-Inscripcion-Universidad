using Inscripcion_Universidad.Models.Dominio;
using System;

namespace Inscripcion_Universidad.Models.ViewModels.HistorialAcademico
{
    public class ViewModelsHistorial
    {
        public Guid Id { get; set; }
        public virtual Materia Materia { get; set; }
        public Guid? IdMateria { get; set; }
        public DateTime FechaExamen { get; set; }
        public decimal Nota { get; set; }
    }
}