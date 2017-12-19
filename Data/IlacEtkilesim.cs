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
    [System.ComponentModel.DataAnnotations.Schema.Table("IlacEtkilesim")]
    public class IlacEtkilesim : Entity<int>
    {
        [Display(ResourceType = typeof(Lang), Name = "LabelIlac"), CustomRequired]
        public int IlacId1 { get; set; }
        [Display(ResourceType = typeof(Lang), Name = "LabelIlac"), CustomRequired]
        public int IlacId2 { get; set; }
        [Display(ResourceType = typeof(Lang), Name = "LabelDetail")]
        public string Aciklama { get; set; }
        [ForeignKey("IlacId1")]
        public virtual Ilac Ilac1 { get; set; }
        [ForeignKey("IlacId2")]
        public virtual Ilac Ilac2 { get; set; }
    }
}