using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Data
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Ilac")]
    public class Ilac : Entity<int>
    {
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public string YanEtkiler { get; set; }
        public string NasilKullanilir { get; set; }
        public string DikkatEdilecekler { get; set; }
        public string EtkenMaddeler { get; set; }
        public virtual List<EtkenMadde> EtkenMaddeListe { get; set; }
    }
}