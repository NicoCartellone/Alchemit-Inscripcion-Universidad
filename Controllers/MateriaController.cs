using Inscripcion_Universidad.Models;
using Inscripcion_Universidad.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Inscripcion_Universidad.Controllers
{
    public class MateriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Materia
        public ActionResult Index()
        {
            return View(db.Materias.ToList());
        }

        // GET: Create materia
        public ActionResult Create()
        {
            ViewBag.Carrera = new SelectList(db.Carreras, "Id", "NombreCarrera");
            return View();
        }

        //POST: Create materia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, NombreMateria, Carrera_Id")] Materia Materia)
        {
            if (ModelState.IsValid)
            {
                Materia.Id = Guid.NewGuid();
                db.Materias.Add(Materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Carrera = new SelectList(db.Carreras, "Id", "NombreCarrera", Materia.Id);
            return View(Materia);
        }


        //GET: Delete materia
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia Materia = db.Materias.Find(id);
            if (Materia == null)
            {
                return HttpNotFound();
            }
            return View(Materia);
        }

        //POST: Delete materia
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Materia Materia = db.Materias.Find(id);
            db.Materias.Remove(Materia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}