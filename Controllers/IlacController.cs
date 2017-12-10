using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ilac_etkilesimleri;
using ilac_etkilesimleri.Data;
using ilac_etkilesimleri.Models;
using System.Text;

namespace ilac_etkilesimleri.Controllers
{
    public class IlacController : Controller
    {
        private TingoonDbContext db = new TingoonDbContext();
        // GET: Ilac
        public async Task<ActionResult> Index()
        {
            return View(await db.Ilac.Select(x => new IlacIndexViewModels { Id = x.Id, Ad = x.Ad, AnalizYapildiMi = x.AnalizYapildiMi }).ToListAsync());
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
            var vm = new IlacViewModels
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                YanEtkiler = m.YanEtkiler,
                NasilKullanilir = m.NasilKullanilir,
                DikkatEdilecekler = m.DikkatEdilecekler,
                EtkenMaddelerId = m.EtkenMaddeler == null ? null : m.EtkenMaddeler.Split('-')
            };
            if (vm.EtkenMaddelerId != null)
            {
                List<int> EtkilesenEtkenMaddelerId = new List<int>();
                foreach (var item in vm.EtkenMaddelerId)
                {
                    EtkilesenEtkenMaddelerId.Add(Convert.ToInt32(item));
                }
                vm.EtkenMaddelerText = m.EtkenMaddeler == null ? null : db.EtkenMadde.Where(x => EtkilesenEtkenMaddelerId.Contains(x.Id)).Select(x => x.Ad).ToList();
            }
            return View(vm);
        }

        // GET: Ilac/Create
        public ActionResult Create()
        {
            var vm = new IlacViewModels
            {
                EtkenMaddeler = db.EtkenMadde.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Ad }).ToList()
            };
            return View(vm);
        }

        // POST: Ilac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Ad,Aciklama,YanEtkiler,NasilKullanilir,DikkatEdilecekler,EtkenMaddelerId")] IlacViewModels vm)
        {
            if (ModelState.IsValid)
            {
                var m = new Ilac
                {
                    Ad = vm.Ad,
                    Aciklama = vm.Aciklama,
                    YanEtkiler = vm.YanEtkiler,
                    NasilKullanilir = vm.NasilKullanilir,
                    DikkatEdilecekler = vm.DikkatEdilecekler,
                    EtkenMaddeler = vm.EtkenMaddelerId == null ? null : string.Join("-", vm.EtkenMaddelerId)
                };
                db.Ilac.Add(m);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Ilac/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            var vm = new IlacViewModels
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                YanEtkiler = m.YanEtkiler,
                NasilKullanilir = m.NasilKullanilir,
                DikkatEdilecekler = m.DikkatEdilecekler,
                EtkenMaddelerId = m.EtkenMaddeler == null ? null : m.EtkenMaddeler.Split('-'),
                EtkenMaddeler = db.EtkenMadde.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Ad }).ToList()
            };
            return View(vm);
        }

        // POST: Ilac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ad,Aciklama,YanEtkiler,NasilKullanilir,DikkatEdilecekler,EtkenMaddelerId")] IlacViewModels vm)
        {
            if (ModelState.IsValid)
            {
                var m = new Ilac
                {
                    Id = vm.Id,
                    Ad = vm.Ad,
                    Aciklama = vm.Aciklama,
                    YanEtkiler = vm.YanEtkiler,
                    NasilKullanilir = vm.NasilKullanilir,
                    DikkatEdilecekler = vm.DikkatEdilecekler,
                    EtkenMaddeler = vm.EtkenMaddelerId == null ? null : string.Join("-", vm.EtkenMaddelerId)
                };
                db.Entry(m).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Ilac/Delete/5
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
            var vm = new IlacViewModels
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                YanEtkiler = m.YanEtkiler,
                NasilKullanilir = m.NasilKullanilir,
                DikkatEdilecekler = m.DikkatEdilecekler,
                EtkenMaddelerId = m.EtkenMaddeler == null ? null : m.EtkenMaddeler.Split('-')
            };
            if (vm.EtkenMaddelerId != null)
            {
                List<int> EtkilesenEtkenMaddelerId = new List<int>();
                foreach (var item in vm.EtkenMaddelerId)
                {
                    EtkilesenEtkenMaddelerId.Add(Convert.ToInt32(item));
                }
                vm.EtkenMaddelerText = m.EtkenMaddeler == null ? null : db.EtkenMadde.Where(x => EtkilesenEtkenMaddelerId.Contains(x.Id)).Select(x => x.Ad).ToList();
            }
            return View(vm);
        }

        // POST: Ilac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ilac ilac = await db.Ilac.FindAsync(id);
            db.Ilac.Remove(ilac);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
