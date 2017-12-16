using ilac_etkilesimleri.Plugin.CustomAttributes;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Data
{
    [System.ComponentModel.DataAnnotations.Schema.Table("EtkenMaddeEtkilesim")]
    public class EtkenMaddeEtkilesim : Entity<int>
    {
        [Display(ResourceType = typeof(Lang), Name = "LabelEtkenMadde"), CustomRequired]
        public int EtkenMaddeId1 { get; set; }

        [Display(ResourceType = typeof(Lang), Name = "LabelEtkenMadde"), CustomRequired]
        public int EtkenMaddeId2 { get; set; }

        [Display(ResourceType = typeof(Lang), Name = "LabelDetail")]
        public string Aciklama { get; set; }

        [ForeignKey("EtkenMaddeId1")]
        public virtual EtkenMadde EtkenMadde1 { get; set; }
        [ForeignKey("EtkenMaddeId2")]
        public virtual EtkenMadde EtkenMadde2 { get; set; }

    }
}