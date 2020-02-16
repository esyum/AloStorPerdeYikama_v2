using AloStorPerdeYikama_v2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Slayder> slayder { get; set; }
        public DbSet<Galery> galery { get; set; }
        public DbSet<Galery_Tur> galery_tur { get; set; }
        public DbSet<HizmetTuru> hizmet_turu { get; set; }
        public DbSet<Iletisim> iletisim { get; set; }

        public DatabaseContext()
        {
            //Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
    }

    public class VeritabaniOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            ////slayder oluştur

            //Slayder _slayder = new Slayder();
            //_slayder.OlusturmaTarihi = DateTime.Now;
            //_slayder.SliderSubText = "Sağlığınızı önemsiyor, çevre dostu temizlik ürünleri kullanıyoruz. Tecrübeli personelimiz ile hizmetinizdeyiz.";
            //_slayder.SliderText = "PERDELERİNİZİ İLK GÜNKÜ HALİNE GETİRİYORUZ";

            //Image resim = Image.FromFile(@"\\Content\\img\\storperde.jpg");

            //using (MemoryStream m = new MemoryStream())
            //{
            //    resim.Save(m, resim.RawFormat);
            //    _slayder.SliderFoto = m.ToArray();
            //}
            //context.slayder.Add(_slayder);
            //context.SaveChanges();

            //List<Slayder> tumSlayt = context.slayder.ToList();

            ////galery ekle

            //Galery _galery = new Galery();
            //_galery.baslik = "Stor Perdeniz Tertemiz";
            //_galery.alt_baslik = "Titiz temizlik bizim işimiz.";
            //_galery.filter_name = "temiz";
            //_galery.title = "Alo Stor Perde";
            //_galery.OlusturmaTarihi = DateTime.Now;

            //resim = Image.FromFile(@"D:\yazılım\esyum\Stor_Perde_Yikama\Stor_Perde_Yikama\Content\img\bg-img\1-1.jpg");

            //using (MemoryStream g = new MemoryStream())
            //{
            //    resim.Save(g, resim.RawFormat);
            //    _galery.galery_pic = g.ToArray();
            //}

            //context.galery.Add(_galery);
            //context.SaveChanges();


            ////galery 
        }


    }
}