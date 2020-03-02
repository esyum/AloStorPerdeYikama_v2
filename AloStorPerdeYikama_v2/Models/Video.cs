using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Models
{
    [Table("Video")]
    public partial class Video
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50),DisplayName("Dosya Adı")]
        public string Name { get; set; }

        [StringLength(200),DisplayName("Dosya Turu")]
        public string ContentType { get; set; }

        [StringLength(250),DisplayName("Video Data")]
        public string Data { get; set; }
        //public byte[] Data { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; }
    }
}