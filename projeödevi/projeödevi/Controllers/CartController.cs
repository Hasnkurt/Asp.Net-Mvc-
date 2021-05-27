using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;


namespace projeödevi.Controllers
{
    public class CartController : Controller
    {
       
        eticaretEntities5 db = new eticaretEntities5();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public PartialViewResult SepetÖzet()
        {
            return PartialView(GetCart());
        }
        public ActionResult ÜrünSil(int id)
        {
            var ürünler = db.ürünler.FirstOrDefault(i => i.ürünid == id);
            if (ürünler!=null)
            {
                GetCart().DeleteÜrün(ürünler);
            }
            return RedirectToAction("Index");
        }
        public ActionResult EkleÜrün(int id)
        {
            var ürünler = db.ürünler.FirstOrDefault(i => i.ürünid == id);
            if (ürünler!=null)
            {
                GetCart().EkleÜrün(ürünler, 1);
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }return cart;
        }

       
        [HttpPost]
        public ActionResult SiparişTamamla(siparişdetay model)
        {
            var cart = GetCart();
            if (cart.Cartlines.Count==0)
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde Ürün yok");

            }
            if(ModelState.IsValid)
            {
                SaveOrder(cart,model);
                cart.temizle();
                return View("SiparişTamamlandı");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult SiparişTamamla()
        {

            return View();
        }


        private void SaveOrder(Cart cart,siparişdetay model)
        {
            var sipariş = new sipariş();
            sipariş.siparisno = "A" + (new Random()).Next(1111, 9999).ToString();
            sipariş.kullaniciadi = sipariş.kullaniciadi;
            sipariş.sipariştarihi = sipariş.sipariştarihi;
            sipariş.adres = sipariş.adres;
            sipariş.sehir = sipariş.sehir;
            sipariş.Siparişlerims = new List<Siparişlerim>();
          
           
            db.sipariş.Add(sipariş);
            db.SaveChanges();
        }







    }
}