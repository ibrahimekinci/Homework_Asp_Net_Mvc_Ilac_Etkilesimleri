using ilac_etkilesimleri.Plugin.CustomAttributes;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Data
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Ilac")]
    public class Ilac : Entity<int>
    {
        public Ilac()
        {
            IlacEtkenMadde = new List<IlacEtkenMadde>();
        }
        [Display(ResourceType = typeof(Lang), Name = "LabelIlac"), CustomRequired]
        public string Ad { get; set; }
        [Display(ResourceType = typeof(Lang), Name = "LabelDetail")]
        public string Aciklama { get; set; }
        public string YanEtkiler { get; set; }
        public string NasilKullanilir { get; set; }
        public string DikkatEdilecekler { get; set; }
        public Nullable<bool> AnalizYapildiMi { get; set; }
        public ICollection<IlacEtkenMadde> IlacEtkenMadde { get; set; }
    }
}