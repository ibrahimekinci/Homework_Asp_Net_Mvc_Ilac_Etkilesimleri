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
    public class IlacController : Controller
    {
        private TingoonDbContext db = new TingoonDbContext();

        // GET: Ilac
        public async Task<ActionResult> Index()
        {
            return View(await db.IlacModels.ToListAsync());
        }

        // GET: Ilac/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilac ilac = await db.IlacModels.FindAsync(id);
            if (ilac == null)
            {
                return HttpNotFound();
            }
            return View(ilac);
        }

        // GET: Ilac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ilac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Ad,Aciklama,YanEtkiler,NasilKullanilir,DikkatEdilecekler,EtkenMaddeler")] Ilac ilac)
        {
            if (ModelState.IsValid)
            {
                db.IlacModels.Add(ilac);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ilac);
        }

        // GET: Ilac/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilac ilac = await db.IlacModels.FindAsync(id);
            if (ilac == null)
            {
                return HttpNotFound();
            }
            return View(ilac);
        }

        // POST: Ilac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ad,Aciklama,YanEtkiler,NasilKullanilir,DikkatEdilecekler,EtkenMaddeler")] Ilac ilac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilac).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ilac);
        }

        // GET: Ilac/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilac ilac = await db.IlacModels.FindAsync(id);
            if (ilac == null)
            {
                return HttpNotFound();
            }
            return View(ilac);
        }

        // POST: Ilac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ilac ilac = await db.IlacModels.FindAsync(id);
            db.IlacModels.Remove(ilac);
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
