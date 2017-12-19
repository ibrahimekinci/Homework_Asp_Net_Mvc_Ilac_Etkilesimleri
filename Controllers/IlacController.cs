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
    public class IlacController : Controller
    {
        private TingoonDbContext db = new TingoonDbContext();

        // GET: EtkenMadde
        public async Task<ActionResult> Index()
        {
            return View(await db.Ilac.Select(x => new IlacListViewModel { Id = x.Id, Ad = x.Ad }).ToListAsync());
        }

        // GET: Ilac/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilac m = await db.Ilac.FindAsync(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            var vm = new IlacViewModel
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                YanEtkiler = m.YanEtkiler,
                NasilKullanilir = m.NasilKullanilir,
                DikkatEdilecekler = m.DikkatEdilecekler,
                EtkenMaddeler = await db.IlacEtkenMadde.Where(x => x.IlacId == m.Id).Select(x => x.EtkenMadde).ToListAsync()
            };
            return View(vm);
        }

        public async Task<ActionResult> Create(int? id)
        {
            ViewBag.EtkenMaddeListe = await db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }).ToListAsync();
            return View();
        }

        // POST: EtkenMadde/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Ad,Aciklama,YanEtkiler,NasilKullanilir,DikkatEdilecekler,EtkenMaddelerId")] IlacViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EtkenMaddeListe = await db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }).ToListAsync();
                return View(vm);
            }
            if (db.Ilac.Where(x => x.Ad == vm.Ad.ToLower()).Count() > 0)
            {
                ModelState.AddModelError("Ad", "Bu isimde bir ilac zaten var.");
                ViewBag.EtkenMaddeListe = await db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }).ToListAsync();
                return View(vm);
            }
            var m = new Ilac
            {
                Id = vm.Id,
                Ad = vm.Ad,
                Aciklama = vm.Aciklama,
                YanEtkiler = vm.YanEtkiler,
                NasilKullanilir = vm.NasilKullanilir,
                DikkatEdilecekler = vm.DikkatEdilecekler,
                AnalizYapildiMi = false
            };
            db.Ilac.Add(m);
            await db.SaveChangesAsync();
            if (vm.EtkenMaddelerId != null && vm.EtkenMaddelerId.Count > 0)
            {
                foreach (var item in vm.EtkenMaddelerId)
                    db.IlacEtkenMadde.Add(new IlacEtkenMadde { EtkenMaddeId = item, IlacId = m.Id });
                await db.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var m = await db.Ilac.FindAsync(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            var vm = new IlacViewModel
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                YanEtkiler = m.YanEtkiler,
                NasilKullanilir = m.NasilKullanilir,
                DikkatEdilecekler = m.DikkatEdilecekler,
                EtkenMaddeler = await db.IlacEtkenMadde.Where(x => x.IlacId == m.Id).Select(x => x.EtkenMadde).ToListAsync()
            };
            IEnumerable<SelectListItem> items = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkenMaddeler);
            ViewBag.EtkenMaddeListe = items;
            //ViewBag.EtkenMaddeListe = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkilesenEtkenMaddelerId);
            return View(vm);
        }

        // POST: EtkenMadde/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ad,Aciklama,YanEtkiler,NasilKullanilir,DikkatEdilecekler,EtkenMaddelerId")] IlacViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.EtkenMaddeListe = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkenMaddelerId);
                return View(vm);
            }
            Ilac m = await db.Ilac.FindAsync(vm.Id);
            if (m == null)
            {
                return HttpNotFound();
            }
            if (db.Ilac.Where(x => x.Ad == vm.Ad.ToLower() && x.Id != vm.Id).Count() > 0)
            {
                ModelState.AddModelError("Ad", "Bu isimde bir ilac zaten var.");
                ViewBag.EtkenMaddeListe = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkenMaddelerId);
                return View(vm);
            }
            m.Ad = vm.Ad;
            m.Aciklama = vm.Aciklama;
            m.YanEtkiler = vm.YanEtkiler;
            m.NasilKullanilir = vm.NasilKullanilir;
            m.DikkatEdilecekler = vm.DikkatEdilecekler;
            m.IlacEtkenMadde = await db.IlacEtkenMadde.Where(x => x.IlacId == m.Id).ToListAsync();
            var eskiEtkenMaddelerId = m.IlacEtkenMadde.Select(x => x.EtkenMadde.Id).ToList();
            if (eskiEtkenMaddelerId == null || eskiEtkenMaddelerId.Count() == 0)
            {
                foreach (var item in vm.EtkenMaddelerId)
                    db.IlacEtkenMadde.Add(new IlacEtkenMadde { IlacId = m.Id, EtkenMaddeId = item });
            }
            else
            {
                if (vm.EtkenMaddelerId == null || vm.EtkenMaddelerId.Count() == 0)
                {
                    db.IlacEtkenMadde.RemoveRange(m.IlacEtkenMadde);
                }
                else
                {
                    var yeniEtkenMaddeFarkId = vm.EtkenMaddelerId.Except(eskiEtkenMaddelerId);
                    if (yeniEtkenMaddeFarkId != null && yeniEtkenMaddeFarkId.Count() > 0)
                    {
                        foreach (var item in yeniEtkenMaddeFarkId)
                            db.IlacEtkenMadde.Add(new IlacEtkenMadde { IlacId = m.Id, EtkenMaddeId = item });
                    }
                    var eskiEtkenMaddeFarkId = eskiEtkenMaddelerId.Except(vm.EtkenMaddelerId);
                    if (eskiEtkenMaddeFarkId != null && eskiEtkenMaddeFarkId.Count() > 0)
                    {
                        db.IlacEtkenMadde.RemoveRange(m.IlacEtkenMadde.Where(x => eskiEtkenMaddeFarkId.Contains(x.EtkenMaddeId)));
                    }
                }
            }
            db.Entry(m).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: EtkenMadde/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilac m = await db.Ilac.FindAsync(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            var vm = new IlacViewModel
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                YanEtkiler = m.YanEtkiler,
                NasilKullanilir = m.NasilKullanilir,
                DikkatEdilecekler = m.DikkatEdilecekler,
                EtkenMaddeler = await db.IlacEtkenMadde.Where(x => x.IlacId == m.Id).Select(x => x.EtkenMadde).ToListAsync()
            };
            return View(vm);
        }

        // POST: EtkenMadde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ilac m = await db.Ilac.FindAsync(id);
            db.Ilac.Remove(m);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
