using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_qebula_yazılma.Models;

namespace Online_qebula_yazılma.Controllers
{
    public class IstifadechilerController : Controller
    {
        private QachqinKomEntities db = new QachqinKomEntities();

        // GET: Istifadechiler
        public ActionResult Index()
        {
            return View(db.Istifadechilers.ToList());
        }

        // GET: Istifadechiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadechiler istifadechiler = db.Istifadechilers.Find(id);
            if (istifadechiler == null)
            {
                return HttpNotFound();
            }
            return View(istifadechiler);
        }

        // GET: Istifadechiler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Istifadechiler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "istifadechi_id,istifadechi_adi,istifadechi_novu")] Istifadechiler istifadechiler)
        {
            if (ModelState.IsValid)
            {
                db.Istifadechilers.Add(istifadechiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(istifadechiler);
        }

        // GET: Istifadechiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadechiler istifadechiler = db.Istifadechilers.Find(id);
            if (istifadechiler == null)
            {
                return HttpNotFound();
            }
            return View(istifadechiler);
        }

        // POST: Istifadechiler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "istifadechi_id,istifadechi_adi,istifadechi_novu")] Istifadechiler istifadechiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(istifadechiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(istifadechiler);
        }

        // GET: Istifadechiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadechiler istifadechiler = db.Istifadechilers.Find(id);
            if (istifadechiler == null)
            {
                return HttpNotFound();
            }
            return View(istifadechiler);
        }

        // POST: Istifadechiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Istifadechiler istifadechiler = db.Istifadechilers.Find(id);
            db.Istifadechilers.Remove(istifadechiler);
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
