using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ilac_etkilesimleri.Models
{
    public class EtkenMaddeViewModels
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public IEnumerable<string> EtkilesenEtkenMaddelerText { get; set; }
        public IEnumerable<string> EtkilesenEtkenMaddelerId { get; set; }
        public IEnumerable<SelectListItem> EtkenMaddeler { get; set; }

    }
}