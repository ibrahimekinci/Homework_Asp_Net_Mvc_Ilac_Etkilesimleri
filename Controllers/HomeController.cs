using ilac_etkilesimleri.Data;
using ilac_etkilesimleri.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ilac_etkilesimleri.Controllers
{
    public class HomeController : Controller
    {
        TingoonDbContext db = new TingoonDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetIlacEtkilesim(string CheckIlaclar)
        {

            if (CheckIlaclar == null)
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            if (CheckIlaclar.EndsWith(","))
                CheckIlaclar = CheckIlaclar.Substring(0, CheckIlaclar.Length - 1);
            if (CheckIlaclar.StartsWith(","))
                CheckIlaclar = CheckIlaclar.Substring(1, CheckIlaclar.Length);
            List<int> IlacListId = new List<int>();
            foreach (var item in CheckIlaclar.Split(','))
                IlacListId.Add(Convert.ToInt32(item));
            var temp = db.IlacEtkilesim.Where(x => IlacListId.Contains(x.IlacId1) && IlacListId.Contains(x.IlacId2)).Distinct().Select(x => new { Ad1 = x.Ilac1.Ad, Ad2 = x.Ilac2.Ad, Id1 = x.IlacId1, Id2 = x.IlacId2 }).ToList();
            return new JsonResult { Data = temp, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetIlacSearchValue(string search)
        {
            var allsearch = db.Ilac.Where(x => x.Ad.Contains(search)).Select(x => new IlacEtkilesimIndexViewModel { Id = x.Id, Ad = x.Ad, AnalizYapildiMi = x.AnalizYapildiMi }).Take(10).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string mail, string konu, string ileti)
        {
            try
            {
                WebMail.SmtpServer = "smtp.live.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "mvckutuphanemiz@hotmail.com";
                WebMail.Password = "mvc123456";
                WebMail.SmtpPort = 587;
                WebMail.Send(
                        "mvckutuphanemiz@hotmail.com",
                        konu,
                        ileti,
                        mail
                    );

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_HATA", ex.Message);
            }
            return View();
        }
    }
}