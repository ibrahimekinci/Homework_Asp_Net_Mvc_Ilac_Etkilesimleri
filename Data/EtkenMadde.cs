using ilac_etkilesimleri.Plugin.CustomAttributes;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Data
{
    [System.ComponentModel.DataAnnotations.Schema.Table("EtkenMadde")]
    public class EtkenMadde : Entity<int>
    {
        [Display(ResourceType = typeof(Lang), Name = "LabelEtkenMadde"), CustomRequired]
        public string Ad { get; set; }

        [Display(ResourceType = typeof(Lang), Name = "LabelDetail")]
        public string Aciklama { get; set; }
        public ICollection<IlacEtkenMadde> IlacEtkenMadde { get; set; }
    }
}
