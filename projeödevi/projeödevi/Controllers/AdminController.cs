using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;



namespace projeödevi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
     
     

        //GET:KATEGORİ 

        eticaretEntities5 db = new eticaretEntities5();
      
        public ViewResult Kategori()
        {
            var degerler = db.kategori.ToList();   //listeleme işlemi yapıldı
            return View(degerler);

        }

        [HttpGet]
       
        public ActionResult YeniKategori() // sayfa yüklenince httpget yap
        {
            return View();
        }





        [HttpPost]
      
        public ActionResult YeniKategori(kategori p1)  //ben butona tılayınca httpost yap 
        {
            db.kategori.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }
        
        public ActionResult SIL(int id)
        {
            var kategori = db.kategori.Find(id);
            db.kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.kategori.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(kategori p1)
        { 
            var ktg = db.kategori.Find(p1.kategoriid);
            ktg.kategoriad = p1.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ViewResult Index()
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