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
    public class EmpleadoesController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.Rol_empleado);
            return View(empleadoes.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_rol_empleado = new SelectList(db.Rol_empleado, "Id_rol_empleado", "Nombre_rol_empleado");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUI_empleado,Primer_nombre_empleado,Segundo_nombre_empleado,Primer_apellido_empleado,Segundo_apellido_empleado,dirección,Id_rol_empleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_rol_empleado = new SelectList(db.Rol_empleado, "Id_rol_empleado", "Nombre_rol_empleado", empleado.Id_rol_empleado);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_rol_empleado = new SelectList(db.Rol_empleado, "Id_rol_empleado", "Nombre_rol_empleado", empleado.Id_rol_empleado);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CUI_empleado,Primer_nombre_empleado,Segundo_nombre_empleado,Primer_apellido_empleado,Segundo_apellido_empleado,dirección,Id_rol_empleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_rol_empleado = new SelectList(db.Rol_empleado, "Id_rol_empleado", "Nombre_rol_empleado", empleado.Id_rol_empleado);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(empleado);
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
