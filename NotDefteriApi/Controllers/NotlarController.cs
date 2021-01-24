using Microsoft.AspNet.Identity;
using NotDefteriApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NotDefteriApi.Controllers
{
    [Authorize]
    public class NotlarController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Notlar
        [HttpGet]
        public List<Not> Listele()
        {
            var userId = User.Identity.GetUserId();
            return db.Notlar.Where(x => x.KullaniciId == userId).OrderBy(x => x.Tarih).ToList();
        }

        [HttpPost]
        public IHttpActionResult Ekle(NotEkleDto dto)
        {
            if (ModelState.IsValid)
            {
                Not not = new Not()
                {
                    KullaniciId = User.Identity.GetUserId(),
                    Baslik = dto.Baslik,
                    Icerik = dto.Icerik,
                    Tarih = DateTime.Now
                };
                db.Notlar.Add(not);
                db.SaveChanges();
                return Ok(not);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IHttpActionResult Duzenle(NotDuzenleDto dto)
        {
            if (ModelState.IsValid)
            {
                var not = db.Notlar.FirstOrDefault(x => x.Id == dto.Id);
                if (not != null && not.KullaniciId == User.Identity.GetUserId())
                {
                    not.Baslik = dto.Baslik;
                    not.Icerik = dto.Icerik;
                    not.Tarih = DateTime.Now;
                    db.SaveChanges();
                    return Ok(not);
                }
                return BadRequest();

            }
            return BadRequest(ModelState);
        }

        //[HttpGet]
        //public IHttpActionResult Sil(int? id)
        //{
        //    var not = db.Notlar.FirstOrDefault(x => x.Id == id);
        //    if (not != null && not.KullaniciId == User.Identity.GetUserId())
        //    {
        //        db.Notlar.Remove(not);
        //        db.SaveChanges();
        //        return Ok();
        //    }
        //    return BadRequest();
        //}

        [HttpDelete]
        public IHttpActionResult Sil(int? id)
        {
            var not = db.Notlar.FirstOrDefault(x => x.Id == id);
            if (not != null && not.KullaniciId == User.Identity.GetUserId())
            {
                db.Notlar.Remove(not);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }

    }
}
