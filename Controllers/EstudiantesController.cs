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

        public ActionResult ListadeInscriptos()
        {
            return View(db.Estudiantes.ToList());
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

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(Guid? id)
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

        // POST: Estudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,IdCarrera,IdMateria")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
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