using Online_qebula_yazılma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_qebula_yazılma.Controllers
{
    public class LoginController : Controller
    {
        QachqinKomEntities db = new QachqinKomEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Istifadechiler objCheck)
        {
            if (ModelState.IsValid)
            {
                using (QachqinKomEntities db = new QachqinKomEntities())
                {
                    var obj = db.Istifadechilers.Where(a => a.istifadechi_adi.Equals(objCheck.istifadechi_adi) && a.shifre.Equals(objCheck.shifre)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["istifadechi_id"] = obj.istifadechi_id.ToString();
                        Session["istifadechi_adi"] = obj.istifadechi_adi.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "İstifadəçi adı və ya şifrə səhvdir");
                    }
                }
            }

            return View(objCheck);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}