using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;

namespace projeödevi.Controllers
{
    public class ÜrünController : Controller
    {
        // GET: Ürün
        eticaretEntities5 db = new eticaretEntities5();
        public ActionResult Index()
        {
            return View();
        }
      


        [Route("urun/{id}")]
        public  ActionResult ÜrünDetay(int id)
        {
        
            {
                var model = db.ürünler.Where(x => x.ürünid == id).FirstOrDefault();
                return View(model);
            }


        }
    


       
      


    }
}