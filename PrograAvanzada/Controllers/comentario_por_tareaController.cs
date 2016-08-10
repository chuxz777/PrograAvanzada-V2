using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrograAvanzada.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace PrograAvanzada.Controllers
{
    public class comentario_por_tareaController : Controller
    {
        private db_admin_proyectosEntities1 db = new db_admin_proyectosEntities1();

        // GET: comentario_por_tarea
        public ActionResult Index()
        {
            var comentario_por_tarea = db.comentario_por_tarea.Include(c => c.AspNetUsers).Include(c => c.tarea);
            return View(comentario_por_tarea.ToList());
        }

        public ActionResult IndexComentarioPorTarea(int idtareapar)
        {
            var _comentario_por_tarea = from aux in db.comentario_por_tarea
                                        where aux.tarea.id_tarea == idtareapar
                                        select aux ;
            return View(_comentario_por_tarea.ToList());
        }

        public ActionResult DownLoadFile(int id)
        {
            var _comentario_por_tarea = from aux in db.comentario_por_tarea
                                        //where aux.tarea.id_tarea == id
                                        select aux;

            var data = _comentario_por_tarea.ToList();

            var xml_data = new XElement("Registro_comentarios", data.Select(x => new XElement("Detalle",
                                                                                   new XElement("id_comentario", x.id_comentario),
                                                                                   new XElement("comentario", x.comentario),
                                                                                   new XElement("fecha_comentario", x.fecha_comentario),
                                                                                   new XElement("cod_tarea", x.cod_tarea),
                                                                                   new XElement("cod_usuario", x.cod_usuario)
                                                                                   )));

            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);
            tw.WriteLine(xml_data);
            tw.Flush();
            tw.Close();
            return File(memoryStream.GetBuffer(), "text/xml", "Comentarios.xml");
        }

        // GET: comentario_por_tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario_por_tarea comentario_por_tarea = db.comentario_por_tarea.Find(id);
            if (comentario_por_tarea == null)
            {
                return HttpNotFound();
            }
            return View(comentario_por_tarea);
        }

        // GET: comentario_por_tarea/Create
        public ActionResult Create()
        {
            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion");
            return View();
        }

        // POST: comentario_por_tarea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_comentario,comentario,fecha_comentario,cod_tarea,cod_usuario")] comentario_por_tarea comentario_por_tarea)
        {
            if (ModelState.IsValid)
            {
                db.comentario_por_tarea.Add(comentario_por_tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email", comentario_por_tarea.cod_usuario);
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion", comentario_por_tarea.cod_tarea);
            return View(comentario_por_tarea);
        }

        // GET: comentario_por_tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario_por_tarea comentario_por_tarea = db.comentario_por_tarea.Find(id);
            if (comentario_por_tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email", comentario_por_tarea.cod_usuario);
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion", comentario_por_tarea.cod_tarea);
            return View(comentario_por_tarea);
        }

        // POST: comentario_por_tarea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_comentario,comentario,fecha_comentario,cod_tarea,cod_usuario")] comentario_por_tarea comentario_por_tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario_por_tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_usuario = new SelectList(db.AspNetUsers, "Id", "Email", comentario_por_tarea.cod_usuario);
            ViewBag.cod_tarea = new SelectList(db.tarea, "id_tarea", "observacion", comentario_por_tarea.cod_tarea);
            return View(comentario_por_tarea);
        }

        // GET: comentario_por_tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario_por_tarea comentario_por_tarea = db.comentario_por_tarea.Find(id);
            if (comentario_por_tarea == null)
            {
                return HttpNotFound();
            }
            return View(comentario_por_tarea);
        }

        // POST: comentario_por_tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comentario_por_tarea comentario_por_tarea = db.comentario_por_tarea.Find(id);
            db.comentario_por_tarea.Remove(comentario_por_tarea);
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
