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
    public class CorrelativasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Correlativas
        public ActionResult Index()
        {
            return View(db.Correlativas.ToList());
        }

        // GET: Correlativas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correlativa correlativa = db.Correlativas.Find(id);
            if (correlativa == null)
            {
                return HttpNotFound();
            }
            return View(correlativa);
        }

        // GET: Correlativas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Correlativas/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCorrelativa")] Correlativa correlativa)
        {
            if (ModelState.IsValid)
            {
                correlativa.Id = Guid.NewGuid();
                db.Correlativas.Add(correlativa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(correlativa);
        }

        // GET: Correlativas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correlativa correlativa = db.Correlativas.Find(id);
            if (correlativa == null)
            {
                return HttpNotFound();
            }
            return View(correlativa);
        }

        // POST: Correlativas/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCorrelativa")] Correlativa correlativa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(correlativa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(correlativa);
        }

        // GET: Correlativas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correlativa correlativa = db.Correlativas.Find(id);
            if (correlativa == null)
            {
                return HttpNotFound();
            }
            return View(correlativa);
        }

        // POST: Correlativas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Correlativa correlativa = db.Correlativas.Find(id);
            db.Correlativas.Remove(correlativa);
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
