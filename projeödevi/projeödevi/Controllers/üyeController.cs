using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using projeödevi.Models.Entity;

namespace projeödevi.Controllers
{
    public class üyeController : Controller
    {
        // GET: üye
        eticaretEntities5 db = new eticaretEntities5();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ÜyeEkle()
        {
            return View();
        }   

        [HttpPost]
        public ActionResult ÜyeEkle(kayitol kayitol)
        {

            kayitol.Role = "User";

            db.kayitol.Add(kayitol);
        
           

            db.SaveChanges();
           
            return View();
        }

        [Authorize(Roles = "A")]
        public ActionResult ÜyeList()
        {
            var degerler = db.kayitol.ToList();   //listeleme işlemi yapıldı
            return View(degerler);

        }


        public ActionResult login()
        {

            
            return View();
        }


        [HttpPost]
        public ActionResult login(kayitol p)
        {
            var bilgiler = db.kayitol.FirstOrDefault(x => x.eposta == p.eposta && x.sifre == p.sifre);
            if (bilgiler != null)
            {
              
                return RedirectToAction("Index", "Home");

            }


            else

            {
                TempData["Basarisiz"] = "E-Posta Adresiniz veya Şifreniz yanlış lütfen tekrar deneyiniz.";
                return View();
            }

        }

        public ActionResult sifreunuttum()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Home");
        }
    }
}