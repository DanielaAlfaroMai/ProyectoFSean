using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FSean.Models;

namespace FSean.Controllers
{
    public class CapacitacionxVoluntarioController : Controller
    {
        private FSeanDB db = new FSeanDB();

        // GET: CapacitacionxVoluntario
        public ActionResult Index()
        {
            var capacitacionxVoluntario = db.CapacitacionxVoluntario.Include(c => c.Capacitacion).Include(c => c.Voluntario);
            return View(capacitacionxVoluntario.ToList());
        }

        // GET: CapacitacionxVoluntario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapacitacionxVoluntario capacitacionxVoluntario = db.CapacitacionxVoluntario.Find(id);
            if (capacitacionxVoluntario == null)
            {
                return HttpNotFound();
            }
            return View(capacitacionxVoluntario);
        }

        // GET: CapacitacionxVoluntario/Create
        public ActionResult Create()
        {
            ViewBag.iIdCapacitacion = new SelectList(db.Capacitacion, "iId", "vNombre");
            ViewBag.iIdVoluntario = new SelectList(db.Voluntario, "iId", "vLugarTrabajo");
            return View();
        }

        // POST: CapacitacionxVoluntario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iId,iIdCapacitacion,iIdVoluntario")] CapacitacionxVoluntario capacitacionxVoluntario)
        {
            if (ModelState.IsValid)
            {
                db.CapacitacionxVoluntario.Add(capacitacionxVoluntario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iIdCapacitacion = new SelectList(db.Capacitacion, "iId", "vNombre", capacitacionxVoluntario.iIdCapacitacion);
            ViewBag.iIdVoluntario = new SelectList(db.Voluntario, "iId", "vLugarTrabajo", capacitacionxVoluntario.iIdVoluntario);
            return View(capacitacionxVoluntario);
        }

        // GET: CapacitacionxVoluntario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapacitacionxVoluntario capacitacionxVoluntario = db.CapacitacionxVoluntario.Find(id);
            if (capacitacionxVoluntario == null)
            {
                return HttpNotFound();
            }
            ViewBag.iIdCapacitacion = new SelectList(db.Capacitacion, "iId", "vNombre", capacitacionxVoluntario.iIdCapacitacion);
            ViewBag.iIdVoluntario = new SelectList(db.Voluntario, "iId", "vLugarTrabajo", capacitacionxVoluntario.iIdVoluntario);
            return View(capacitacionxVoluntario);
        }

        // POST: CapacitacionxVoluntario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iId,iIdCapacitacion,iIdVoluntario")] CapacitacionxVoluntario capacitacionxVoluntario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capacitacionxVoluntario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iIdCapacitacion = new SelectList(db.Capacitacion, "iId", "vNombre", capacitacionxVoluntario.iIdCapacitacion);
            ViewBag.iIdVoluntario = new SelectList(db.Voluntario, "iId", "vLugarTrabajo", capacitacionxVoluntario.iIdVoluntario);
            return View(capacitacionxVoluntario);
        }

        // GET: CapacitacionxVoluntario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapacitacionxVoluntario capacitacionxVoluntario = db.CapacitacionxVoluntario.Find(id);
            if (capacitacionxVoluntario == null)
            {
                return HttpNotFound();
            }
            return View(capacitacionxVoluntario);
        }

        // POST: CapacitacionxVoluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CapacitacionxVoluntario capacitacionxVoluntario = db.CapacitacionxVoluntario.Find(id);
            db.CapacitacionxVoluntario.Remove(capacitacionxVoluntario);
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
