using ilac_etkilesimleri.Data;
using ilac_etkilesimleri.Plugin.CustomAttributes;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ilac_etkilesimleri.Models
{
    public class IlacViewModel
    {
        public IlacViewModel()
        {
            EtkenMaddelerId = new List<int>();
            EtkenMaddeler = new List<EtkenMadde>();
        }
        public int Id { get; set; }
        [Display(ResourceType = typeof(Lang), Name = "LabelIlac"), CustomRequired]
        public string Ad { get; set; }
        [Display(ResourceType = typeof(Lang), Name = "LabelDetail"), CustomRequired]
        [AllowHtml]
        public string Aciklama { get; set; }
        [AllowHtml]
        public string YanEtkiler { get; set; }
        [AllowHtml]
        public string NasilKullanilir { get; set; }
        [AllowHtml]
        public string DikkatEdilecekler { get; set; }
        [Display(ResourceType = typeof(Lang), Name = "LabelEtkenMadde"), CustomRequired]
        public ICollection<int> EtkenMaddelerId { get; set; }
        public ICollection<EtkenMadde> EtkenMaddeler { get; set; }
    }
}