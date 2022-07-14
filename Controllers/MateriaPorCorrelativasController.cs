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
    public class MateriaPorCorrelativasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MateriaPorCorrelativas
        public ActionResult Index()
        {
            var materiasporcorrelativas = db.MateriaPorCorrelativas.Include(m => m.PrimeraCorrelativa).Include(m => m.SegundaCorrelativa).Include(m => m.Materia);
            return View(materiasporcorrelativas.ToList());
        }

        // GET: MateriaPorCorrelativas/Create
        public ActionResult Create()
        {
            ViewBag.id_materia = new SelectList(db.Materias, "Id", "NombreMateria");
            ViewBag.id_correlativa1 = new SelectList(db.Correlativas, "Id", "NombreCorrelativa");
            ViewBag.id_correlativa2 = new SelectList(db.Correlativas, "Id", "NombreCorrelativa");
            return View();
        }

        // POST: MateriaPorCorrelativas/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Materia_Id, PrimeraCorrelativa_Id, SegundaCorrelativa_Id")] MateriaPorCorrelativa materiaPorCorrelativa)
        {
            if (ModelState.IsValid)
            {
                materiaPorCorrelativa.Id = Guid.NewGuid();
                db.MateriaPorCorrelativas.Add(materiaPorCorrelativa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_materia = new SelectList(db.Materias, "Id", "NombreMateria", materiaPorCorrelativa.Materia_Id);
            ViewBag.id_correlativa1 = new SelectList(db.Correlativas, "Id", "NombreCorrelativa", materiaPorCorrelativa.PrimeraCorrelativa_Id);
            ViewBag.id_correlativa2 = new SelectList(db.Correlativas, "Id", "NombreCorrelativa", materiaPorCorrelativa.SegundaCorrelativa_Id);
            return View(materiaPorCorrelativa);
        }

        // GET: MateriaPorCorrelativas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaPorCorrelativa materiaPorCorrelativa = db.MateriaPorCorrelativas.Find(id);
            if (materiaPorCorrelativa == null)
            {
                return HttpNotFound();
            }
            return View(materiaPorCorrelativa);
        }

        // POST: MateriaPorCorrelativas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MateriaPorCorrelativa materiaPorCorrelativa = db.MateriaPorCorrelativas.Find(id);
            db.MateriaPorCorrelativas.Remove(materiaPorCorrelativa);
            db.SaveChanges();
            return RedirectToAction("Index");
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
