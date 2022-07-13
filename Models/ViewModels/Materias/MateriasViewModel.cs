using Inscripcion_Universidad.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.ViewModels.Materias
{
    public class MateriasViewModel
    {
        #region Constructores

        public MateriasViewModel()
        {

        }

        public MateriasViewModel(Materia Materia, Carrera Carrera)
        {
            this.Id = Materia.Id;
            this.NombreMateria = Materia.NombreMateria;
            this.Semestre = Materia.Semestre;
            this.IdCarrera = Carrera.Id;
            this.NombreCarrera = Carrera.NombreCarrera;
        }

        #endregion

        #region Propiedades
        public Guid Id { get; set; }
        public string NombreMateria { get; set; }
        public bool Semestre { get; set; }
        public Guid IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        #endregion

        #region Metodos

        //public Carrera ToEntity()
        //{
        //    return new Carrera
        //    {
        //        Id = Guid.NewGuid(),
        //        NombreCarrera = this.NombreCarrera,
        //    };
        //}

        public Materia ToEntity(Carrera carrera)
        {
            return new Materia
            {
                Id = Guid.NewGuid(),
                NombreMateria = this.NombreMateria,
                IdCarrera = carrera.Id,
            };
        }

        #endregion
    }
}