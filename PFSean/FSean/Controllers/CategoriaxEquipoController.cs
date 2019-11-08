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
    public class CategoriaxEquipoController : Controller
    {
        private FSeanDB db = new FSeanDB();

        // GET: CategoriaxEquipoes
        public ActionResult Index()
        {
            var categoriaxEquipo = db.CategoriaxEquipo.Include(c => c.Categoria).Include(c => c.Equipo);
            return View(categoriaxEquipo.ToList());
        }

        // GET: CategoriaxEquipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaxEquipo categoriaxEquipo = db.CategoriaxEquipo.Find(id);
            if (categoriaxEquipo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaxEquipo);
        }

        // GET: CategoriaxEquipoes/Create
        public ActionResult Create()
        {
            ViewBag.iIdCategoria = new SelectList(db.Categoria, "iId", "vNombre");
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion");
            return View();
        }

        // POST: CategoriaxEquipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iId,iIdCategoria,iIdEquipo")] CategoriaxEquipo categoriaxEquipo)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaxEquipo.Add(categoriaxEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iIdCategoria = new SelectList(db.Categoria, "iId", "vNombre", categoriaxEquipo.iIdCategoria);
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", categoriaxEquipo.iIdEquipo);
            return View(categoriaxEquipo);
        }

        // GET: CategoriaxEquipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaxEquipo categoriaxEquipo = db.CategoriaxEquipo.Find(id);
            if (categoriaxEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.iIdCategoria = new SelectList(db.Categoria, "iId", "vNombre", categoriaxEquipo.iIdCategoria);
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", categoriaxEquipo.iIdEquipo);
            return View(categoriaxEquipo);
        }

        // POST: CategoriaxEquipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iId,iIdCategoria,iIdEquipo")] CategoriaxEquipo categoriaxEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaxEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iIdCategoria = new SelectList(db.Categoria, "iId", "vNombre", categoriaxEquipo.iIdCategoria);
            ViewBag.iIdEquipo = new SelectList(db.Equipo, "iIdEquipo", "vInstitucion", categoriaxEquipo.iIdEquipo);
            return View(categoriaxEquipo);
        }

        // GET: CategoriaxEquipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaxEquipo categoriaxEquipo = db.CategoriaxEquipo.Find(id);
            if (categoriaxEquipo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaxEquipo);
        }

        // POST: CategoriaxEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaxEquipo categoriaxEquipo = db.CategoriaxEquipo.Find(id);
            db.CategoriaxEquipo.Remove(categoriaxEquipo);
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
