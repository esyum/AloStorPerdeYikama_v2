using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Models
{
    [Table("Iletisim")]
    public partial class Iletisim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "İsim"),
            Required,
            StringLength(40)]
        public string name { get; set; }


        [Display(Name = "Eposta"),
            StringLength(50),
            Required,
            EmailAddress]
        public string eposta { get; set; }

        [Display(Name = "Konu"), StringLength(50), Required]
        public string konu { get; set; }

        [Display(Name = "Mesaj"), StringLength(500), Required]
        public string mesaj { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; }

    }
}