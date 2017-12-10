using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Models
{
    public class IlacIndexViewModels
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool AnalizYapildiMi { get; set; }
    }
}