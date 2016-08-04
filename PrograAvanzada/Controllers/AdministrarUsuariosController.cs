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
    public class AdministrarUsuariosController : Controller
    {
        private db_admin_proyectosEntities db = new db_admin_proyectosEntities();

        // GET: AdministrarUsuarios
        public ActionResult Index()
        {
            return View(db.AdministrarUsuarios.ToList());
        }

        // GET: AdministrarUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrarUsuarios administrarUsuarios = db.AdministrarUsuarios.Find(id);
            if (administrarUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(administrarUsuarios);
        }

        // GET: AdministrarUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministrarUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,email,rol")] AdministrarUsuarios administrarUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.AdministrarUsuarios.Add(administrarUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrarUsuarios);
        }

        // GET: AdministrarUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrarUsuarios administrarUsuarios = db.AdministrarUsuarios.Find(id);
            if (administrarUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(administrarUsuarios);
        }

        // POST: AdministrarUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,email,rol")] AdministrarUsuarios administrarUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrarUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrarUsuarios);
        }

        // GET: AdministrarUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrarUsuarios administrarUsuarios = db.AdministrarUsuarios.Find(id);
            if (administrarUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(administrarUsuarios);
        }

        // POST: AdministrarUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministrarUsuarios administrarUsuarios = db.AdministrarUsuarios.Find(id);
            db.AdministrarUsuarios.Remove(administrarUsuarios);
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
