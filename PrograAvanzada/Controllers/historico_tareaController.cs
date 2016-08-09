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
    public class historico_tareaController : Controller
    {
        private db_admin_proyectosEntities1 db = new db_admin_proyectosEntities1();

        // GET: historico_tarea
        public ActionResult Index()
        {
            var historico_tarea = db.historico_tarea.Include(h => h.AspNetUsers).Include(h => h.tarea);
            return View(historico_tarea.ToList());
        }

        public ActionResult IndexPorTareas(int codtarea)
        {
            var httarea =
                from historico_tarea in db.historico_tarea
                where historico_tarea.cod_tarea == codtarea
                select historico_tarea;
            return View(httarea.ToList());
        }

        // GET: historico_tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico_tarea historico_tarea = db.historico_tarea.Find(id);
            if (historico_tarea == null)
            {
                return HttpNotFound();
            }
            return View(historico_tarea);
        }

        // GET: historico_tarea/Create
        public ActionResult Create()
        {
            ViewBag.cod_usuarioProyecto = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion");
            return View();
        }

        // POST: historico_tarea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_log,cod_tarea,cod_usuarioProyecto,observacion,fecha_cambio")] historico_tarea historico_tarea)
        {
            if (ModelState.IsValid)
            {
                db.historico_tarea.Add(historico_tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_usuarioProyecto = new SelectList(db.AspNetUsers, "Id", "Email", historico_tarea.cod_usuarioProyecto);
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion", historico_tarea.cod_tarea);
            return View(historico_tarea);
        }

        // GET: historico_tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico_tarea historico_tarea = db.historico_tarea.Find(id);
            if (historico_tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_usuarioProyecto = new SelectList(db.AspNetUsers, "Id", "Email", historico_tarea.cod_usuarioProyecto);
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion", historico_tarea.cod_tarea);
            return View(historico_tarea);
        }

        // POST: historico_tarea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_log,cod_tarea,cod_usuarioProyecto,observacion,fecha_cambio")] historico_tarea historico_tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico_tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_usuarioProyecto = new SelectList(db.AspNetUsers, "Id", "Email", historico_tarea.cod_usuarioProyecto);
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion", historico_tarea.cod_tarea);
            return View(historico_tarea);
        }

        // GET: historico_tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico_tarea historico_tarea = db.historico_tarea.Find(id);
            if (historico_tarea == null)
            {
                return HttpNotFound();
            }
            return View(historico_tarea);
        }

        // POST: historico_tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historico_tarea historico_tarea = db.historico_tarea.Find(id);
            db.historico_tarea.Remove(historico_tarea);
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
