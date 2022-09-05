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
    public class Tipo_tratamientoController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Tipo_tratamiento
        public ActionResult Index()
        {
            return View(db.Tipo_tratamiento.ToList());
        }

        // GET: Tipo_tratamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_tratamiento tipo_tratamiento = db.Tipo_tratamiento.Find(id);
            if (tipo_tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_tratamiento);
        }

        // GET: Tipo_tratamiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_tratamiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tipo_tratamiento,Nombre_tratamiento,Duracion_horas,imágen_muestra")] Tipo_tratamiento tipo_tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_tratamiento.Add(tipo_tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_tratamiento);
        }

        // GET: Tipo_tratamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_tratamiento tipo_tratamiento = db.Tipo_tratamiento.Find(id);
            if (tipo_tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_tratamiento);
        }

        // POST: Tipo_tratamiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_tipo_tratamiento,Nombre_tratamiento,Duracion_horas,imágen_muestra")] Tipo_tratamiento tipo_tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_tratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_tratamiento);
        }

        // GET: Tipo_tratamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_tratamiento tipo_tratamiento = db.Tipo_tratamiento.Find(id);
            if (tipo_tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_tratamiento);
        }

        // POST: Tipo_tratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_tratamiento tipo_tratamiento = db.Tipo_tratamiento.Find(id);
            db.Tipo_tratamiento.Remove(tipo_tratamiento);
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
