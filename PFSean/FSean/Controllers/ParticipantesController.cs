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
    public class ParticipantesController : Controller
    {
        private FSeanDB db = new FSeanDB();

        // GET: Participantes
        public ActionResult Index()
        {
            var participante = db.Participante.Include(p => p.Equipo);
            return View(participante.ToList());
        }

        // GET: Participantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // GET: Participantes/Create
        public ActionResult Create()
        {
            ViewBag.iEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion");
            return View();
        }

        // POST: Participantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iIdPartcipante,iEquipo,bEntrenador")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Participante.Add(participante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", participante.iEquipo);
            return View(participante);
        }

        // GET: Participantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            ViewBag.iEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", participante.iEquipo);
            return View(participante);
        }

        // POST: Participantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iIdPartcipante,iEquipo,bEntrenador")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", participante.iEquipo);
            return View(participante);
        }

        // GET: Participantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participante participante = db.Participante.Find(id);
            db.Participante.Remove(participante);
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
