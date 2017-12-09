using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Data
{
    [System.ComponentModel.DataAnnotations.Schema.Table("EtkenMadde")]
    public class EtkenMadde : Entity<int>
    {
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public string EtkilesenEtkenMaddeler { get; set; }
    }
}