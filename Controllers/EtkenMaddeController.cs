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

namespace ilac_etkilesimleri.Controllers
{
    public class EtkenMaddeController : Controller
    {
        private TingoonDbContext db = new TingoonDbContext();

        // GET: EtkenMadde
        public async Task<ActionResult> Index()
        {
            return View(await db.EtkenMaddeModels.ToListAsync());
        }

        // GET: EtkenMadde/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkenMadde etkenMadde = await db.EtkenMaddeModels.FindAsync(id);
            if (etkenMadde == null)
            {
                return HttpNotFound();
            }
            return View(etkenMadde);
        }

        // GET: EtkenMadde/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtkenMadde/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Ad,Aciklama,BeraberKullanilmayacaklar")] EtkenMadde etkenMadde)
        {
            if (ModelState.IsValid)
            {
                db.EtkenMaddeModels.Add(etkenMadde);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(etkenMadde);
        }

        // GET: EtkenMadde/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkenMadde etkenMadde = await db.EtkenMaddeModels.FindAsync(id);
            if (etkenMadde == null)
            {
                return HttpNotFound();
            }
            return View(etkenMadde);
        }

        // POST: EtkenMadde/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ad,Aciklama,BeraberKullanilmayacaklar")] EtkenMadde etkenMadde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etkenMadde).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(etkenMadde);
        }

        // GET: EtkenMadde/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkenMadde etkenMadde = await db.EtkenMaddeModels.FindAsync(id);
            if (etkenMadde == null)
            {
                return HttpNotFound();
            }
            return View(etkenMadde);
        }

        // POST: EtkenMadde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EtkenMadde etkenMadde = await db.EtkenMaddeModels.FindAsync(id);
            db.EtkenMaddeModels.Remove(etkenMadde);
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
