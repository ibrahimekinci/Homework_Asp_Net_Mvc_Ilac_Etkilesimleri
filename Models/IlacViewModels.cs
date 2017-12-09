using ilac_etkilesimleri.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ilac_etkilesimleri.Models
{
    public class IlacViewModels
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public string YanEtkiler { get; set; }
        public string NasilKullanilir { get; set; }
        public string DikkatEdilecekler { get; set; }
        public IEnumerable<string> EtkenMaddelerText { get; set; }
        public IEnumerable<string> EtkenMaddelerId { get; set; }
        public IEnumerable<SelectListItem> EtkenMaddeler { get; set; }
    }
}