using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;

namespace projeödevi.Controllers
{
  [Authorize]
    [Authorize(Roles = "A")]
    public class adminürünController : Controller
    {
        // GET: adminürün

        eticaretEntities5 db = new eticaretEntities5();
        public ActionResult Index()
        {
            var degerler = db.ürünler.ToList();
            return View(degerler);
        }


     
        [HttpGet]
        [Authorize(Roles ="A")]
        public ActionResult ÜrünEkle()

        {
            List<SelectListItem> degerler = (from i in db.kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();

            List<SelectListItem> degerler1 = (from i in db.markalar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.markaad,
                                                 Value = i.markaid.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;
            ViewBag.dgr1 = degerler1;
     
            return View();

        }
     


        [HttpPost]
        public ActionResult ÜrünEkle(ürünler p1)

        {

            if (Request.Files.Count > 0)

            {

                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p1.ürünresmi = "/images/" + randomName;

                var path = "/images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));

            }

            var ktg = db.kategori.Where(m => m.kategoriid == p1.kategori.kategoriid).FirstOrDefault();
            p1.kategori = ktg;

            var ktg1 = db.markalar.Where(m => m.markaid == p1.markalar.markaid).FirstOrDefault();
            p1.markalar = ktg1;

      

            db.ürünler.Add(p1);
            
             db.SaveChanges();
            return RedirectToAction("Index");
        }
     

        public ActionResult SIL(int id)
        {
           
            var urun = db.ürünler.Find(id);
            db.ürünler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
           
        public ActionResult ÜrünGetir(int id)
            {
                var urun = db.ürünler.Find(id);
            List<SelectListItem> degerler = (from i in db.kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                                
                                             }).ToList();

            ViewBag.dgr = degerler;
         
            return View("ÜrünGetir", urun );
           


        }

      
     


        public ActionResult GUNCELLE(ürünler p)
        {

            if (Request.Files.Count > 0)

            {

                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p.ürünresmi = "/images/" + randomName;

                var path = "/images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));

            }




            var urun = db.ürünler.Find(p.ürünid);
            urun.ürünadi = p.ürünadi;
            urun.ürünmarka = p.ürünmarka;
            urun.ürünözellikleri = p.ürünözellikleri;
            //urun.ürünkategori = p.ürünkategori;
            var ktg = db.kategori.Where(m => m.kategoriid == p.kategori.kategoriid).FirstOrDefault();
            urun.ürünkategori = ktg.kategoriid;
            urun.ürünresmi = p.ürünresmi;
            urun.fiyat = p.fiyat;
            urun.stok = p.stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}