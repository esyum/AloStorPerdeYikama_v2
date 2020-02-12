using AloStorPerdeYikama_v2.Context;
using AloStorPerdeYikama_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AloStorPerdeYikama_v2.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        
        // GET: Home
        public ActionResult Index()
        {
            AnaSayfaDTO obj = new AnaSayfaDTO();
            obj.DTO_slider = db.slayder.OrderByDescending(x => x.OlusturmaTarihi).ToList();
            obj.DTO_galery = db.galery.OrderByDescending(x => x.OlusturmaTarihi).ToList();
            obj.DTO_Hizmet_Turu = db.hizmet_turu.ToList();
            //List<Slayder> slayt = db.slayder.ToList();

            return View(obj);
        }

        public ActionResult ByCategory(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Galery> _galery = db.galery.Where(x => x.ID == ID).ToList();
            if (_galery==null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Index", _galery);
        }

        public ActionResult HizmetTurleri(int? ID)
        {
            if (ID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             List<HizmetTuru> hzt = db.hizmet_turu.Where(x => x.ID == ID).ToList();
             
            if (hzt==null)
            {
                return HttpNotFound();
            }
            return PartialView("_PartialHizmetDetay",hzt);
        }

        public ActionResult GaleryTurleri()
        {
            List<Galery_Tur> _galery_tur = db.galery_tur.ToList();

            return PartialView("_PartialCategory",_galery_tur);
        }
    }
}