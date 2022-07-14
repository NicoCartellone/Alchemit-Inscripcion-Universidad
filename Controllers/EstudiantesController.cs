using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inscripcion_Universidad.Models;
using Inscripcion_Universidad.Models.Dominio;

namespace Inscripcion_Universidad.Controllers
{
    public class EstudiantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Estudiantes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Solicitudes()
        {
            return View();
        }

        public ActionResult ListadeInscriptos()
        {
            return View(db.Estudiantes.ToList());
        }

        public ActionResult ListadeInscripciones()
        {
            return View(db.InscripcionesMaterias.ToList());
        }


        // GET: Estudiantes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Inscribirse
        public ActionResult Inscribirse()
        {

            ViewBag.Carrera = new SelectList(db.Carreras, "Id", "NombreCarrera");
            return View();
        }

        // POST: Estudiantes/Inscribirse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscribirse([Bind(Include = "Id,Nombre,Apellido,Carrera_Id")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante.Id = Guid.NewGuid();
                db.Estudiantes.Add(estudiante);
                db.SaveChanges();

                return RedirectToAction("About", "Home");


            }
            ViewBag.Carrera = new SelectList(db.Carreras, "Id", "NombreCarrera", estudiante.Id);

            return View(estudiante);
        }

        //GET: Estudiantes/InscribirseMateria
        public ActionResult InscribirseMateria()
        {

            ViewBag.Materia = new SelectList(db.Materias, "Id", "NombreMateria");
            ViewBag.Estudiante = new SelectList(db.Estudiantes, "Id", "Apellido");
            return View();
        }

        // POST: Estudiantes/InscribirseMateria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InscribirseMateria([Bind(Include = "Materia_Id, Estudiante_Id")] InscripcionMateria InscripcionMateria)
        {
            if (ModelState.IsValid)
            {
                InscripcionMateria.Id = Guid.NewGuid();
                db.InscripcionesMaterias.Add(InscripcionMateria);
                db.SaveChanges();

                return RedirectToAction("About", "Home");


            }
            ViewBag.Materia = new SelectList(db.Materias, "Id", "NombreMateria", InscripcionMateria.Id);
            ViewBag.Estudiante = new SelectList(db.Materias, "Id", "Apellido", InscripcionMateria.Id);

            return View(InscripcionMateria);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            db.Estudiantes.Remove(estudiante);
            db.SaveChanges();
            return RedirectToAction("ListadeInscriptos");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}