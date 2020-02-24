using AloStorPerdeYikama_v2.Context;
using AloStorPerdeYikama_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AloStorPerdeYikama_v2.Controllers
{
    public class ContactController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: Contact
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult BilgiIstekFormuGonder(Iletisim blgform)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index");

                Iletisim _bilgiform = new Iletisim();
                _bilgiform.name = blgform.name;
                _bilgiform.eposta = blgform.eposta;
                _bilgiform.konu = blgform.konu;
                _bilgiform.mesaj = blgform.mesaj;
                _bilgiform.OlusturmaTarihi = DateTime.Now;

                db.iletisim.Add(_bilgiform);
                db.SaveChanges();
                TempData["Mesaj"] = "Form Başarı ile gönderilmiştir.";
                return View("Index");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }

        }

    }
}