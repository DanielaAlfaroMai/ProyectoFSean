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
    public class EquipoxCompetenciasController : Controller
    {
        private FSeanDB db = new FSeanDB();

        // GET: EquipoxCompetencias
        public ActionResult Index()
        {
            var equipoxCompetencia = db.EquipoxCompetencia.Include(e => e.Competencia).Include(e => e.Equipo);
            return View(equipoxCompetencia.ToList());
        }

        // GET: EquipoxCompetencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoxCompetencia equipoxCompetencia = db.EquipoxCompetencia.Find(id);
            if (equipoxCompetencia == null)
            {
                return HttpNotFound();
            }
            return View(equipoxCompetencia);
        }

        // GET: EquipoxCompetencias/Create
        public ActionResult Create()
        {
            ViewBag.iIdCompetencia = new SelectList(db.Competencia, "iId", "vDescripcion");
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion");
            return View();
        }

        // POST: EquipoxCompetencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iId,iIdEquipo,iIdCompetencia")] EquipoxCompetencia equipoxCompetencia)
        {
            if (ModelState.IsValid)
            {
                db.EquipoxCompetencia.Add(equipoxCompetencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iIdCompetencia = new SelectList(db.Competencia, "iId", "vDescripcion", equipoxCompetencia.iIdCompetencia);
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", equipoxCompetencia.iIdEquipo);
            return View(equipoxCompetencia);
        }

        // GET: EquipoxCompetencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoxCompetencia equipoxCompetencia = db.EquipoxCompetencia.Find(id);
            if (equipoxCompetencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.iIdCompetencia = new SelectList(db.Competencia, "iId", "vDescripcion", equipoxCompetencia.iIdCompetencia);
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", equipoxCompetencia.iIdEquipo);
            return View(equipoxCompetencia);
        }

        // POST: EquipoxCompetencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iId,iIdEquipo,iIdCompetencia")] EquipoxCompetencia equipoxCompetencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoxCompetencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iIdCompetencia = new SelectList(db.Competencia, "iId", "vDescripcion", equipoxCompetencia.iIdCompetencia);
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", equipoxCompetencia.iIdEquipo);
            return View(equipoxCompetencia);
        }

        // GET: EquipoxCompetencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoxCompetencia equipoxCompetencia = db.EquipoxCompetencia.Find(id);
            if (equipoxCompetencia == null)
            {
                return HttpNotFound();
            }
            return View(equipoxCompetencia);
        }

        // POST: EquipoxCompetencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoxCompetencia equipoxCompetencia = db.EquipoxCompetencia.Find(id);
            db.EquipoxCompetencia.Remove(equipoxCompetencia);
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
