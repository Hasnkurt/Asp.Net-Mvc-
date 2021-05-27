using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;

namespace projeödevi.Controllers
{
    [Authorize]
    public class markaController : Controller
    {
        // GET: marka
        eticaretEntities5 db = new eticaretEntities5();
        public ActionResult Index()
        {
            var degerler = db.markalar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMarka()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMarka(markalar p1)
        {
            db.markalar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkaGetir(int id)
        {
            var ktgr1 = db.markalar.Find(id);
            return View("MarkaGetir", ktgr1);
        }
        public ActionResult SIL(int id)
        {
            var markalar = db.markalar.Find(id);
            db.markalar.Remove(markalar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(markalar p2)
        {
            var ktg = db.markalar.Find(p2.markaid);
            ktg.markaad = p2.markaad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

