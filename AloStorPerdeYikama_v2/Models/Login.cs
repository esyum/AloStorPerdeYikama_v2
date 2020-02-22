using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AloStorPerdeYikama_v2.Models
{
    [Table("Login")]
    public class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Kullanıcı adı"),Required(ErrorMessage ="{0} alanı boş geçilemez.")]
        public string Username { get; set; }

        [DisplayName("Şifre"),Required(ErrorMessage ="{0} alanı boş geçilemez"),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}