using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Models
{
    [Table("Galery")]
    public partial class Galery
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name ="Grup"), Required]
        public string filter_name { get; set; }

        [Display(Name = "Resim")]
        public byte[] galery_pic { get; set; }

        [Display(Name = "Resim Açıklaması"), StringLength(30),Required]
        public string title { get; set; }

        [Display(Name = "Başlık"), StringLength(30),Required]
        public string baslik { get; set; }

        [Display(Name = "Alt Başlık"), StringLength(30),Required]
        public string alt_baslik { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; }

    }
}