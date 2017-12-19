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

namespace ilac_etkilesimleri.Controllers
{
    [Authorize]
    public class EtkenMaddeController : Controller
    {
        private TingoonDbContext db = new TingoonDbContext();

        // GET: EtkenMadde
        public async Task<ActionResult> Index()
        {
            return View(await db.EtkenMadde.Select(x => new EtkenMaddeListViewModel { Id = x.Id, Ad = x.Ad }).ToListAsync());
        }

        // GET: EtkenMadde/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkenMadde m = await db.EtkenMadde.FindAsync(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            var vm = new EtkenMaddeViewModel
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama
            };
            var temp = await db.EtkenMaddeEtkilesim.Where(x => x.EtkenMaddeId1 == id || x.EtkenMaddeId2 == id).ToListAsync();
            if (temp != null)
            {
                foreach (var item in temp)
                {
                    if (item.EtkenMaddeId1 == id)
                        vm.EtkilesenEtkenMaddeler.Add(item.EtkenMadde2);
                    else if (item.EtkenMaddeId2 == id)
                        vm.EtkilesenEtkenMaddeler.Add(item.EtkenMadde1);
                }
            }
            return View(vm);
        }

        // GET: EtkenMadde/Create
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Ad,Aciklama,EtkilesenEtkenMaddelerId")] EtkenMaddeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EtkenMaddeListe = await db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }).ToListAsync();
                return View(vm);
            }
            if (db.EtkenMadde.Where(x => x.Ad == vm.Ad.ToLower()).Count() > 0)
            {
                ModelState.AddModelError("Ad", "Bu isimde bir etken madde zaten var.");
                ViewBag.EtkenMaddeListe = await db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }).ToListAsync();
                return View(vm);
            }
            var m = new EtkenMadde
            {
                Ad = vm.Ad.ToLower(),
                Aciklama = vm.Aciklama,
            };
            db.EtkenMadde.Add(m);
            await db.SaveChangesAsync();
            if (vm.EtkilesenEtkenMaddelerId != null && vm.EtkilesenEtkenMaddelerId.Count() > 0)
            {
                foreach (var item in vm.EtkilesenEtkenMaddelerId)
                    db.EtkenMaddeEtkilesim.Add(new EtkenMaddeEtkilesim { EtkenMaddeId1 = m.Id, EtkenMaddeId2 = item });
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // GET: EtkenMadde/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkenMadde m = await db.EtkenMadde.FindAsync(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            var vm = new EtkenMaddeViewModel
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama
            };
            var temp = await db.EtkenMaddeEtkilesim.Where(x => x.EtkenMaddeId1 == id || x.EtkenMaddeId2 == id).ToListAsync();
            if (temp != null)
            {
                foreach (var item in temp)
                {
                    if (item.EtkenMaddeId1 == id)
                        vm.EtkilesenEtkenMaddeler.Add(item.EtkenMadde2);
                    else if (item.EtkenMaddeId2 == id)
                        vm.EtkilesenEtkenMaddeler.Add(item.EtkenMadde1);
                }
            }
            foreach (var item in temp)
            {
                if (item.EtkenMaddeId1 == vm.Id)
                    vm.EtkilesenEtkenMaddelerId.Add(item.EtkenMaddeId2);
                else if (item.EtkenMaddeId2 == vm.Id)
                    vm.EtkilesenEtkenMaddelerId.Add(item.EtkenMaddeId1);
            }
            IEnumerable<SelectListItem> items = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkilesenEtkenMaddelerId);
            ViewBag.EtkenMaddeListe = items;
            //ViewBag.EtkenMaddeListe = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkilesenEtkenMaddelerId);


            return View(vm);
        }

        // POST: EtkenMadde/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ad,Aciklama,EtkilesenEtkenMaddelerId")] EtkenMaddeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EtkenMaddeListe = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkilesenEtkenMaddelerId);
                return View(vm);
            }
            EtkenMadde m = await db.EtkenMadde.FindAsync(vm.Id);
            if (m == null)
            {
                return HttpNotFound();
            }
            if (db.EtkenMadde.Where(x => x.Ad == vm.Ad.ToLower() && x.Id != vm.Id).Count() > 0)
            {
                ModelState.AddModelError("Ad", "Bu isimde bir etken madde zaten var.");
                ViewBag.EtkenMaddeListe = new MultiSelectList(db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }), "Value", "Text", vm.EtkilesenEtkenMaddelerId);
                return View(vm);
            }
            m.Ad = vm.Ad;
            m.Aciklama = vm.Aciklama;
            var eskiEtkilesenEtkenMaddeler = await db.EtkenMaddeEtkilesim.Where(x => x.EtkenMaddeId1 == m.Id || x.EtkenMaddeId2 == m.Id).ToListAsync();

            if (eskiEtkilesenEtkenMaddeler == null || eskiEtkilesenEtkenMaddeler.Count == 0)
            {
                foreach (var item in vm.EtkilesenEtkenMaddelerId)
                    db.EtkenMaddeEtkilesim.Add(new EtkenMaddeEtkilesim { EtkenMaddeId1 = m.Id, EtkenMaddeId2 = item });
            }
            else
            {
                if (vm.EtkilesenEtkenMaddelerId == null || vm.EtkilesenEtkenMaddelerId.Count() == 0)
                {
                    db.EtkenMaddeEtkilesim.RemoveRange(eskiEtkilesenEtkenMaddeler);
                }
                else
                {
                    List<int> eskiEtkilesenEtkenMaddelerId = new List<int>();
                    foreach (var item in eskiEtkilesenEtkenMaddeler)
                    {
                        if (item.EtkenMaddeId1 == vm.Id)
                            eskiEtkilesenEtkenMaddelerId.Add(item.EtkenMaddeId2);
                        else if (item.EtkenMaddeId2 == vm.Id)
                            eskiEtkilesenEtkenMaddelerId.Add(item.EtkenMaddeId1);
                    }

                    var yeniEtkilesenEtkenMaddeFark = vm.EtkilesenEtkenMaddelerId.Except(eskiEtkilesenEtkenMaddelerId);
                    if (yeniEtkilesenEtkenMaddeFark != null && yeniEtkilesenEtkenMaddeFark.Count()>0)
                    {
                        foreach (var item in yeniEtkilesenEtkenMaddeFark)
                            db.EtkenMaddeEtkilesim.Add(new EtkenMaddeEtkilesim { EtkenMaddeId1 = m.Id, EtkenMaddeId2 = item });
                    }
                    var eskiEtkilesenEtkenMaddeFark = eskiEtkilesenEtkenMaddelerId.Except(vm.EtkilesenEtkenMaddelerId);
                    if (eskiEtkilesenEtkenMaddeFark != null && eskiEtkilesenEtkenMaddeFark.Count() > 0)
                    {
                        db.EtkenMaddeEtkilesim.RemoveRange(eskiEtkilesenEtkenMaddeler.Where(x => eskiEtkilesenEtkenMaddeFark.Contains(x.EtkenMaddeId1) || eskiEtkilesenEtkenMaddeFark.Contains(x.EtkenMaddeId2)));
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
            EtkenMadde m = await db.EtkenMadde.FindAsync(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            var vm = new EtkenMaddeViewModel
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama
            };
            var temp = await db.EtkenMaddeEtkilesim.Where(x => x.EtkenMaddeId1 == id || x.EtkenMaddeId2 == id).ToListAsync();
            if (temp != null)
            {
                foreach (var item in temp)
                {
                    if (item.EtkenMaddeId1 == id)
                        vm.EtkilesenEtkenMaddeler.Add(item.EtkenMadde2);
                    else if (item.EtkenMaddeId2 == id)
                        vm.EtkilesenEtkenMaddeler.Add(item.EtkenMadde1);
                }
            }
            return View(vm);
        }

        // POST: EtkenMadde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EtkenMadde etkenMadde = await db.EtkenMadde.FindAsync(id);
            db.EtkenMaddeEtkilesim.RemoveRange(db.EtkenMaddeEtkilesim.Where(x => x.EtkenMaddeId1 == id || x.EtkenMaddeId2 == id));
            db.EtkenMadde.Remove(etkenMadde);
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
