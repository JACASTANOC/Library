using Library.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class PrestamosController : Controller
    {
        private LibraryUrContext db = new LibraryUrContext();

        public ActionResult Index()
        {
            var prestamos = db.Prestamos.Include(p => p.Estudiante).Include(p => p.Libro);
            return View(prestamos.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombre");
            ViewBag.LibroId = new SelectList(db.Libros, "LibroId", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrestamoId,EstudianteId,LibroId,FechaPrestamo,FechaDevolucion,FechaDevolucionReal,Estado")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                // Establecer la fecha de préstamo como la fecha actual
                prestamo.FechaPrestamo = DateTime.Now;

                // Verificar disponibilidad del libro
                var libro = db.Libros.Find(prestamo.LibroId);
                if (libro.CopiasDisponibles > 0)
                {
                    libro.CopiasDisponibles--;

                    db.Prestamos.Add(prestamo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "No hay copias disponibles de este libro.");
                }
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombre", prestamo.EstudianteId);
            ViewBag.LibroId = new SelectList(db.Libros, "LibroId", "Titulo", prestamo.LibroId);
            return View(prestamo);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombre", prestamo.EstudianteId);
            ViewBag.LibroId = new SelectList(db.Libros, "LibroId", "Titulo", prestamo.LibroId);
            return View(prestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrestamoId,EstudianteId,LibroId,FechaPrestamo,FechaDevolucion,FechaDevolucionReal,Estado")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombre", prestamo.EstudianteId);
            ViewBag.LibroId = new SelectList(db.Libros, "LibroId", "Titulo", prestamo.LibroId);
            return View(prestamo);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamos.Find(id);

            // Devolver una copia al libro si el préstamo se elimina
            var libro = db.Libros.Find(prestamo.LibroId);
            libro.CopiasDisponibles++;

            db.Prestamos.Remove(prestamo);
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