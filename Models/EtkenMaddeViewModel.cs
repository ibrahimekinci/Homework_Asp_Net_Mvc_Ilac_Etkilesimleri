using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ilac_etkilesimleri.Data;
using ilac_etkilesimleri.Plugin.CustomAttributes;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;

namespace ilac_etkilesimleri.Models
{
    public class EtkenMaddeViewModel
    {
        public EtkenMaddeViewModel()
        {
            EtkilesenEtkenMaddelerId = new List<int>();
            EtkilesenEtkenMaddeler = new List<EtkenMadde>();
        }
        public int Id { get; set; }
        [Display(ResourceType = typeof(Lang), Name = "LabelEtkenMadde"), CustomRequired]
        public string Ad { get; set; }

        [Display(ResourceType = typeof(Lang), Name = "LabelDetail")]
        [AllowHtml]
        public string Aciklama { get; set; }
        public ICollection<int> EtkilesenEtkenMaddelerId { get; set; }
        public ICollection<EtkenMadde> EtkilesenEtkenMaddeler { get; set; }
    }
}