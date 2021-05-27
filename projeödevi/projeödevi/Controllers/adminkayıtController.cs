using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;

namespace projeödevi.Controllers
{
    [Authorize(Roles = "A")]
    public class adminkayıtController : Controller
    {
        // GET: ayarlar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Üye()
        {
            var degerler = db.adminlogin.ToList();   //listeleme işlemi yapıldı
            return View(degerler);
           
        }

        eticaretEntities5 db = new eticaretEntities5();
        public ActionResult ÜyeGetir(int id)
        {
            var ayr =db.adminlogin.Find(id);

            return View("ÜyeGetir",ayr);
        }

        public ActionResult Guncelle(adminlogin p5)
        {
            var ayr = db.adminlogin.Find(p5.id);
            ayr.ad = p5.ad;
            ayr.sifre = p5.sifre;
            ayr.Rol = p5.Rol;
          
            db.SaveChanges();
            return RedirectToAction("Üye");

        }
    }
}
