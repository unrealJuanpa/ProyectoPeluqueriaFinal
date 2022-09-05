using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoPeluqueriaFinal.Models;

namespace ProyectoPeluqueriaFinal.Controllers
{
    public class Razon_retiro_productoController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Razon_retiro_producto
        public ActionResult Index()
        {
            return View(db.Razon_retiro_producto.ToList());
        }

        // GET: Razon_retiro_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razon_retiro_producto razon_retiro_producto = db.Razon_retiro_producto.Find(id);
            if (razon_retiro_producto == null)
            {
                return HttpNotFound();
            }
            return View(razon_retiro_producto);
        }

        // GET: Razon_retiro_producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Razon_retiro_producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_retiro_producto,Nombre_razon_retiro,Descripcion_razon_retiro")] Razon_retiro_producto razon_retiro_producto)
        {
            if (ModelState.IsValid)
            {
                db.Razon_retiro_producto.Add(razon_retiro_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(razon_retiro_producto);
        }

        // GET: Razon_retiro_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razon_retiro_producto razon_retiro_producto = db.Razon_retiro_producto.Find(id);
            if (razon_retiro_producto == null)
            {
                return HttpNotFound();
            }
            return View(razon_retiro_producto);
        }

        // POST: Razon_retiro_producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_retiro_producto,Nombre_razon_retiro,Descripcion_razon_retiro")] Razon_retiro_producto razon_retiro_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(razon_retiro_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(razon_retiro_producto);
        }

        // GET: Razon_retiro_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razon_retiro_producto razon_retiro_producto = db.Razon_retiro_producto.Find(id);
            if (razon_retiro_producto == null)
            {
                return HttpNotFound();
            }
            return View(razon_retiro_producto);
        }

        // POST: Razon_retiro_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Razon_retiro_producto razon_retiro_producto = db.Razon_retiro_producto.Find(id);
            db.Razon_retiro_producto.Remove(razon_retiro_producto);
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
