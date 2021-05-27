using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeödevi.Models.Entity;

namespace projeödevi.Controllers
{
    public class sepetController : Controller
    {
        // GET: sepet
        eticaretEntities5 db = new eticaretEntities5();
        public ActionResult Index(int id)
        {
        
         
            var model = db.ürünler.Where(x => x.ürünid == id).FirstOrDefault();
            return View(model);
        }
     


    }
}