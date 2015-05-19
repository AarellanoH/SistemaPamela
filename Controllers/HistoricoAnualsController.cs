using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pamela_4._0.Models;

namespace Pamela_4._0.Controllers
{
    public class HistoricoAnualsController : Controller
    {
        private PamelaEntities db = new PamelaEntities();

        // GET: HistoricoAnuals
        public ActionResult Index()
        {
            var historicoAnuals = db.HistoricoAnuals.Include(h => h.Becado).Include(h => h.Categoria).Include(h => h.Escuela).Include(h => h.Periodo).Include(h => h.Servicio);
            return View(historicoAnuals.ToList());
        }

        // GET: HistoricoAnuals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoAnual historicoAnual = db.HistoricoAnuals.Find(id);
            if (historicoAnual == null)
            {
                return HttpNotFound();
            }
            return View(historicoAnual);
        }

        // GET: HistoricoAnuals/Create
        public ActionResult Create()
        {
            ViewBag.IDBecado = new SelectList(db.Becadoes, "IDBecado", "Nombre");
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria");
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Nombre");
            ViewBag.IDPeriodos = new SelectList(db.Periodos, "IDPeriodos", "IDPeriodos");
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre");
            return View();
        }

        // POST: HistoricoAnuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHistoricoAnual,IDPeriodos,IDBecado,IDCategoria,IDEscuela,Promedio,IDServicio,HorasRealizadas")] HistoricoAnual historicoAnual)
        {
            if (ModelState.IsValid)
            {
                db.HistoricoAnuals.Add(historicoAnual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBecado = new SelectList(db.Becadoes, "IDBecado", "Nombre", historicoAnual.IDBecado);
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria", historicoAnual.IDCategoria);
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Nombre", historicoAnual.IDEscuela);
            ViewBag.IDPeriodos = new SelectList(db.Periodos, "IDPeriodos", "IDPeriodos", historicoAnual.IDPeriodos);
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre", historicoAnual.IDServicio);
            return View(historicoAnual);
        }

        // GET: HistoricoAnuals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoAnual historicoAnual = db.HistoricoAnuals.Find(id);
            if (historicoAnual == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBecado = new SelectList(db.Becadoes, "IDBecado", "Nombre", historicoAnual.IDBecado);
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria", historicoAnual.IDCategoria);
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Nombre", historicoAnual.IDEscuela);
            ViewBag.IDPeriodos = new SelectList(db.Periodos, "IDPeriodos", "IDPeriodos", historicoAnual.IDPeriodos);
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre", historicoAnual.IDServicio);
            return View(historicoAnual);
        }

        // POST: HistoricoAnuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHistoricoAnual,IDPeriodos,IDBecado,IDCategoria,IDEscuela,Promedio,IDServicio,HorasRealizadas")] HistoricoAnual historicoAnual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicoAnual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBecado = new SelectList(db.Becadoes, "IDBecado", "Nombre", historicoAnual.IDBecado);
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "NombreCategoria", historicoAnual.IDCategoria);
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Nombre", historicoAnual.IDEscuela);
            ViewBag.IDPeriodos = new SelectList(db.Periodos, "IDPeriodos", "IDPeriodos", historicoAnual.IDPeriodos);
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre", historicoAnual.IDServicio);
            return View(historicoAnual);
        }

        // GET: HistoricoAnuals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoAnual historicoAnual = db.HistoricoAnuals.Find(id);
            if (historicoAnual == null)
            {
                return HttpNotFound();
            }
            return View(historicoAnual);
        }

        // POST: HistoricoAnuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoricoAnual historicoAnual = db.HistoricoAnuals.Find(id);
            db.HistoricoAnuals.Remove(historicoAnual);
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
