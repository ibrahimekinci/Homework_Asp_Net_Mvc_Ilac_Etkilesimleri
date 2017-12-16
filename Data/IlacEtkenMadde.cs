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
    [System.ComponentModel.DataAnnotations.Schema.Table("IlacEtkenMadde")]
    public class IlacEtkenMadde : Entity<int>
    {
        [Display(ResourceType = typeof(Lang), Name = "LabelIlac"), CustomRequired]
        public int IlacId { get; set; }

        [Display(ResourceType = typeof(Lang), Name = "LabelEtkenMadde"), CustomRequired]
        public int EtkenMaddeId { get; set; }

        [ForeignKey("IlacId")]
        public virtual Ilac Ilac { get; set; }
        [ForeignKey("EtkenMaddeId")]
        public virtual EtkenMadde EtkenMadde { get; set; }

    }
}