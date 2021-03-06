﻿using AloStorPerdeYikama_v2.Context;
using AloStorPerdeYikama_v2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AloStorPerdeYikama_v2.Controllers
{
    //SET GLOBAL max_allowed_packet=1024*1024*1024; 
    //mysql de dosya boyut sıkıntısını aşmak için bu işlemi yapmamız gerekmektedir. MYSQL de.

    [UserAuthorize]
    public class AdminController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyIletisim()
        {
            List<Iletisim> _iletisim = db.iletisim.OrderByDescending(x => x.OlusturmaTarihi).ToList();
            return View(_iletisim);
        }

        public ActionResult MySlayder()
        {
            List<Slayder> _slayder = db.slayder.OrderByDescending(x => x.OlusturmaTarihi).ToList();
            return View(_slayder);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slayder s, HttpPostedFileBase file)
        {
            try
            {
                Slayder _slayder = new Slayder();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _slayder.SliderFoto = memoryStream.ToArray();

                    _slayder.SliderText = s.SliderText;
                    _slayder.SliderSubText = s.SliderSubText;
                    _slayder.OlusturmaTarihi = DateTime.Now;
                    db.slayder.Add(_slayder);
                    db.SaveChanges();

                    return RedirectToAction("MySlayder", "Admin");

                }

                return View(s);

            }
            catch (Exception)
            {

                throw new Exception("Hata oluştu");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slayder _slayder = db.slayder.Find(id);
            if (_slayder == null)
            {
                return HttpNotFound();
            }
            return View(_slayder);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slayder s, HttpPostedFileBase file)
        {
            try
            {
                if (s.SliderText == null || s.SliderSubText == null)
                {
                    TempData["edit_hata"] = "Tüm alanları doldurun...";
                    return View(s);
                }

                Slayder _slayder = new Slayder();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _slayder.SliderFoto = memoryStream.ToArray();
                }

                _slayder.ID = s.ID;
                _slayder.SliderText = s.SliderText;
                _slayder.SliderSubText = s.SliderSubText;
                _slayder.OlusturmaTarihi = DateTime.Now;

                db.Entry(_slayder).State = EntityState.Modified;

                if (file == null)
                    db.Entry(_slayder).Property(m => m.SliderFoto).IsModified = false;
                db.SaveChanges();


                return RedirectToAction("MySlayder", "Admin");
            }
            catch (Exception)
            {

                throw new Exception("Hata oluştu");
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(_slayder).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("MySlayder");
            //}
            //return View(_slayder);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slayder _slayder = db.slayder.Find(id);
            if (_slayder == null)
            {
                return HttpNotFound();
            }
            return View(_slayder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slayder _slayder = db.slayder.Find(id);
            db.slayder.Remove(_slayder);
            db.SaveChanges();
            return RedirectToAction("MySlayder");
        }

        public ActionResult MyGalery()
        {
            List<Galery> _galery = db.galery.OrderByDescending(x => x.OlusturmaTarihi).ToList();
            return View(_galery);
        }

        // GET: Admin/Create
        public ActionResult Galery_Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Galery_Create(AnaSayfaDTO s, HttpPostedFileBase file)
        {
            try
            {
                Galery _galery = new Galery();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _galery.galery_pic = memoryStream.ToArray();

                    _galery.baslik = s.DTO_Galery_Model.baslik;
                    _galery.alt_baslik = s.DTO_Galery_Model.alt_baslik;
                    _galery.filter_name = s.DTO_Galery_Model.filter_name;
                    _galery.title = s.DTO_Galery_Model.title;
                    _galery.OlusturmaTarihi = DateTime.Now;

                    db.galery.Add(_galery);
                    db.SaveChanges();

                    return RedirectToAction("MyGalery", "Admin");

                }

                return View(s);

            }
            catch (Exception)
            {

                throw new Exception("Hata oluştu");
            }
        }

        public ActionResult Galery_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galery _galery = db.galery.Find(id);
            if (_galery == null)
            {
                return HttpNotFound();
            }
            return View(_galery);
        }

        [HttpPost, ActionName("Galery_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_Galery(int id)
        {
            Galery _galery = db.galery.Find(id);
            db.galery.Remove(_galery);
            db.SaveChanges();
            return RedirectToAction("MyGalery");
        }

        // GET: Admin/Edit/5
        public ActionResult Galery_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galery _galery = db.galery.Find(id);
            if (_galery == null)
            {
                return HttpNotFound();
            }
            return View(_galery);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Galery_Edit(Galery s, HttpPostedFileBase file)
        {
            try
            {
                if (s.title == null || s.baslik == null || s.alt_baslik == null)
                {
                    TempData["edit_hata"] = "Tüm alanları doldurun...";
                    return View(s);
                }

                Galery _galery = new Galery();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _galery.galery_pic = memoryStream.ToArray();
                }

                _galery.ID = s.ID;
                _galery.baslik = s.baslik;
                _galery.alt_baslik = s.alt_baslik;
                _galery.title = s.title;
                _galery.filter_name = s.filter_name;
                _galery.OlusturmaTarihi = DateTime.Now;

                db.Entry(_galery).State = EntityState.Modified;

                if (file == null)
                    db.Entry(_galery).Property(m => m.galery_pic).IsModified = false;
                db.SaveChanges();

                return RedirectToAction("MyGalery", "Admin");
            }
            catch (Exception)
            {

                throw new Exception("Hata oluştu");
            }

        }

        //HİZMETLERİMİZ

        public ActionResult MyHizmet()
        {
            List<HizmetTuru> _hizmet = db.hizmet_turu.OrderByDescending(x => x.OlusturmaTarihi).ToList();
            return View(_hizmet);
        }

        public ActionResult HizmetTuru_Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HizmetTuru_Create(HizmetTuru s, HttpPostedFileBase file)
        {
            try
            {
                HizmetTuru _hizmet = new HizmetTuru();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _hizmet.fotograf = memoryStream.ToArray();

                    _hizmet.Title = s.Title;
                    _hizmet.TitleSub = s.TitleSub;
                    _hizmet.OlusturmaTarihi = DateTime.Now;

                    db.hizmet_turu.Add(_hizmet);
                    db.SaveChanges();

                    return RedirectToAction("MyHizmet", "Admin");

                }

                return View(s);

            }
            catch (Exception)
            {

                throw new Exception("Hata oluştu");
            }
        }

        public ActionResult HizmetTuru_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HizmetTuru _hizmet = db.hizmet_turu.Find(id);
            if (_hizmet == null)
            {
                return HttpNotFound();
            }
            return View(_hizmet);
        }

        [HttpPost, ActionName("HizmetTuru_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_HizmetTuru(int id)
        {
            HizmetTuru _hizmet = db.hizmet_turu.Find(id);
            db.hizmet_turu.Remove(_hizmet);
            db.SaveChanges();
            return RedirectToAction("MyHizmet");
        }

        // GET: Admin/Edit/5
        public ActionResult HizmetTuru_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HizmetTuru _hizmet = db.hizmet_turu.Find(id);
            if (_hizmet == null)
            {
                return HttpNotFound();
            }
            return View(_hizmet);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HizmetTuru_Edit(HizmetTuru s, HttpPostedFileBase file)
        {
            try
            {
                if (s.Title == null || s.TitleSub == null)
                {
                    TempData["edit_hata"] = "Tüm alanları doldurun...";
                    return View(s);
                }

                HizmetTuru _hizmet = new HizmetTuru();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _hizmet.fotograf = memoryStream.ToArray();
                }

                _hizmet.ID = s.ID;
                _hizmet.Title = s.Title;
                _hizmet.TitleSub = s.TitleSub;
                _hizmet.OlusturmaTarihi = DateTime.Now;

                db.Entry(_hizmet).State = EntityState.Modified;

                if (file == null)
                    db.Entry(_hizmet).Property(m => m.fotograf).IsModified = false;
                db.SaveChanges();

                return RedirectToAction("MyHizmet", "Admin");
            }
            catch (Exception)
            {

                throw new Exception("Hata oluştu");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyVideo()
        {
            return View(db.video.Where(p => p.ContentType == "video/mp4").ToList());
        }

        public ActionResult Video_Create()
        {
            return View();
        }

        //VİDEOYU database e kaydetme yöntemi
        //[HttpPost]
        //public ActionResult Video_Create(HttpPostedFileBase postedFile)
        //{
        //    try
        //    {
        //        if (postedFile == null)
        //        {
        //            return View();
        //        }

        //        byte[] bytes;
        //        //using (BinaryReader br = new BinaryReader(postedFile.InputStream))
        //        using (BinaryReader br = new BinaryReader(postedFile.InputStream))
        //        {
        //            bytes = br.ReadBytes(postedFile.ContentLength);
        //        }

        //        db.video.Add(new Video
        //        {
        //            Name = Path.GetFileName(postedFile.FileName),
        //            ContentType = postedFile.ContentType,
        //            Data = bytes,
        //            OlusturmaTarihi = DateTime.Now
        //        });
        //        db.SaveChanges();
        //        return RedirectToAction("MyVideo");
        //    }
        //    catch (Exception)
        //    {

        //        throw new Exception("Dosya boyutu aşıldı") ;
        //    }

        //}

        [HttpPost]
        public ActionResult Video_Create(HttpPostedFileBase postedFile)
        {
            try
            {
                if (postedFile == null)
                {
                    return View();
                }

                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    //İLGİLİ DOSYA KLASÖRE KAYDEDİLİR
                    var path = Path.Combine(Server.MapPath("~/Content/video/"), postedFile.FileName);
                    postedFile.SaveAs(path);

                    db.video.Add(new Video
                    {
                        Name = Path.GetFileName(postedFile.FileName),
                        ContentType = postedFile.ContentType,
                        Data = "~/Content/video/"+ Path.GetFileName(postedFile.FileName),
                        OlusturmaTarihi = DateTime.Now
                    });
                    db.SaveChanges();
                    return RedirectToAction("MyVideo");
                }

                return RedirectToAction("MyVideo");

                }
            catch (Exception)
            {

                throw new Exception("Dosya boyutu aşıldı");
            }

        }


        [HttpGet]
        public FileResult Video_DownloadFile(int? fileId)
        {
            Video file = db.video.ToList().Find(p => p.ID == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }

        public ActionResult Video_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video vd = db.video.Find(id);
            if (vd == null)
            {
                return HttpNotFound();
            }
            return View(vd);
        }

        [HttpPost, ActionName("Video_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_Video(int id)
        {
            Video vd = db.video.Find(id);
            db.video.Remove(vd);
            db.SaveChanges();
            return RedirectToAction("MyVideo");
        }
    }
}
