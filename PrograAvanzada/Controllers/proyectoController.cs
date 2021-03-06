﻿using System;
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
    public class proyectoController : Controller
    {
        private db_admin_proyectosEntities1 db = new db_admin_proyectosEntities1();

        //Index creados para mostrar informacion dependiendo a quien se le quiere mostrar usando linq
        // GET: proyecto
        public ActionResult Index()
        {
            var proyecto = db.proyecto.Include(p => p.AspNetUsers).Include(p => p.estado);
            return View(proyecto.ToList());
        }
        public ActionResult Index3()
        {
            var proyecto = db.proyecto.Include(p => p.AspNetUsers).Include(p => p.estado);
            return View(proyecto.ToList());
        }

        public void RedirigirForo(int? id)
        {
            string sitio = "http://localhost:2005/ForoPlantilla/Index" + "?" + "id=" + id;
            Response.Redirect(sitio);
        }
        
        //metodo creado para redirigir a un sitio con cierto valor por link usando linq
        [HttpGet, ValidateInput(false)]
        public void Ver(int id)
        {
            int i;
            i = id;

            var _proyecto =
                from aux in db.tarea.Include(t => t.AspNetUsers).Include(t => t.estado).Include(t => t.proyecto)
                where aux.proyecto.id_proyecto == id
                select aux.proyecto.nombre_proyecto;

            string a = _proyecto.FirstOrDefault();
            string sitio = "~/tareas/IndexPorProyecto" + "?" + "proyecto=" + a;
            Response.Redirect(sitio);
        }

        [HttpGet, ValidateInput(false)]
        public void VerForo(int id)
        {
            string sitio = "~/foro/Index" + "?" + "proyecto=" + id;
            Response.Redirect(sitio);
        }

        // GET: proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: proyecto/Create
        public ActionResult Create()
        {
            ViewBag.admin_asignado = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion");
            return View();
        }

        // POST: proyecto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proyecto,nombre_proyecto,descripcion,admin_asignado,cod_estado")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.admin_asignado = new SelectList(db.AspNetUsers, "Id", "Email", proyecto.admin_asignado);
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion", proyecto.cod_estado);
            return View(proyecto);
        }

        // GET: proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_asignado = new SelectList(db.AspNetUsers, "Id", "Email", proyecto.admin_asignado);
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion", proyecto.cod_estado);
            return View(proyecto);
        }

        // POST: proyecto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proyecto,nombre_proyecto,descripcion,admin_asignado,cod_estado")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_asignado = new SelectList(db.AspNetUsers, "Id", "Email", proyecto.admin_asignado);
            ViewBag.cod_estado = new SelectList(db.estado, "id_estado", "descripcion", proyecto.cod_estado);
            return View(proyecto);
        }

        // GET: proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proyecto proyecto = db.proyecto.Find(id);
            db.proyecto.Remove(proyecto);
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
