using System.Data.Entity.Migrations;
using System.Linq;
using ilac_etkilesimleri;
using ilac_etkilesimleri.Data;
using ilac_etkilesimleri.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ilac_etkilesimleri.DAL
{
    public class AppSeed
    {
        private readonly TingoonDbContext _db;
        public AppSeed(TingoonDbContext db)
        {
            this._db = db;
            //veriler bir kere eklendikten sonra eklenmiyor
            if (db.Users.Any()) return;
            UserSeed();
            BasicSeed();
        }

        private static void UserSeed()
        {
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new TingoonDbContext()));
            var user = new ApplicationUser()
            {
                UserName = "ibrahimekinci36@gmail.com",
                Email = "ibrahimekinci36@gmail.com",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                AccessFailedCount = 0,
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            manager.Create(user, ".Standart1");
        }
        private void BasicSeed()
        {
            _db.EtkenMadde.AddOrUpdate(
                new EtkenMadde { Ad = "e1", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e2", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e3", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e4", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e5", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e6", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e7", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e8", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e9", Aciklama = "eAçıklama" },
                new EtkenMadde { Ad = "e10", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e11", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e12", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e13", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e14", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e15", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e16", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e17", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e18", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e19", Aciklama = " Açıklama" },
                new EtkenMadde { Ad = "e20", Aciklama = " Açıklama" }
                );

            _db.Ilac.AddOrUpdate(
                new Ilac { Ad = "i1", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i2", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i3", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i4", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i5", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i6", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i7", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i8", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i9", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i10", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i11", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i12", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i13", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i14", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i15", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i16", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i17", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i18", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i19", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false },
                new Ilac { Ad = "i20", Aciklama = "Açıklama", DikkatEdilecekler = "Dikkat edilecekler", NasilKullanilir = "Nasıl Kullanılır", YanEtkiler = "Yan Etkiler", AnalizYapildiMi = false }
                );
            _db.SaveChanges();

            _db.IlacEtkenMadde.AddOrUpdate(
                new IlacEtkenMadde { IlacId = 1, EtkenMaddeId = 1 },
                new IlacEtkenMadde { IlacId = 2, EtkenMaddeId = 2 },
                new IlacEtkenMadde { IlacId = 3, EtkenMaddeId = 3 },
                new IlacEtkenMadde { IlacId = 4, EtkenMaddeId = 4 },
                new IlacEtkenMadde { IlacId = 5, EtkenMaddeId = 5 },
                new IlacEtkenMadde { IlacId = 6, EtkenMaddeId = 6 },
                new IlacEtkenMadde { IlacId = 7, EtkenMaddeId = 7 },
                new IlacEtkenMadde { IlacId = 8, EtkenMaddeId = 8 },
                new IlacEtkenMadde { IlacId = 9, EtkenMaddeId = 9 },
                new IlacEtkenMadde { IlacId = 10, EtkenMaddeId = 10 },
                new IlacEtkenMadde { IlacId = 11, EtkenMaddeId = 11 },
                new IlacEtkenMadde { IlacId = 12, EtkenMaddeId = 12 },
                new IlacEtkenMadde { IlacId = 13, EtkenMaddeId = 13 },
                new IlacEtkenMadde { IlacId = 14, EtkenMaddeId = 14 },
                new IlacEtkenMadde { IlacId = 15, EtkenMaddeId = 15 },
                new IlacEtkenMadde { IlacId = 16, EtkenMaddeId = 16 },
                new IlacEtkenMadde { IlacId = 17, EtkenMaddeId = 17 },
                new IlacEtkenMadde { IlacId = 18, EtkenMaddeId = 18 },
                new IlacEtkenMadde { IlacId = 19, EtkenMaddeId = 19 },
                new IlacEtkenMadde { IlacId = 20, EtkenMaddeId = 20 },
                new IlacEtkenMadde { IlacId = 1, EtkenMaddeId = 2 },
                new IlacEtkenMadde { IlacId = 2, EtkenMaddeId = 4 },
                new IlacEtkenMadde { IlacId = 3, EtkenMaddeId = 6 },
                new IlacEtkenMadde { IlacId = 4, EtkenMaddeId = 8 },
                new IlacEtkenMadde { IlacId = 5, EtkenMaddeId = 10 },
                new IlacEtkenMadde { IlacId = 6, EtkenMaddeId = 12 },
                new IlacEtkenMadde { IlacId = 7, EtkenMaddeId = 14 },
                new IlacEtkenMadde { IlacId = 8, EtkenMaddeId = 16 },
                new IlacEtkenMadde { IlacId = 9, EtkenMaddeId = 18 },
                new IlacEtkenMadde { IlacId = 10, EtkenMaddeId = 1 },
                new IlacEtkenMadde { IlacId = 11, EtkenMaddeId = 2 },
                new IlacEtkenMadde { IlacId = 12, EtkenMaddeId = 3 },
                new IlacEtkenMadde { IlacId = 13, EtkenMaddeId = 4 },
                new IlacEtkenMadde { IlacId = 14, EtkenMaddeId = 5 },
                new IlacEtkenMadde { IlacId = 15, EtkenMaddeId = 6 },
                new IlacEtkenMadde { IlacId = 16, EtkenMaddeId = 7 },
                new IlacEtkenMadde { IlacId = 17, EtkenMaddeId = 8 },
                new IlacEtkenMadde { IlacId = 18, EtkenMaddeId = 9 }
                );



            _db.EtkenMaddeEtkilesim.AddOrUpdate(
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 1, EtkenMaddeId2 = 2, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 2, EtkenMaddeId2 = 4, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 3, EtkenMaddeId2 = 6, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 4, EtkenMaddeId2 = 8, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 5, EtkenMaddeId2 = 10, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 6, EtkenMaddeId2 = 12, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 7, EtkenMaddeId2 = 14, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 8, EtkenMaddeId2 = 16, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 9, EtkenMaddeId2 = 18, Aciklama = "Açıklama" },

                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 1, EtkenMaddeId2 = 3, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 2, EtkenMaddeId2 = 6, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 3, EtkenMaddeId2 = 9, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 4, EtkenMaddeId2 = 12, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 5, EtkenMaddeId2 = 15, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 6, EtkenMaddeId2 = 18, Aciklama = "Açıklama" },

                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 1, EtkenMaddeId2 = 4, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 2, EtkenMaddeId2 = 8, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 3, EtkenMaddeId2 = 9, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 4, EtkenMaddeId2 = 12, Aciklama = "Açıklama" },
                new EtkenMaddeEtkilesim { EtkenMaddeId1 = 5, EtkenMaddeId2 = 19, Aciklama = "Açıklama" }
                );

            _db.IlacEtkilesim.AddOrUpdate(
                 new IlacEtkilesim { IlacId1 = 1, IlacId2 = 2, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 2, IlacId2 = 4, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 3, IlacId2 = 6, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 4, IlacId2 = 8, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 5, IlacId2 = 10, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 6, IlacId2 = 12, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 7, IlacId2 = 14, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 8, IlacId2 = 16, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 9, IlacId2 = 18, Aciklama = "Açıklama" },

                 new IlacEtkilesim { IlacId1 = 1, IlacId2 = 3, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 2, IlacId2 = 6, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 3, IlacId2 = 9, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 4, IlacId2 = 12, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 5, IlacId2 = 15, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 6, IlacId2 = 18, Aciklama = "Açıklama" },

                 new IlacEtkilesim { IlacId1 = 1, IlacId2 = 4, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 2, IlacId2 = 8, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 3, IlacId2 = 9, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 4, IlacId2 = 12, Aciklama = "Açıklama" },
                 new IlacEtkilesim { IlacId1 = 5, IlacId2 = 19, Aciklama = "Açıklama" }
                 );
            _db.SaveChanges();
        }
    }
}
