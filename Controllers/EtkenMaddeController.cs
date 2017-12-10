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
        public async Task<ActionResult> Create([Bind(Include = "Id,Ad,Aciklama,EtkilesenEtkenMaddelerId")] EtkenMaddeViewModels vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var m = new EtkenMadde
            {
                Ad = vm.Ad,
                Aciklama = vm.Aciklama,
                EtkilesenEtkenMaddeler = vm.EtkilesenEtkenMaddelerId == null ? null : string.Join("-", vm.EtkilesenEtkenMaddelerId)
            };
            db.EtkenMadde.Add(m);
            await db.SaveChangesAsync();

            if (vm.EtkilesenEtkenMaddelerId != null)
            {
                foreach (var etkilesenEtkenMaddeId in vm.EtkilesenEtkenMaddelerId)
                {
                    var tempEtkenMadde = await db.EtkenMadde.FindAsync(Convert.ToInt32(etkilesenEtkenMaddeId));
                    if (tempEtkenMadde == null)
                        continue;
                    if (tempEtkenMadde.EtkilesenEtkenMaddeler == null)
                        tempEtkenMadde.EtkilesenEtkenMaddeler = m.Id.ToString();
                    else
                        tempEtkenMadde.EtkilesenEtkenMaddeler = tempEtkenMadde.EtkilesenEtkenMaddeler + "-" + m.Id.ToString();
                    db.Entry(m).State = EntityState.Modified;
                }
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
            var vm = new EtkenMaddeViewModels
            {
                Id = m.Id,
                Ad = m.Ad,
                Aciklama = m.Aciklama,
                EtkilesenEtkenMaddelerId = m.EtkilesenEtkenMaddeler == null ? null : m.EtkilesenEtkenMaddeler.Split('-'),
                EtkenMaddeler = db.EtkenMadde.Where(x => x.Id != m.Id).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Ad }).ToList(),
            };
            return View(vm);
        }

        // POST: EtkenMadde/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ad,Aciklama,EtkilesenEtkenMaddelerId")] EtkenMaddeViewModels vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            EtkenMadde m = await db.EtkenMadde.FindAsync(vm.Id);
            m.Ad = vm.Ad;
            m.Aciklama = vm.Aciklama;
            if (m == null)
            {
                return HttpNotFound();
            }
            //var YeniM = new EtkenMadde
            //{
            //    Id = vm.Id,
            //    Ad = vm.Ad,
            //    Aciklama = vm.Aciklama,
            //    EtkilesenEtkenMaddeler = vm.EtkilesenEtkenMaddelerId == null ? null : string.Join("-", vm.EtkilesenEtkenMaddelerId)
            //};
            if (m.EtkilesenEtkenMaddeler == string.Join("-", vm.EtkilesenEtkenMaddelerId))
            {
                db.Entry(m).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var eskiEtkilesenEtkenMaddelerId = m.EtkilesenEtkenMaddeler == null ? null : m.EtkilesenEtkenMaddeler.Split('-');
            if (eskiEtkilesenEtkenMaddelerId != null)
            {
                foreach (var item in eskiEtkilesenEtkenMaddelerId)
                {
                    if (!vm.EtkilesenEtkenMaddelerId.Contains(item))
                    {
                        var tempEtkenMadde = await db.EtkenMadde.FindAsync(Convert.ToInt32(item));
                        if (tempEtkenMadde != null)
                        {
                            var tempEtkenMaddeEtkilesenEtkenMaddelerId = tempEtkenMadde.EtkilesenEtkenMaddeler == null ? null : tempEtkenMadde.EtkilesenEtkenMaddeler.Split('-');
                            tempEtkenMadde.EtkilesenEtkenMaddeler = null;
                            foreach (var item2 in tempEtkenMaddeEtkilesenEtkenMaddelerId)
                            {
                                if (item2 != vm.Id.ToString())
                                {
                                    if (tempEtkenMadde.EtkilesenEtkenMaddeler == null)
                                        tempEtkenMadde.EtkilesenEtkenMaddeler = item2;
                                    else
                                        tempEtkenMadde.EtkilesenEtkenMaddeler = tempEtkenMadde.EtkilesenEtkenMaddeler + "-" + item2;
                                }
                            }
                            db.Entry(tempEtkenMadde).State = EntityState.Modified;
                        }
                    }
                }
            }

            if (vm.EtkilesenEtkenMaddelerId != null)
            {
                m.EtkilesenEtkenMaddeler = null;
                foreach (var etkilesenEtkenMaddeId in vm.EtkilesenEtkenMaddelerId)
                {
                    var tempEtkenMadde = await db.EtkenMadde.FindAsync(Convert.ToInt32(etkilesenEtkenMaddeId));
                    if (tempEtkenMadde != null)
                    {
                        //üzerinde çalışılan nesneni etkileşilenler listesi güncelleniyor
                        if (m.EtkilesenEtkenMaddeler == null)
                            m.EtkilesenEtkenMaddeler = tempEtkenMadde.Id.ToString();
                        else
                            m.EtkilesenEtkenMaddeler = m.EtkilesenEtkenMaddeler + "-" + tempEtkenMadde.Id.ToString();

                        if (eskiEtkilesenEtkenMaddelerId == null || !eskiEtkilesenEtkenMaddelerId.Contains(etkilesenEtkenMaddeId))
                        {
                            //Etkileşin etken maddelerin etkilenleri kısmına şuan değişiklik yapılan etken madde ıd si ekleniyor
                            if (tempEtkenMadde.EtkilesenEtkenMaddeler == null)
                                tempEtkenMadde.EtkilesenEtkenMaddeler = m.Id.ToString();
                            else
                                tempEtkenMadde.EtkilesenEtkenMaddeler = tempEtkenMadde.EtkilesenEtkenMaddeler + "-" + m.Id.ToString();
                            db.Entry(tempEtkenMadde).State = EntityState.Modified;
                        }
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
