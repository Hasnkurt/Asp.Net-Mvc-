using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;
using projeödevi.Models;

namespace projeödevi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        eticaretEntities5 db = new eticaretEntities5();
        public ViewResult Home()
        {
            return View();
        }




        public PartialViewResult Partial1()
        {
            var degerler = db.kategori.ToList();   //listeleme işlemi kategori web sitesi unutma 

            return PartialView(degerler);
        }


        public PartialViewResult Ürünler()

        {
           
            var degerler = db.ürünler.ToList();
            return PartialView(degerler);
        }

  
        [Route("Index/{id}")]
        public PartialViewResult ÜrünDetay(Int32 id)

        {
            eticaretEntities5 db = new eticaretEntities5();
            var urun = db.ürünler.Where(x => x.ürünid == id).FirstOrDefault();
            return PartialView(urun);

        }


        public PartialViewResult Sliderüstt()
        {

            var liste = db.sliderüst.Where(x => x.slider == x.slider).Take(5).ToList();
            return PartialView(liste);
        }

        public ActionResult ürünlistesi(int id)
        {
            return View(db.ürünler.Where(i => i.kategori.kategoriid == id).ToList());
        }

        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

    }

}