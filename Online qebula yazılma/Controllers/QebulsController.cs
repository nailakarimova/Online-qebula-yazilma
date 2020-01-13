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
    public class QebulsController : Controller
    {
        private QachqinKomEntities db = new QachqinKomEntities();

        // GET: Qebuls
        public ActionResult Index()
        {
            var qebuls = db.Qebuls.Include(q => q.Istifadechiler).Include(q => q.Istifadechiler1).Include(q => q.Istiqamet).Include(q => q.Kateqoriya).Include(q => q.Kochkun_dushduyu_rayon).Include(q => q.Meskunlashdigi_rayon).Include(q => q.Sosial_durum);
            return View(qebuls.ToList());
        }

        // GET: Qebuls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qebul qebul = db.Qebuls.Find(id);
            if (qebul == null)
            {
                return HttpNotFound();
            }
            return View(qebul);
        }

        // GET: Qebuls/Create
        public ActionResult Create()
        {
            ViewBag.istifadechi_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi");
            ViewBag.qebul_eden_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi");
            ViewBag.istiqamet_id = new SelectList(db.Istiqamets, "istiqamet_id", "istiqamet_adi");
            ViewBag.kateqoriya_id = new SelectList(db.Kateqoriyas, "kateqoriya_id", "kateqoriya_adi");
            ViewBag.kochkun_rayon_id = new SelectList(db.Kochkun_dushduyu_rayon, "kochkun_rayon_id", "rayon_adi");
            ViewBag.meskunlashdigi_rayon_id = new SelectList(db.Meskunlashdigi_rayon, "meskunlashdigi_rayon_id", "rayon_adi");
            ViewBag.durum_id = new SelectList(db.Sosial_durum, "durum_id", "durum_adi");
            return View();
        }

        // POST: Qebuls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "qebul_id,istifadechi_id,ad_soyad,dogum_tarixi,sh_vesiqesi_no,fin,email,mobile,phone,kochkun_rayon_id,meskunlashdigi_rayon_id,unvan,durum_id,kateqoriya_id,istiqamet_id,qebul_eden_id,qebul_date,qeyd")] Qebul qebul)
        {
            if (ModelState.IsValid)
            {
                db.Qebuls.Add(qebul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.istifadechi_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi", qebul.istifadechi_id);
            ViewBag.qebul_eden_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi", qebul.qebul_eden_id);
            ViewBag.istiqamet_id = new SelectList(db.Istiqamets, "istiqamet_id", "istiqamet_adi", qebul.istiqamet_id);
            ViewBag.kateqoriya_id = new SelectList(db.Kateqoriyas, "kateqoriya_id", "kateqoriya_adi", qebul.kateqoriya_id);
            ViewBag.kochkun_rayon_id = new SelectList(db.Kochkun_dushduyu_rayon, "kochkun_rayon_id", "rayon_adi", qebul.kochkun_rayon_id);
            ViewBag.meskunlashdigi_rayon_id = new SelectList(db.Meskunlashdigi_rayon, "meskunlashdigi_rayon_id", "rayon_adi", qebul.meskunlashdigi_rayon_id);
            ViewBag.durum_id = new SelectList(db.Sosial_durum, "durum_id", "durum_adi", qebul.durum_id);
            return View(qebul);
        }

        // GET: Qebuls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qebul qebul = db.Qebuls.Find(id);
            if (qebul == null)
            {
                return HttpNotFound();
            }
            ViewBag.istifadechi_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi", qebul.istifadechi_id);
            ViewBag.qebul_eden_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi", qebul.qebul_eden_id);
            ViewBag.istiqamet_id = new SelectList(db.Istiqamets, "istiqamet_id", "istiqamet_adi", qebul.istiqamet_id);
            ViewBag.kateqoriya_id = new SelectList(db.Kateqoriyas, "kateqoriya_id", "kateqoriya_adi", qebul.kateqoriya_id);
            ViewBag.kochkun_rayon_id = new SelectList(db.Kochkun_dushduyu_rayon, "kochkun_rayon_id", "rayon_adi", qebul.kochkun_rayon_id);
            ViewBag.meskunlashdigi_rayon_id = new SelectList(db.Meskunlashdigi_rayon, "meskunlashdigi_rayon_id", "rayon_adi", qebul.meskunlashdigi_rayon_id);
            ViewBag.durum_id = new SelectList(db.Sosial_durum, "durum_id", "durum_adi", qebul.durum_id);
            return View(qebul);
        }

        // POST: Qebuls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "qebul_id,istifadechi_id,ad_soyad,dogum_tarixi,sh_vesiqesi_no,fin,email,mobile,phone,kochkun_rayon_id,meskunlashdigi_rayon_id,unvan,durum_id,kateqoriya_id,istiqamet_id,qebul_eden_id,qebul_date,qeyd")] Qebul qebul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qebul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.istifadechi_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi", qebul.istifadechi_id);
            ViewBag.qebul_eden_id = new SelectList(db.Istifadechilers, "istifadechi_id", "istifadechi_adi", qebul.qebul_eden_id);
            ViewBag.istiqamet_id = new SelectList(db.Istiqamets, "istiqamet_id", "istiqamet_adi", qebul.istiqamet_id);
            ViewBag.kateqoriya_id = new SelectList(db.Kateqoriyas, "kateqoriya_id", "kateqoriya_adi", qebul.kateqoriya_id);
            ViewBag.kochkun_rayon_id = new SelectList(db.Kochkun_dushduyu_rayon, "kochkun_rayon_id", "rayon_adi", qebul.kochkun_rayon_id);
            ViewBag.meskunlashdigi_rayon_id = new SelectList(db.Meskunlashdigi_rayon, "meskunlashdigi_rayon_id", "rayon_adi", qebul.meskunlashdigi_rayon_id);
            ViewBag.durum_id = new SelectList(db.Sosial_durum, "durum_id", "durum_adi", qebul.durum_id);
            return View(qebul);
        }

        // GET: Qebuls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qebul qebul = db.Qebuls.Find(id);
            if (qebul == null)
            {
                return HttpNotFound();
            }
            return View(qebul);
        }

        // POST: Qebuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qebul qebul = db.Qebuls.Find(id);
            db.Qebuls.Remove(qebul);
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
