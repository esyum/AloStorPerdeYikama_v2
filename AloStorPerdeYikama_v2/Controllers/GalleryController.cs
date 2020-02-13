using AloStorPerdeYikama_v2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AloStorPerdeYikama_v2.Controllers
{
    public class GalleryController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: Gallery
        public ActionResult Index()
        {
            AnaSayfaDTO obj = new AnaSayfaDTO();
            obj.DTO_galery = db.galery.OrderByDescending(x => x.OlusturmaTarihi).ToList();

            return View(obj);
        }
    }
}