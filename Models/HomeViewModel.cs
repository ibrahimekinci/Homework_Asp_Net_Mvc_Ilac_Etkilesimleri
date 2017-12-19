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
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            IlacEtkilesim = new List<IlacEtkilesim>();
        }
        public List<IlacEtkilesim> IlacEtkilesim { get; set; }
    }
}