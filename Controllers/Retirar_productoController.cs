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
    public class Retirar_productoController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Retirar_producto
        public ActionResult Index()
        {
            var retirar_producto = db.Retirar_producto.Include(r => r.Empleado).Include(r => r.Insumo).Include(r => r.Razon_retiro_producto);
            return View(retirar_producto.ToList());
        }

        // GET: Retirar_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retirar_producto retirar_producto = db.Retirar_producto.Find(id);
            if (retirar_producto == null)
            {
                return HttpNotFound();
            }
            return View(retirar_producto);
        }

        // GET: Retirar_producto/Create
        public ActionResult Create()
        {
            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado");
            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo");
            ViewBag.Id_retiro_producto = new SelectList(db.Razon_retiro_producto, "Id_retiro_producto", "Nombre_razon_retiro");
            return View();
        }

        // POST: Retirar_producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_retirar_producto,Fecha_retiro,Unidades_Retira,Id_insumo,CUI_empleado,Id_retiro_producto")] Retirar_producto retirar_producto)
        {
            if (ModelState.IsValid)
            {
                db.Retirar_producto.Add(retirar_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado", retirar_producto.CUI_empleado);
            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo", retirar_producto.Id_insumo);
            ViewBag.Id_retiro_producto = new SelectList(db.Razon_retiro_producto, "Id_retiro_producto", "Nombre_razon_retiro", retirar_producto.Id_retiro_producto);
            return View(retirar_producto);
        }

        // GET: Retirar_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retirar_producto retirar_producto = db.Retirar_producto.Find(id);
            if (retirar_producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado", retirar_producto.CUI_empleado);
            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo", retirar_producto.Id_insumo);
            ViewBag.Id_retiro_producto = new SelectList(db.Razon_retiro_producto, "Id_retiro_producto", "Nombre_razon_retiro", retirar_producto.Id_retiro_producto);
            return View(retirar_producto);
        }

        // POST: Retirar_producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_retirar_producto,Fecha_retiro,Unidades_Retira,Id_insumo,CUI_empleado,Id_retiro_producto")] Retirar_producto retirar_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retirar_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado", retirar_producto.CUI_empleado);
            ViewBag.Id_insumo = new SelectList(db.Insumoes, "Id_insumo", "Nombre_insumo", retirar_producto.Id_insumo);
            ViewBag.Id_retiro_producto = new SelectList(db.Razon_retiro_producto, "Id_retiro_producto", "Nombre_razon_retiro", retirar_producto.Id_retiro_producto);
            return View(retirar_producto);
        }

        // GET: Retirar_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retirar_producto retirar_producto = db.Retirar_producto.Find(id);
            if (retirar_producto == null)
            {
                return HttpNotFound();
            }
            return View(retirar_producto);
        }

        // POST: Retirar_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Retirar_producto retirar_producto = db.Retirar_producto.Find(id);
            db.Retirar_producto.Remove(retirar_producto);
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
