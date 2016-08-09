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
    public class tareasController : Controller
    {
        private db_admin_proyectosEntities1 db = new db_admin_proyectosEntities1();

        // GET: tareas
        public ActionResult Index()
        {
            var tarea = db.tarea.Include(t => t.AspNetUsers).Include(t => t.estado).Include(t => t.proyecto);
            return View(tarea.ToList());
        }

        [HttpGet, ValidateInput(false)]
        public void Ver(int id)
        {
            int i;
            i = id;

            var _comentariotarea =
                from aux in db.comentario_por_tarea
                where aux.cod_tarea == id
                select aux.tarea.id_tarea;

            int a = _comentariotarea.FirstOrDefault();
            string sitio = "~/comentario_por_tarea/IndexComentarioPorTarea" + "?" + "idtareapar=" + a;
            Response.Redirect(sitio);
        }

        //public void Ver(int id)
        //{
        //    int i;
        //    i = id;

        //    var _tarea =
        //        from aux in db.historico_tarea.Include(t => t.tarea)
        //        where aux.cod_tarea == id
        //        select aux.tarea.id_tarea;

        //    int a = _tarea.FirstOrDefault();
        //    string sitio = "~/historico_tarea/IndexPorTareas" + "?" + "codtarea=" + a;
        //    Response.Redirect(sitio);
        //}



        public ActionResult IndexPorProyecto(string proyecto)
        {
            var tarea = 
                from tareas_proyecto in  db.tarea.Include(t => t.AspNetUsers).Include(t => t.estado).Include(t => t.proyecto)
                where tareas_proyecto.proyecto.nombre_proyecto == proyecto
                select tareas_proyecto;
            return View(tarea.ToList());
        }


        // GET: tareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarea tarea = db.tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: tareas/Create
        public ActionResult Create()
        {
            ViewBag.cod_usuarioAsignado = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion");
            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto");



            return View();
        }

        // POST: tareas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarea,observacion,cod_proyecto,cod_estado,cod_usuarioAsignado")] tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.tarea.Add(tarea);
                db.SP_UsuarioProyecto(tarea.cod_usuarioAsignado, tarea.cod_proyecto);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.cod_usuarioAsignado = new SelectList(db.AspNetUsers, "Id", "Email", tarea.cod_usuarioAsignado);
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion", tarea.cod_estado);
            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto", tarea.cod_proyecto);
            return View(tarea);
        }

        // GET: tareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarea tarea = db.tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_usuarioAsignado = new SelectList(db.AspNetUsers, "Id", "Email", tarea.cod_usuarioAsignado);
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion", tarea.cod_estado);
            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto", tarea.cod_proyecto);

            DateTime now = System.DateTime.Now;

            db.SP_Registro_Histrorico_Tarea(tarea.id_tarea,tarea.cod_usuarioAsignado,"Cambio de Estado",now);

            return View(tarea);

        }

        // POST: tareas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarea,observacion,cod_proyecto,cod_estado,cod_usuarioAsignado")] tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_usuarioAsignado = new SelectList(db.AspNetUsers, "Id", "Email", tarea.cod_usuarioAsignado);
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion", tarea.cod_estado);
            ViewBag.cod_proyecto = new SelectList(db.proyecto, "id_proyecto", "nombre_proyecto", tarea.cod_proyecto);
            return View(tarea);
        }

        // GET: tareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarea tarea = db.tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tarea tarea = db.tarea.Find(id);
            db.tarea.Remove(tarea);
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
