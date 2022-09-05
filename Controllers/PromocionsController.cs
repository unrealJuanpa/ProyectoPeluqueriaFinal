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
    public class PromocionsController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Promocions
        public ActionResult Index()
        {
            var promocions = db.Promocions.Include(p => p.Tipo_tratamiento);
            return View(promocions.ToList());
        }

        // GET: Promocions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocions.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // GET: Promocions/Create
        public ActionResult Create()
        {
            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento");
            return View();
        }

        // POST: Promocions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_promocion,Nombre_promocion,Descripcion,Fecha_inicio,Fecha_fin,imagen_anuncio,Id_tipo_tratamiento")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                db.Promocions.Add(promocion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento", promocion.Id_tipo_tratamiento);
            return View(promocion);
        }

        // GET: Promocions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocions.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento", promocion.Id_tipo_tratamiento);
            return View(promocion);
        }

        // POST: Promocions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_promocion,Nombre_promocion,Descripcion,Fecha_inicio,Fecha_fin,imagen_anuncio,Id_tipo_tratamiento")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_tipo_tratamiento = new SelectList(db.Tipo_tratamiento, "Id_tipo_tratamiento", "Nombre_tratamiento", promocion.Id_tipo_tratamiento);
            return View(promocion);
        }

        // GET: Promocions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocions.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // POST: Promocions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocion promocion = db.Promocions.Find(id);
            db.Promocions.Remove(promocion);
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
