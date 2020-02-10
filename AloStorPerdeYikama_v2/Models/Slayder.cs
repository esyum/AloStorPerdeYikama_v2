using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Models
{
    [Table("Slayder")]
    public partial class Slayder
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Slider Foto")]
        public byte[] SliderFoto { get; set; }

        [Display(Name = "Baslik")]
        [StringLength(300)]
        public string SliderText { get; set; }

        [Display(Name = "Alt Başlık")]
        [StringLength(400)]
        public string SliderSubText { get; set; }

        [Display(Name = "Tarih")]
        [Required]
        public DateTime OlusturmaTarihi { get; set; }
    }
}