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
    public class CarrerasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carreras
        public ActionResult Index()
        {
            return View(db.Carreras.ToList());
        }

        //GET: Carrera Details
        public ActionResult Details(Guid? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            if(carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        //GET: Carrera Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Carrera Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCarrera")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                carrera.Id = Guid.NewGuid();
                db.Carreras.Add(carrera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        //GET: Carrera Edit
        public ActionResult Edit(Guid? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            if(carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        //POST: Carrera Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCarrera")]Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        //GET: Carrera Delete
        public ActionResult Delete(Guid? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            if(carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        //POST: Carrera Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Carrera carrera = db.Carreras.Find(id);
            db.Carreras.Remove(carrera);
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