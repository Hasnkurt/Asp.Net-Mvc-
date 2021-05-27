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
    public class SliderController : Controller
    {
        eticaretEntities5 db = new eticaretEntities5();
        // GET: Slider
        public ActionResult Index()
        {
            var degerler = db.sliderüst.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Slider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Slider(sliderüst p2)
        {
            if (Request.Files.Count > 0)

            {

                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p2.slider = "/images/" + randomName;

                var path = "/images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));

            }
            db.sliderüst.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var slider = db.sliderüst.Find(id);
            db.sliderüst.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SliderGetir(int id)
        {
            var ayr = db.sliderüst.Find(id);

            return View("SliderGetir", ayr);
        }


        public ActionResult GUNCELLE(sliderüst p)
        {

            if (Request.Files.Count > 0)

            {

                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p.slider = "/images/" + randomName;

                var path = "/images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));

            }




            var urun = db.sliderüst.Find(p.id);
         
            urun.slider = p.slider;
        
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}