using AloStorPerdeYikama_v2.Context;
using AloStorPerdeYikama_v2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AloStorPerdeYikama_v2.Controllers
{
    public class VideoController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Video
        public ActionResult Index()
        {
           
            return View(db.video.Where(p=>p.ContentType=="video/mp4").ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            
            db.video.Add(new Video
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult DownloadFile(int? fileId)
        {

            Video file = db.video.ToList().Find(p => p.ID == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }
    }
}