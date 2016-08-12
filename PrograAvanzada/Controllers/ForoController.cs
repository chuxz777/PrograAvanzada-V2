using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrograAvanzada.Models;

namespace PrograAvanzada.Controllers
{
    public class foroController : Controller
    {
        private db_admin_proyectosEntities1 db = new db_admin_proyectosEntities1();

        // GET: foro
        public ActionResult Index(int proyecto)
        {

            var foro =
            from datos in db.foro.Include(f => f.proyecto)
            where datos.cod_proyecto == proyecto
            select datos;

            return PartialView(foro.ToList());
            
        }

        public ActionResult Index2()
        {

            var foro =
            from datos in db.foro.Include(f => f.proyecto)
            select datos;

            return PartialView(foro.ToList());

        }





        // GET: foro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foro foro = db.foro.Find(id);
            if (foro == null)
            {
                return HttpNotFound();
            }
            return View(foro);
        }

        // GET: foro/Create
        public ActionResult Create()
        {
            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto");
            return View();
        }

        // POST: foro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_foro,cod_proyecto")] foro foro)
        {
            if (ModelState.IsValid)
            {
                db.foro.Add(foro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto", foro.cod_proyecto);
            return View(foro);
        }

        // GET: foro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foro foro = db.foro.Find(id);
            if (foro == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto", foro.cod_proyecto);
            return View(foro);
        }

        // POST: foro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_foro,cod_proyecto")] foro foro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto", foro.cod_proyecto);
            return View(foro);
        }

        // GET: foro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foro foro = db.foro.Find(id);
            if (foro == null)
            {
                return HttpNotFound();
            }
            return View(foro);
        }

        // POST: foro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foro foro = db.foro.Find(id);
            db.foro.Remove(foro);
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
