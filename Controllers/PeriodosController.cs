﻿using System;
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
    public class PeriodosController : Controller
    {
        private PamelaEntities db = new PamelaEntities();

        // GET: Periodos
        public ActionResult Index()
        {
            return View(db.Periodos.ToList());
        }

        // GET: Periodos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // GET: Periodos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periodos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPeriodos,FechaInicio,FechaFinal")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Periodos.Add(periodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodo);
        }

        // GET: Periodos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // POST: Periodos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPeriodos,FechaInicio,FechaFinal")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodo);
        }

        // GET: Periodos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // POST: Periodos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periodo periodo = db.Periodos.Find(id);
            db.Periodos.Remove(periodo);
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
