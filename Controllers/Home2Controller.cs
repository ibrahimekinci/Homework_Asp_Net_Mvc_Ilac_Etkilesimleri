using ilac_etkilesimleri.Data;
using ilac_etkilesimleri.Models;
using Newtonsoft.Json;
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
    public class Home2Controller : Controller
    {
        TingoonDbContext db = new TingoonDbContext();
        public ActionResult Index()
        {
            // List<tblDepartment> DeptList = db.tblDepartments.ToList();
            // ViewBag.ListOfDepartment = new SelectList(DeptList, "DepartmentId", "DepartmentName");
            return View();
        }
        public ActionResult Index2()
        {
            // List<tblDepartment> DeptList = db.tblDepartments.ToList();
            // ViewBag.ListOfDepartment = new SelectList(DeptList, "DepartmentId", "DepartmentName");
            return View();
        }
        public async Task<ActionResult> Index3()
        {
            return View(await db.Ilac.Select(x => new IlacEtkilesimIndexViewModel { Id = x.Id, Ad = x.Ad }).ToListAsync());
        }
        [HttpPost]
        public ActionResult Index3(List<IlacIndexViewModel> model)
        {
            foreach (var item in model)
            {
                if (item.AnalizYapildiMi)
                { // Do your logic}
                }
            }
            return RedirectToAction("Index3");


        }
        public JsonResult GetEtkenMaddeList()
        {
            List<EtkenMaddeViewModel> List = db.EtkenMadde.Select(x => new EtkenMaddeViewModel
            {
                Id = x.Id,
                Ad = x.Ad,
                Aciklama = x.Aciklama
            }).ToList();

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEtkenMaddeById(int Id)
        {
            EtkenMadde model = db.EtkenMadde.Where(x => x.Id == Id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(EtkenMaddeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // ViewBag.EtkenMaddeListe = db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }).ToList();
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                if (model.Id != null && model.Id > 0)
                {
                    EtkenMadde m = db.EtkenMadde.SingleOrDefault(x => x.Id == model.Id);
                    if (m.Ad != model.Ad.ToLower() && db.EtkenMadde.Where(x => x.Ad == model.Ad.ToLower()).Count() > 0)
                    {
                        ModelState.AddModelError("Ad", "Bu isimde bir etken madde zaten var.");
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    m.Aciklama = model.Aciklama;
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }

                if (db.EtkenMadde.Where(x => x.Ad == model.Ad.ToLower()).Count() > 0)
                {
                    ModelState.AddModelError("Ad", "Bu isimde bir etken madde zaten var.");
                    return Json(false, JsonRequestBehavior.AllowGet);
                    //ViewBag.EtkenMaddeListe =  db.EtkenMadde.Select(x => new SelectListItem { Text = x.Ad, Value = x.Id.ToString() }).ToList();
                }
                else
                {
                    EtkenMadde m = new EtkenMadde();
                    m.Ad = model.Ad;
                    m.Aciklama = model.Aciklama;
                    db.EtkenMadde.Add(m);
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
                //   ModelState.AddModelError("Hata", "Bu isimde bir etken madde zaten var.");
            }

        }

        public JsonResult DeleteEtkenMaddeRecord(int Id)
        {
            bool result = false;
            EtkenMadde m = db.EtkenMadde.SingleOrDefault(x => x.Id == Id);
            if (m != null)
            {
                db.EtkenMadde.Remove(m);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}