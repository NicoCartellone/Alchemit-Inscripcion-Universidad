using Inscripcion_Universidad.Models.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.ViewModels.Carreras
{
    public class CarrerasViewModel
    {
        #region Constrtuctores

        public CarrerasViewModel()
        {

        }
        public CarrerasViewModel(Carrera Carrera)
        {
            this.NombreCarrera = Carrera.NombreCarrera;
            this.Id = Carrera.Id;
        }

        #endregion

        #region Propiedades
        public Guid Id { get; set; }

        [Required]
        public string NombreCarrera { get; set; }
        #endregion

        #region Metodos

        public Carrera ToEntity()
        {
            return new Carrera
            {
                NombreCarrera = this.NombreCarrera,
                Id = Guid.NewGuid()
            };
        }

        #endregion
    }
}