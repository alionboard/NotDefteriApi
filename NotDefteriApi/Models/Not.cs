using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriApi.Models
{
    [Table("Notlar")]
    public class Not
    {
        public int Id { get; set; }
        [ForeignKey("Kullanici")]
        public string KullaniciId { get; set; }
        [Required, MaxLength(50)]
        public string Baslik { get; set; }
        [Required, MaxLength(5000)]
        public string Icerik { get; set; }
        public DateTime? Tarih { get; set; }
        public ApplicationUser Kullanici { get; set; }
    }
}