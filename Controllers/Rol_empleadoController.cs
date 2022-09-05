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
    public class Rol_empleadoController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Rol_empleado
        public ActionResult Index()
        {
            return View(db.Rol_empleado.ToList());
        }

        // GET: Rol_empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_empleado rol_empleado = db.Rol_empleado.Find(id);
            if (rol_empleado == null)
            {
                return HttpNotFound();
            }
            return View(rol_empleado);
        }

        // GET: Rol_empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol_empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_rol_empleado,Nombre_rol_empleado,descripcion,nivel_acceso")] Rol_empleado rol_empleado)
        {
            if (ModelState.IsValid)
            {
                db.Rol_empleado.Add(rol_empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rol_empleado);
        }

        // GET: Rol_empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_empleado rol_empleado = db.Rol_empleado.Find(id);
            if (rol_empleado == null)
            {
                return HttpNotFound();
            }
            return View(rol_empleado);
        }

        // POST: Rol_empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_rol_empleado,Nombre_rol_empleado,descripcion,nivel_acceso")] Rol_empleado rol_empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol_empleado);
        }

        // GET: Rol_empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_empleado rol_empleado = db.Rol_empleado.Find(id);
            if (rol_empleado == null)
            {
                return HttpNotFound();
            }
            return View(rol_empleado);
        }

        // POST: Rol_empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol_empleado rol_empleado = db.Rol_empleado.Find(id);
            db.Rol_empleado.Remove(rol_empleado);
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
