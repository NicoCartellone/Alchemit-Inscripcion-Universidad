using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscripcion_Universidad.Models.ViewModels
{

    
    public class InscripcionEstudianteViewModel
    {

        #region Constructores
        public Guid IdEstudiante { get; set; }
        public string Nombre { get; set; }
       
        public string Apellido { get; set; }
        public Guid IdCarrera { get; set; }
        public string NombreCarrera { get; set; }

        #endregion 

      
        }
    }
