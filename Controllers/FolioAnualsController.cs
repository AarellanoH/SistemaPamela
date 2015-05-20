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
    public class FolioAnualsController : Controller
    {
        private PamelaEntities db = new PamelaEntities();

        // GET: FolioAnuals
        public ActionResult Index()
        {
            var folioAnuals = db.FolioAnuals.Include(f => f.HistoricoAnual);
            return View(folioAnuals.ToList());
        }

        // GET: FolioAnuals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolioAnual folioAnual = db.FolioAnuals.Find(id);
            if (folioAnual == null)
            {
                return HttpNotFound();
            }
            return View(folioAnual);
        }

        // GET: FolioAnuals/Create
        public ActionResult Create()
        {
            ViewBag.IDHistorico = new SelectList(db.HistoricoAnuals, "IDHistoricoAnual", "IDHistoricoAnual");
            return View();
        }

        // POST: FolioAnuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFolio,Monto,Fecha,ModoPago,IDHistorico,Parcialidad")] FolioAnual folioAnual)
        {
            if (ModelState.IsValid)
            {
                db.FolioAnuals.Add(folioAnual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHistorico = new SelectList(db.HistoricoAnuals, "IDHistoricoAnual", "IDHistoricoAnual", folioAnual.IDHistorico);
            return View(folioAnual);
        }

        // GET: FolioAnuals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolioAnual folioAnual = db.FolioAnuals.Find(id);
            if (folioAnual == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHistorico = new SelectList(db.HistoricoAnuals, "IDHistoricoAnual", "IDHistoricoAnual", folioAnual.IDHistorico);
            return View(folioAnual);
        }

        // POST: FolioAnuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDFolio,Monto,Fecha,ModoPago,IDHistorico,Parcialidad")] FolioAnual folioAnual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(folioAnual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDHistorico = new SelectList(db.HistoricoAnuals, "IDHistoricoAnual", "IDHistoricoAnual", folioAnual.IDHistorico);
            return View(folioAnual);
        }

        // GET: FolioAnuals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolioAnual folioAnual = db.FolioAnuals.Find(id);
            if (folioAnual == null)
            {
                return HttpNotFound();
            }
            return View(folioAnual);
        }

        // POST: FolioAnuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FolioAnual folioAnual = db.FolioAnuals.Find(id);
            db.FolioAnuals.Remove(folioAnual);
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

        public ActionResult PartialView()
        {
           
            var result = new PartialModels();
            using (var context = new PamelaEntities())
            {
                int prueba = FolioAnual.miDato();
                var info2 = new FolioAnual();
                var info = context.View__HistoricoFolios();
                result.historiaList = info.ToList();
                result.anual = info2;
                var becadoes = db.Becadoes.Include(b => b.Tutor);
                result.becadoList = becadoes.ToList();

                ViewBag.IDHistorico = new SelectList(db.HistoricoAnuals, "IDHistoricoAnual", "IDHistoricoAnual", info2.IDHistorico);
                List<SelectListItem> parcialidad = new List<SelectListItem>();
                parcialidad.Add(new SelectListItem { Text = "1", Value = "1" });
                parcialidad.Add(new SelectListItem { Text = "2", Value = "2" });
                parcialidad.Add(new SelectListItem { Text = "3", Value = "3" });
                parcialidad.Add(new SelectListItem { Text = "4", Value = "4" });
                parcialidad.Add(new SelectListItem { Text = "5", Value = "5" });
                ViewBag.Parcialidad = new SelectList(parcialidad, "Value", "Text");
            }

            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartialView([Bind(Include = "IDFolio,Monto,Fecha,ModoPago,IDHistorico,Parcialidad")] FolioAnual folioAnual)
        {
            if (ModelState.IsValid)
            {
                db.FolioAnuals.Add(folioAnual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHistorico = new SelectList(db.HistoricoAnuals, "IDHistoricoAnual", "IDHistoricoAnual", folioAnual.IDHistorico);
            return View(folioAnual);
        }
    }
}
