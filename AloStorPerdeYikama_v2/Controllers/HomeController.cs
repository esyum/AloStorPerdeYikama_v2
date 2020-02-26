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
            obj.DTO_galery = db.galery.OrderByDescending(x => x.OlusturmaTarihi).Take(12).ToList();
            obj.DTO_slider = db.slayder.OrderByDescending(x => x.OlusturmaTarihi).Take(3).ToList();
            obj.DTO_galery_tur = db.galery_tur.ToList();
            obj.DTO_Hizmet_Turu = db.hizmet_turu.ToList();
            obj.DTO_iletisim = new Iletisim();
            return View("Index",obj);
        }

        [HttpPost]
        public ActionResult BilgiIstekFormuGonder(AnaSayfaDTO blgform)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index", "Home");

                Iletisim _bilgiform = new Iletisim();
                _bilgiform.name = blgform.DTO_iletisim.name;
                _bilgiform.eposta = blgform.DTO_iletisim.eposta;
                _bilgiform.konu = blgform.DTO_iletisim.konu;
                _bilgiform.mesaj = blgform.DTO_iletisim.mesaj;
                _bilgiform.OlusturmaTarihi = DateTime.Now;

                db.iletisim.Add(_bilgiform);
                db.SaveChanges();
                TempData["Mesaj"] = "Form Başarı ile gönderilmiştir.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }

        }

        public ActionResult ByCategory(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TempData["_filterName"] = ID;

            return RedirectToAction("Index");
        }

        public ActionResult Galery_Partial()
        {
            List<Galery> _galery = db.galery.OrderByDescending(x => x.OlusturmaTarihi).ToList();

            return PartialView("_PartialGalery", _galery);
        }

        public ActionResult HizmetTurleri(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<HizmetTuru> hzt = db.hizmet_turu.Where(x => x.ID == ID).ToList();

            if (hzt == null)
            {
                return HttpNotFound();
            }
            return PartialView("_PartialHizmetDetay", hzt);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
               List<Login> _login = db.login.Where(x => x.Username == model.Username&&x.Password==model.Password).ToList();

                if (_login.Count>0)
                {
                    Session["username"] = model.Username;

                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    TempData["LoginHata"] = "Kullanıcı adı veya şifre hatalı...";
                    return View();
                }
            }
            return View();
        }
    }
}