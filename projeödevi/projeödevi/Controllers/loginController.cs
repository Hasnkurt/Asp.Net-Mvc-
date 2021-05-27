using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Configuration;
using System.Web.Helpers;
using System.Web.Security;

namespace projeödevi.Controllers
{

    public class loginController : Controller
    {
        // GET: login
        eticaretEntities5 db = new eticaretEntities5();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(adminlogin k)
        {
            var bilgiler = db.adminlogin.FirstOrDefault(x => x.ad == k.ad && x.sifre == k.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.ad,false);
                return RedirectToAction("Index", "Admin");

            }

       
            else
          
            {
                TempData["Basarisiz"] = "E-Posta Adresiniz veya Şifreniz yanlış lütfen tekrar deneyiniz.";
                return View();
            }

        }
  
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();    
            return RedirectToAction("Index","Login");
        }



        public ActionResult sifreunuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sifreunuttum(adminlogin p)
          

        {
            var model = db.adminlogin.Where(x => x.ad == p.ad).SingleOrDefault();
            if (model!=null)
            {
                Guid rastgele = Guid.NewGuid();
                model.sifre = rastgele.ToString().Substring(0, 8);
                db.SaveChanges();

                MailMessage mm = new MailMessage();
                mm.SubjectEncoding = Encoding.Default;
                mm.Subject = "Admin Panel Şifremi Unuttum ";
                mm.BodyEncoding = Encoding.Default;
                mm.Body += "Merhaba Yeni Admin Şifreniz Lütfen Sisteme Giriş Yaptıkdan Sonra Güncellemenizi Öneririz." + "<br/>Kullanıcı Adınız=" + model.ad + "<br/> Şifreniz=" + model.sifre;
                mm.IsBodyHtml = true;
                mm.From = new MailAddress("hkmusicmartket@gmail.com", "Şifre Sıfırlama");
          
                mm.To.Add("hkmusicmarket@gmail.com");
            

            
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
                smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
                smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);
                smtpClient.Send(mm);

                TempData["Basarili"] = "E-posta Adresinize Bilgilerinizi Gönderdik Lütfen Kontrol Ediniz.";




                return View();






            }

            else
            {
                TempData["Basarisiz"] = "E-Posta Adresiniz Sistemde Mevcut Degil Lütfen Dikkatli Bir Şekilde Yazınız.";
                return View();
            }
        }

   

        public ActionResult kayitol()
        {
            return View();
        }

     
    }
}