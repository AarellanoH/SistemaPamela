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
    public class BecadosController : Controller
    {
        private PamelaEntities db = new PamelaEntities();

        // GET: Becados
        public ActionResult Index()
        {
            var becadoes = db.Becadoes.Include(b => b.Tutor);
            return View(becadoes.ToList());
        }

        // GET: Becados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becado becado = db.Becadoes.Find(id);
            if (becado == null)
            {
                return HttpNotFound();
            }
            return View(becado);
        }

        // GET: Becados/Create
        public ActionResult Create()
        {
            ViewBag.IDPadre = new SelectList(db.Tutors, "IDTutor", "Nombre");
            return View();
        }

        // POST: Becados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBecado,IDPadre,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono")] Becado becado)
        {
            if (ModelState.IsValid)
            {
                db.Becadoes.Add(becado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPadre = new SelectList(db.Tutors, "IDTutor", "Nombre", becado.IDPadre);
            return View(becado);
        }

        // GET: Becados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becado becado = db.Becadoes.Find(id);
            if (becado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPadre = new SelectList(db.Tutors, "IDTutor", "Nombre", becado.IDPadre);
            return View(becado);
        }

        // POST: Becados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBecado,IDPadre,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono")] Becado becado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(becado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPadre = new SelectList(db.Tutors, "IDTutor", "Nombre", becado.IDPadre);
            return View(becado);
        }

        // GET: Becados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becado becado = db.Becadoes.Find(id);
            if (becado == null)
            {
                return HttpNotFound();
            }
            return View(becado);
        }

        // POST: Becados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Becado becado = db.Becadoes.Find(id);
            db.Becadoes.Remove(becado);
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

        public ActionResult MyPartialView(int id)
        {
            if (id == null)
                id = 4;

       
            var result = new PartialModels();
            using (var context = new PamelaEntities())
            
            {
                var info = context.View_Becado_HistoricoPeriodosCategoriaBecadoTutorEscuelaSocial(id);
                result.todolist = info.ToList();
                var info1 =  context.View_Becado_HistoricoFolios(id);
                result.folioList = info1.ToList();
                
            }

            return View(result);
        }

  
            }
        }
   

