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
    public class OrdenController : Controller
    {
        private FSeanDB db = new FSeanDB();

        // GET: Orden
        public ActionResult Index()
        {
            var orden = db.Orden.Include(o => o.Producto).Include(o => o.Usuario);
            return View(orden.ToList());
        }

        // GET: Orden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
            ViewBag.iIdProducto = new SelectList(db.Producto, "iId", "vCategoria");
            ViewBag.iIdUsuario = new SelectList(db.Usuario, "iId", "vUsuario");
            return View();
        }

        // POST: Orden/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iId,iIdUsuario,iIdProducto,iCantidad,dcPrecioFinal")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Orden.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iIdProducto = new SelectList(db.Producto, "iId", "vCategoria", orden.iIdProducto);
            ViewBag.iIdUsuario = new SelectList(db.Usuario, "iId", "vUsuario", orden.iIdUsuario);
            return View(orden);
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.iIdProducto = new SelectList(db.Producto, "iId", "vCategoria", orden.iIdProducto);
            ViewBag.iIdUsuario = new SelectList(db.Usuario, "iId", "vUsuario", orden.iIdUsuario);
            return View(orden);
        }

        // POST: Orden/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iId,iIdUsuario,iIdProducto,iCantidad,dcPrecioFinal")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iIdProducto = new SelectList(db.Producto, "iId", "vCategoria", orden.iIdProducto);
            ViewBag.iIdUsuario = new SelectList(db.Usuario, "iId", "vUsuario", orden.iIdUsuario);
            return View(orden);
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden orden = db.Orden.Find(id);
            db.Orden.Remove(orden);
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
