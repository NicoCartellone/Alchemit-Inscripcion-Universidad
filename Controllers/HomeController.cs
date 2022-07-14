using Inscripcion_Universidad.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscripcion_Universidad.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[ValidarSesion]
        //[Authorize(Roles = "Estudiante")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[ValidarSesion]
        //[Authorize(Roles = "Profesor")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[ValidarSesion]
        //[Authorize(Roles = "Admin")]
        public ActionResult Administradores()
        {
   
            return View();
        }
    }
}