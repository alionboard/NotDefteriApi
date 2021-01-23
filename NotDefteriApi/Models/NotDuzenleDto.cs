using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotDefteriApi.Models
{
    public class NotDuzenleDto
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Baslik { get; set; }
        [Required, MaxLength(1000)]
        public string Icerik { get; set; }
    }
}