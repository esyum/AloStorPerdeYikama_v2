using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Models
{
    [Table("HizmetTuru")]
    public partial class HizmetTuru
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Hizmet Foto")]
        public byte[] fotograf { get; set; }

        [Display(Name = "Baslik")]
        [StringLength(300)]
        public string Title { get; set; }

        [Display(Name = "Gövde Metni")]
        public string TitleSub { get; set; }

        [Display(Name = "Tarih")]
        [Required]
        public DateTime OlusturmaTarihi { get; set; }
    }
}