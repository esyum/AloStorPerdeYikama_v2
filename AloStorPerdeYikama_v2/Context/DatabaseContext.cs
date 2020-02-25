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
        public DbSet<Login> login { get; set; }
        public DbSet<tblFile> TblFile { get; set; }

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
            //Login için bir kişi oluşturuyoruz
            Login _login = new Login();
            _login.Username = "yahya";
            _login.Password = "aloyahya";
            context.login.Add(_login);
            context.SaveChanges();

            //Galery türlerini ekleyelim
            Galery_Tur _galery = new Galery_Tur();
            List<string> turler = new List<string> { "Yıkanmış Ürünler", "Karşılaştırma", "Ev Hizmetleri", "Ofis Hizmetleri" };
            foreach (var item in turler)
            {
                _galery.tur = item;
                context.galery_tur.Add(_galery);
                context.SaveChanges();
            }

        }


    }
}