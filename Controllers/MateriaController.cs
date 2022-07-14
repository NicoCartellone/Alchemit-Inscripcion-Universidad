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
            return View();
        }

        //POST: Create materia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, NombreMateria, IdCarrera, Semestre")] Materia Materia)
        {
            if (ModelState.IsValid)
            {
                db.Materias.Add(Materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Materia);
        }

        //GET: Edit materia
        public ActionResult Edit(Guid? id)
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

        //POST: Edit materia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, NombreMateria, IdCarrera, Semestre")] Materia Materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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