using Inscripcion_Universidad.Models;
using Inscripcion_Universidad.Models.Dominio;
using Inscripcion_Universidad.Models.ViewModels.HistorialAcademico;
using Rotativa;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Inscripcion_Universidad.Controllers
{
    public class HistorialAcademicoController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: HistorialAcademico
        public ActionResult Index()
        {
            var listaHistorial = _context.HistorialesAcademicos.ToList();
            return View(listaHistorial);
        }

        public ActionResult Create() 
        {
            ViewBag.Materias = new SelectList(_context.Materias, "Id", "NombreMateria");
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,IdMateria, FechaExamen, Nota")] HistorialAcademico historial) 
        {

            if (ModelState.IsValid)
            {
                historial.Id = Guid.NewGuid();
                _context.HistorialesAcademicos.Add(historial);
                _context.SaveChanges();
                return RedirectToAction("Index", "HistorialAcademico");

            }
            ViewBag.Materia = new SelectList(_context.Materias, "Id", "NombreMateria", historial.Id);

            return View(historial);
        }

        public ActionResult Editar(int id)
        { 
            ViewModelsHistorial model = new ViewModelsHistorial();
            var historialAcademico = _context.HistorialesAcademicos.Find(id);
            model.Id = historialAcademico.Id;
            model.IdMateria = historialAcademico.IdMateria;
            model.Materia = historialAcademico.Materia;
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ViewModelsHistorial historial)
        {
            if (ModelState.IsValid)
            {
                var historialView = _context.HistorialesAcademicos.Find(historial.Id);
                historialView.IdMateria = historial.IdMateria;
                historialView.Materia = _context.Materias.Find(historialView.IdMateria);
                historialView.FechaExamen = historial.FechaExamen;
                historialView.Nota = historial.Nota;

                _context.Entry(historialView).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index", "HistorialAcademico");
            }
            return View(historial);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var historial = _context.HistorialesAcademicos.Find(id);
            if (historial == null)
                return HttpNotFound();

            _context.HistorialesAcademicos.Remove(historial);
            _context.SaveChanges();
            return RedirectToAction("Index", "HistorialAcademico");
        }
    }
}