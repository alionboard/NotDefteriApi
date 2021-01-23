using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotDefteriApi.Models
{
    public class NotEkleDto
    {
        [Required, MaxLength(50)]
        public string Baslik { get; set; }
        [Required, MaxLength(5000)]
        public string Icerik { get; set; }
    }
}