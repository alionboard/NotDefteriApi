namespace NotDefteriApi.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NotDefteriApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NotDefteriApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NotDefteriApi.Models.ApplicationDbContext";
        }

        protected override void Seed(NotDefteriApi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var kullaniciEmail = "ornek@gmail.com";

            if (!context.Users.Any(x => x.UserName == kullaniciEmail))
            {
                #region Örnek Kullanıcıyı Oluştur
                var kullanici = new ApplicationUser()
                {
                    UserName = kullaniciEmail,
                    Email = kullaniciEmail,
                    EmailConfirmed = true
                };
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);
                userManager.Create(kullanici, "Ankara1.");
                #endregion

                #region Oluşan Kullanıcıyla İlişkili Borç Kaydı Gir
                context.Notlar.AddRange(new List<Not>()
                {
                    new Not()
                    {
                        KullaniciId = kullanici.Id,
                        Baslik="Ornek Baslik",
                        Icerik="Ornek Iceerik",
                        Tarih=DateTime.Now
                    },
                    new Not()
                    {
                       KullaniciId = kullanici.Id,
                        Baslik="Ornek Baslik2",
                        Icerik="Ornek Iceerik2",
                        Tarih=DateTime.Now.AddDays(1)
                    }
                });
                #endregion
            }
        }
    }
}
