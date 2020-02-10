using AloStorPerdeYikama_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Controllers
{
    public class AnaSayfaDTO
    {
        public List<Slayder> DTO_slider { get; set; }

        public List<Galery> DTO_galery { get; set; }

        public List<Galery_Tur> DTO_galery_tur { get; set; }

        public Slayder DTO_Slayder_Model { get; set; }

        public Galery DTO_Galery_Model { get; set; }

        public List<HizmetTuru> DTO_Hizmet_Turu { get; set; }

    }
}