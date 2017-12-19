using ilac_etkilesimleri.Data;
using ilac_etkilesimleri.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ilac_etkilesimleri.Controllers
{
    [Authorize]
    public class IlacEtkilesimController : Controller
    {
        private TingoonDbContext db = new TingoonDbContext();
        // GET: EtkenMadde
        public async Task<ActionResult> Index()
        {
            return View(await db.Ilac.Select(x => new IlacEtkilesimIndexViewModel { Id = x.Id, Ad = x.Ad, AnalizYapildiMi = x.AnalizYapildiMi }).ToListAsync());
        }

        // GET: IlacEtkilesim/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilac im = await db.Ilac.FindAsync(id);
            if (im == null)
            {
                return HttpNotFound();
            }
            var mList = await db.IlacEtkilesim.Where(x => x.IlacId1 == id || x.IlacId2 == id).ToListAsync();
            //if (mList == null || mList.Count == 0)
            //{
            //    return HttpNotFound();
            //}
            //İlşaç biligileri dolduruluyor
            var ivm = new IlacViewModel
            {
                Id = im.Id,
                Ad = im.Ad,
                Aciklama = im.Aciklama,
                YanEtkiler = im.YanEtkiler,
                NasilKullanilir = im.NasilKullanilir,
                DikkatEdilecekler = im.DikkatEdilecekler,
                EtkenMaddeler = await db.IlacEtkenMadde.Where(x => x.IlacId == im.Id).Select(x => x.EtkenMadde).ToListAsync()
            };
            var vm = new IlacEtkilesimViewModel();
            vm.Ilac = ivm;
            if (mList != null)
            {
                Ilac it = new Ilac();
                IlacViewModel ivmt;
                foreach (var item in mList)
                {
                    if (item.IlacId1 == id)
                        it = item.Ilac2;
                    else if (item.IlacId2 == id)
                        it = item.Ilac1;
                    ivmt = new IlacViewModel
                    {
                        Id = it.Id,
                        Ad = it.Ad,
                        Aciklama = it.Aciklama,
                        YanEtkiler = it.YanEtkiler,
                        NasilKullanilir = it.NasilKullanilir,
                        DikkatEdilecekler = it.DikkatEdilecekler,
                        EtkenMaddeler = await db.IlacEtkenMadde.Where(x => x.IlacId == it.Id).Select(x => x.EtkenMadde).ToListAsync()
                    };
                    vm.EtkilesilenIlaclar.Add(ivmt);
                }
            }

            return View(vm);
        }

        // GET: IlacEtkilesim/Create
        public async Task<ActionResult> AnalizYap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilac im = await db.Ilac.FindAsync(id);
            if (im == null)
            {
                return HttpNotFound();
            }

            var ivm = new IlacViewModel
            {
                Id = im.Id,
                Ad = im.Ad,
                Aciklama = im.Aciklama,
                YanEtkiler = im.YanEtkiler,
                NasilKullanilir = im.NasilKullanilir,
                DikkatEdilecekler = im.DikkatEdilecekler,
                EtkenMaddeler = await db.IlacEtkenMadde.Where(x => x.IlacId == im.Id).Select(x => x.EtkenMadde).ToListAsync()
            };
            var vm = new IlacEtkilesimViewModel();
            vm.Ilac = ivm;
            vm.Ilac.EtkenMaddelerId = vm.Ilac.EtkenMaddeler.Select(x => x.Id).ToList();

            List<EtkenMaddeEtkilesim> EtkenMaddeEtkilesim = await db.EtkenMaddeEtkilesim.Where(x => vm.Ilac.EtkenMaddelerId.Contains(x.EtkenMaddeId1) || vm.Ilac.EtkenMaddelerId.Contains(x.EtkenMaddeId2)).ToListAsync();
            List<int> EtkilesenEtkenMaddeId = new List<int>();
            if (EtkenMaddeEtkilesim != null)
            {
                foreach (var item in EtkenMaddeEtkilesim)
                {
                    if (item.EtkenMaddeId1 == id)
                        EtkilesenEtkenMaddeId.Add(item.EtkenMaddeId2);
                    else if (item.EtkenMaddeId2 == id)
                        EtkilesenEtkenMaddeId.Add(item.EtkenMaddeId1);
                }

            }
            EtkilesenEtkenMaddeId = EtkilesenEtkenMaddeId.Distinct().ToList();
            List<Ilac> mList = await db.IlacEtkenMadde.Where(x => EtkilesenEtkenMaddeId.Contains(x.EtkenMaddeId)).Select(x => x.Ilac).ToListAsync();
            foreach (var item in mList)
            {
                ivm = new IlacViewModel
                {
                    Id = item.Id,
                    Ad = item.Ad,
                    Aciklama = item.Aciklama,
                    YanEtkiler = item.YanEtkiler,
                    NasilKullanilir = item.NasilKullanilir,
                    DikkatEdilecekler = item.DikkatEdilecekler,
                    EtkenMaddeler = await db.IlacEtkenMadde.Where(x => x.IlacId == item.Id).Select(x => x.EtkenMadde).ToListAsync()
                };
                vm.EtkilesilenIlaclar.Add(ivm);
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AnalizYap(int id)
        {

            Ilac im = await db.Ilac.FindAsync(id);
            if (im == null)
            {
                return HttpNotFound();
            }
            var CheckYeniEtkilesenIlaclarId = Request.Form.GetValues("CheckBoxEtkilesilenler");
            List<int> yeniEtkilesenIlaclarId = new List<int>();
            if (CheckYeniEtkilesenIlaclarId != null)
            {
                foreach (var item in CheckYeniEtkilesenIlaclarId)
                    yeniEtkilesenIlaclarId.Add(Convert.ToInt32(item));
            }

            var eskiEtkilesenIlaclar = await db.IlacEtkilesim.Where(x => x.IlacId1 == id || x.IlacId2 == id).ToListAsync();

            if (eskiEtkilesenIlaclar == null || eskiEtkilesenIlaclar.Count == 0)
            {
                foreach (var item in yeniEtkilesenIlaclarId)
                    db.IlacEtkilesim.Add(new IlacEtkilesim { IlacId1 = id, IlacId2 = item });
            }
            else
            {
                if (yeniEtkilesenIlaclarId == null || yeniEtkilesenIlaclarId.Count() == 0)
                {
                    db.IlacEtkilesim.RemoveRange(eskiEtkilesenIlaclar);
                }
                else
                {
                    List<int> eskiEtkilesenIlaclarId = new List<int>();
                    foreach (var item in eskiEtkilesenIlaclar)
                    {
                        if (item.IlacId1 == id)
                            eskiEtkilesenIlaclarId.Add(item.IlacId2);
                        else if (item.IlacId2 == id)
                            eskiEtkilesenIlaclarId.Add(item.IlacId1);
                    }
                    var yeniIlaclarFark = yeniEtkilesenIlaclarId.Except(eskiEtkilesenIlaclarId);
                    if (yeniIlaclarFark != null && yeniIlaclarFark.Count() > 0)
                    {
                        foreach (var item in yeniIlaclarFark)
                            db.IlacEtkilesim.Add(new IlacEtkilesim { IlacId1 = id, IlacId2 = item });
                    }
                    var eskiIlaclarFark = eskiEtkilesenIlaclarId.Except(yeniEtkilesenIlaclarId);
                    if (eskiIlaclarFark != null && eskiIlaclarFark.Count() > 0)
                    {
                        db.IlacEtkilesim.RemoveRange(eskiEtkilesenIlaclar.Where(x => eskiIlaclarFark.Contains(x.IlacId1) || eskiIlaclarFark.Contains(x.IlacId2)));
                    }
                }
            }
            im.AnalizYapildiMi = true;
            db.Entry(im).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: IlacEtkilesim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IlacEtkilesim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IlacEtkilesim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IlacEtkilesim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
