

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5001.Models;

namespace MVC5001.Controllers
{
    public class calificacionesController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: calificaciones
        public ActionResult Index()
        {
            var calificaciones = db.calificaciones.Include(c => c.alumnos).Include(c => c.docentes);
            return View(calificaciones.ToList());
        }

        // GET: calificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calificaciones calificaciones = db.calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            return View(calificaciones);
        }

        // GET: calificaciones/Create
        public ActionResult Create()
        {
            ViewBag.Matricula = new SelectList(db.alumnos, "Matricula", "NombreCompleto");
            ViewBag.Clave = new SelectList(db.docentes, "clave", "NombreCompleto");
            return View();
        }

        // POST: calificaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idc,Matricula,Clave,Parcial1,Parcial2,parcial3")] calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {
                db.calificaciones.Add(calificaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Matricula = new SelectList(db.alumnos, "Matricula", "NombreCompleto", calificaciones.Matricula);
            ViewBag.Clave = new SelectList(db.docentes, "clave", "NombreCompleto", calificaciones.Clave);
            return View(calificaciones);
        }

        // GET: calificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calificaciones calificaciones = db.calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Matricula = new SelectList(db.alumnos, "Matricula", "NombreCompleto", calificaciones.Matricula);
            ViewBag.Clave = new SelectList(db.docentes, "clave", "NombreCompleto", calificaciones.Clave);
            return View(calificaciones);
        }

        // POST: calificaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idc,Matricula,Clave,Parcial1,Parcial2,parcial3")] calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Matricula = new SelectList(db.alumnos, "Matricula", "NombreCompleto", calificaciones.Matricula);
            ViewBag.Clave = new SelectList(db.docentes, "clave", "NombreCompleto", calificaciones.Clave);
            return View(calificaciones);
        }

        // GET: calificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calificaciones calificaciones = db.calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            return View(calificaciones);
        }

        // POST: calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            calificaciones calificaciones = db.calificaciones.Find(id);
            db.calificaciones.Remove(calificaciones);
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
