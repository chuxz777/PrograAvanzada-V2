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
    public class comentarios_foroController : Controller
    {
        private db_admin_proyectosEntities1 db = new db_admin_proyectosEntities1();

        // GET: comentarios_foro
        public ActionResult Index(int codForo)
        {
            var comentarios_foro =
            from datos in db.comentarios_foro
            where datos.cod_foro == codForo
            select datos;

            return PartialView(comentarios_foro.ToList());
                       
        }

        public ActionResult Index2()
        {
            var comentarios_foro =
            from datos in db.comentarios_foro
            select datos;

            return PartialView(comentarios_foro.ToList());

        }

        // GET: comentarios_foro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentarios_foro comentarios_foro = db.comentarios_foro.Find(id);
            if (comentarios_foro == null)
            {
                return HttpNotFound();
            }
            return View(comentarios_foro);
        }

        // GET: comentarios_foro/Create
        public ActionResult Create()
        {
            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.cod_foro = new SelectList(db.foro, "id_foro", "id_foro");
            return View();
        }

        // POST: comentarios_foro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_comentario_foro,comentario,fecha_comentario,cod_foro,cod_usuario")] comentarios_foro comentarios_foro)
        {
            if (ModelState.IsValid)
            {
                db.comentarios_foro.Add(comentarios_foro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email", comentarios_foro.cod_usuario);
            ViewBag.cod_foro = new SelectList(db.foro, "id_foro", "id_foro", comentarios_foro.cod_foro);
            return View(comentarios_foro);
        }

        // GET: comentarios_foro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentarios_foro comentarios_foro = db.comentarios_foro.Find(id);
            if (comentarios_foro == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email", comentarios_foro.cod_usuario);
            ViewBag.cod_foro = new SelectList(db.foro, "id_foro", "id_foro", comentarios_foro.cod_foro);
            return View(comentarios_foro);
        }

        // POST: comentarios_foro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_comentario_foro,comentario,fecha_comentario,cod_foro,cod_usuario")] comentarios_foro comentarios_foro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarios_foro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email", comentarios_foro.cod_usuario);
            ViewBag.cod_foro = new SelectList(db.foro, "id_foro", "id_foro", comentarios_foro.cod_foro);
            return View(comentarios_foro);
        }

        // GET: comentarios_foro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentarios_foro comentarios_foro = db.comentarios_foro.Find(id);
            if (comentarios_foro == null)
            {
                return HttpNotFound();
            }
            return View(comentarios_foro);
        }

        // POST: comentarios_foro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comentarios_foro comentarios_foro = db.comentarios_foro.Find(id);
            db.comentarios_foro.Remove(comentarios_foro);
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
