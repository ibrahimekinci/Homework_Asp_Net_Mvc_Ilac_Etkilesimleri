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
    public class EtkenMaddeController : Controller
    {
        private TingoonDbContext db = new TingoonDbContext();

        // GET: EtkenMadde
        public async Task<ActionResult> Index()
        {
            return View(await db.EtkenMadde.Select(x => new IndexListViewModels { Id = x.Id, Ad = x.Ad }).ToListAsync());
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
            var vm = new EtkenMaddeViewModels
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                EtkilesenEtkenMaddelerId = m.EtkilesenEtkenMaddeler == null ? null : m.EtkilesenEtkenMaddeler.Split('-')
            };
            
            if (vm.EtkilesenEtkenMaddelerId != null)
            {
                List<int> EtkilesenEtkenMaddelerId = new List<int>();
                foreach (var item in vm.EtkilesenEtkenMaddelerId)
                {
                    EtkilesenEtkenMaddelerId.Add(Convert.ToInt32(item));
                }
                vm.EtkilesenEtkenMaddelerText = m.EtkilesenEtkenMaddeler == null ? null : db.EtkenMadde.Where(x => EtkilesenEtkenMaddelerId.Contains(x.Id)).Select(x => x.Ad).ToList();
            }
            return View(vm);
        }

        // GET: EtkenMadde/Create
        public ActionResult Create()
        {
            var vm = new EtkenMaddeViewModels
            {
                EtkenMaddeler = db.EtkenMadde.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Ad }).ToList()
            };
            return View(vm);
        }

        // POST: EtkenMadde/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Ad,Aciklama,EtkilesenEtkenMaddeler")] EtkenMaddeViewModels vm)
        {
            if (ModelState.IsValid)
            {
                var m = new EtkenMadde
                {
                    Ad = vm.Ad,
                    Aciklama = vm.Aciklama,
                    EtkilesenEtkenMaddeler = vm.EtkilesenEtkenMaddelerId == null ? null : string.Join("-", vm.EtkilesenEtkenMaddelerId)
                };
                db.EtkenMadde.Add(m);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vm);
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
            var vm = new EtkenMaddeViewModels
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                EtkilesenEtkenMaddelerId = m.EtkilesenEtkenMaddeler == null ? null : m.EtkilesenEtkenMaddeler.Split('-'),
                EtkenMaddeler = db.EtkenMadde.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Ad }).ToList(),
            };
            // ViewBag.EtkenMaddeler2 = new SelectList(vm.EtkenMaddeler.ToArray(),"Value","Text",vm.EtkilesenEtkenMaddeler);
            return View(vm);
        }

        // POST: EtkenMadde/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ad,Aciklama,EtkilesenEtkenMaddelerId")] EtkenMaddeViewModels vm)
        {
            if (ModelState.IsValid)
            {
                var m = new EtkenMadde
                {
                    Id=vm.Id,
                    Ad = vm.Ad,
                    Aciklama = vm.Aciklama,
                    EtkilesenEtkenMaddeler = vm.EtkilesenEtkenMaddelerId == null ? null : string.Join("-", vm.EtkilesenEtkenMaddelerId)
                };

                db.Entry(m).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vm);
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
            var vm = new EtkenMaddeViewModels
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                EtkilesenEtkenMaddelerId = m.EtkilesenEtkenMaddeler == null ? null : m.EtkilesenEtkenMaddeler.Split('-')
            };
            List<int> EtkilesenEtkenMaddelerId = new List<int>();
            if (vm.EtkilesenEtkenMaddelerId != null)
            {
                foreach (var item in vm.EtkilesenEtkenMaddelerId)
                {
                    EtkilesenEtkenMaddelerId.Add(Convert.ToInt32(item));
                }
                vm.EtkilesenEtkenMaddelerText = m.EtkilesenEtkenMaddeler == null ? null : db.EtkenMadde.Where(x => EtkilesenEtkenMaddelerId.Contains(x.Id)).Select(x => x.Ad).ToList();
            }
            return View(vm);
        }

        // POST: EtkenMadde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EtkenMadde etkenMadde = await db.EtkenMadde.FindAsync(id);
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
