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
    public class Registro_compraController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Registro_compra
        public ActionResult Index()
        {
            var registro_compra = db.Registro_compra.Include(r => r.Insumo).Include(r => r.Proveedor);
            return View(registro_compra.ToList());
        }

        // GET: Registro_compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_compra registro_compra = db.Registro_compra.Find(id);
            if (registro_compra == null)
            {
                return HttpNotFound();
            }
            return View(registro_compra);
        }

        // GET: Registro_compra/Create
        public ActionResult Create()
        {
            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo");
            ViewBag.Id_proveedor = new SelectList(db.Proveedors, "Id_proveedor", "Nombre_proveedor");
            return View();
        }

        // POST: Registro_compra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_compra,Fecha_compra,costo_unidad,total_unidades,Id_proveedor,Id_insumo")] Registro_compra registro_compra)
        {
            if (ModelState.IsValid)
            {
                db.Registro_compra.Add(registro_compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo", registro_compra.Id_insumo);
            ViewBag.Id_proveedor = new SelectList(db.Proveedors, "Id_proveedor", "Nombre_proveedor", registro_compra.Id_proveedor);
            return View(registro_compra);
        }

        // GET: Registro_compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_compra registro_compra = db.Registro_compra.Find(id);
            if (registro_compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo", registro_compra.Id_insumo);
            ViewBag.Id_proveedor = new SelectList(db.Proveedors, "Id_proveedor", "Nombre_proveedor", registro_compra.Id_proveedor);
            return View(registro_compra);
        }

        // POST: Registro_compra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_compra,Fecha_compra,costo_unidad,total_unidades,Id_proveedor,Id_insumo")] Registro_compra registro_compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo", registro_compra.Id_insumo);
            ViewBag.Id_proveedor = new SelectList(db.Proveedors, "Id_proveedor", "Nombre_proveedor", registro_compra.Id_proveedor);
            return View(registro_compra);
        }

        // GET: Registro_compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_compra registro_compra = db.Registro_compra.Find(id);
            if (registro_compra == null)
            {
                return HttpNotFound();
            }
            return View(registro_compra);
        }

        // POST: Registro_compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro_compra registro_compra = db.Registro_compra.Find(id);
            db.Registro_compra.Remove(registro_compra);
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
