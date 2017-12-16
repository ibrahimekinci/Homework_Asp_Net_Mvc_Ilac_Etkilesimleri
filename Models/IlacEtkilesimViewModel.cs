using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Models
{
    public class IlacEtkilesimViewModel
    {
        public IlacViewModel Ilac { get; set; }
    
        public List<IlacViewModel> EtkilesenIlaclar { get; set; }
        public List<string> EtkilesimNedenleri { get; set; }
    }
}