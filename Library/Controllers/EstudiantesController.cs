using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class EstudiantesController : Controller

    {
        private LibraryUrContext db = new LibraryUrContext();

        public ActionResult Index()
        {
            return View(db.Estudiantes.ToList());
        }
        //-------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Estudiante estudiante)
        {
            db.Estudiantes.Add(estudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //-------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Edit(Estudiante estudiante)
        {
            db.Entry(estudiante).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //-------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Details(int? id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            return View(estudiante);
        }
        //-------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            db.Estudiantes.Remove(estudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //-------------------------------------------------------------------------------------------------------------
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