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
    public class InsumoesController : Controller
    {
        private DatabasePeluqueriaEntities db = new DatabasePeluqueriaEntities();

        // GET: Insumoes
        public ActionResult Index()
        {
            return View(db.Insumoes.ToList());
        }

        // GET: Insumoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumoes.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // GET: Insumoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_insumo,Nombre_insumo,Descripción")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Insumoes.Add(insumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insumo);
        }

        // GET: Insumoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumoes.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // POST: Insumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_insumo,Nombre_insumo,Descripción")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insumo);
        }

        // GET: Insumoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumoes.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // POST: Insumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insumo insumo = db.Insumoes.Find(id);
            db.Insumoes.Remove(insumo);
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
