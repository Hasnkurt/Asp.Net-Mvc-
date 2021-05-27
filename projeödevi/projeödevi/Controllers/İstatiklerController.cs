using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;

namespace projeödevi.Controllers
{
    public class İstatiklerController : Controller
    {
        eticaretEntities5 db = new eticaretEntities5();
        
        // GET: İstatikler
        public ActionResult Index()
        {
            
            var deger1 = db.kategori.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = db.ürünler.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = db.markalar.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = db.kayitol.Count().ToString();
            ViewBag.d4 = deger4;
            return View();
        }
    }
}