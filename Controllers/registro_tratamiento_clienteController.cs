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
    public class registro_tratamiento_clienteController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: registro_tratamiento_cliente
        public ActionResult Index()
        {
            var registro_tratamiento_cliente = db.registro_tratamiento_cliente.Include(r => r.Cliente).Include(r => r.Empleado).Include(r => r.Tipo_tratamiento);
            return View(registro_tratamiento_cliente.ToList());
        }

        // GET: registro_tratamiento_cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_tratamiento_cliente registro_tratamiento_cliente = db.registro_tratamiento_cliente.Find(id);
            if (registro_tratamiento_cliente == null)
            {
                return HttpNotFound();
            }
            return View(registro_tratamiento_cliente);
        }

        // GET: registro_tratamiento_cliente/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Clientes, "Id_Cliente", "Primer_nombre_Cliente");
            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado");
            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento");
            return View();
        }

        // POST: registro_tratamiento_cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_registro,Fecha,Costo,Id_Cliente,CUI_empleado,Id_tipo_tratamiento")] registro_tratamiento_cliente registro_tratamiento_cliente)
        {
            if (ModelState.IsValid)
            {
                db.registro_tratamiento_cliente.Add(registro_tratamiento_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Clientes, "Id_Cliente", "Primer_nombre_Cliente", registro_tratamiento_cliente.Id_Cliente);
            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado", registro_tratamiento_cliente.CUI_empleado);
            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento", registro_tratamiento_cliente.Id_tipo_tratamiento);
            return View(registro_tratamiento_cliente);
        }

        // GET: registro_tratamiento_cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_tratamiento_cliente registro_tratamiento_cliente = db.registro_tratamiento_cliente.Find(id);
            if (registro_tratamiento_cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Clientes, "Id_Cliente", "Primer_nombre_Cliente", registro_tratamiento_cliente.Id_Cliente);
            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado", registro_tratamiento_cliente.CUI_empleado);
            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento", registro_tratamiento_cliente.Id_tipo_tratamiento);
            return View(registro_tratamiento_cliente);
        }

        // POST: registro_tratamiento_cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_registro,Fecha,Costo,Id_Cliente,CUI_empleado,Id_tipo_tratamiento")] registro_tratamiento_cliente registro_tratamiento_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_tratamiento_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Clientes, "Id_Cliente", "Primer_nombre_Cliente", registro_tratamiento_cliente.Id_Cliente);
            ViewBag.CUI_empleado = new SelectList(db.Empleadoes, "CUI_empleado", "Primer_nombre_empleado", registro_tratamiento_cliente.CUI_empleado);
            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento", registro_tratamiento_cliente.Id_tipo_tratamiento);
            return View(registro_tratamiento_cliente);
        }

        // GET: registro_tratamiento_cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_tratamiento_cliente registro_tratamiento_cliente = db.registro_tratamiento_cliente.Find(id);
            if (registro_tratamiento_cliente == null)
            {
                return HttpNotFound();
            }
            return View(registro_tratamiento_cliente);
        }

        // POST: registro_tratamiento_cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registro_tratamiento_cliente registro_tratamiento_cliente = db.registro_tratamiento_cliente.Find(id);
            db.registro_tratamiento_cliente.Remove(registro_tratamiento_cliente);
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
