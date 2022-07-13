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
using Inscripcion_Universidad.Models.ViewModels.Carreras;

namespace Inscripcion_Universidad.Controllers
{
    public class CarrerasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carreras
        public ActionResult Index()
        {
            List<Carrera> Carreras = db.Carreras.ToList();
            List<CarrerasListaViewModel> model = new List<CarrerasListaViewModel>();
            foreach(Carrera Carrera in Carreras)
            {
                model.Add(new CarrerasListaViewModel { Id = Carrera.Id, NombreCarrera = Carrera.NombreCarrera });
            }
            return View(model);
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            return View(new CarrerasViewModel());
        }

        // POST: Carreras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarrerasViewModel carrera)
        {
            if (ModelState.IsValid)
            {
                db.Carreras.Add(carrera.ToEntity());
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrera);
        }

        // GET: Carreras/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            CarrerasViewModel model = new CarrerasViewModel(carrera);
           
            return View(model);
        }

        // POST: Carreras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarrerasViewModel model)
        {
            if (ModelState.IsValid)
            {
                Carrera Carrera = db.Carreras.Find(model.Id);
                Carrera.NombreCarrera = model.NombreCarrera;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Carreras/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            CarrerasViewModel model = new CarrerasViewModel(carrera);
            if( model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(CarrerasViewModel model)
        {
                Carrera carrera = db.Carreras.Find(model.Id);
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
