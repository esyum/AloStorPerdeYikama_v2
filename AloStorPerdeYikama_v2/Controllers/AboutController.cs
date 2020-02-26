using AloStorPerdeYikama_v2.Context;
using AloStorPerdeYikama_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AloStorPerdeYikama_v2.Controllers
{
    public class AboutController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: About
        public ActionResult Index()
        {
                                
            //List<Video> _video = db.video.OrderByDescending(x => x.OlusturmaTarihi).Where(x => x.ContentType == "Video/mp4").ToList();
            return View(db.video.OrderByDescending(x=>x.OlusturmaTarihi).Where(p => p.ContentType == "video/mp4").Take(3).ToList());
        }

        [HttpGet]
        public FileResult DownloadFile(int? fileId)
        {
            Video file = db.video.ToList().Find(p => p.ID == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }
    }
}