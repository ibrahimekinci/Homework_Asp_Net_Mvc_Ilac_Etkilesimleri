using ilac_etkilesimleri.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ilac_etkilesimleri.Models
{
    public class IlacEtkilesimViewModel
    {
        public IlacEtkilesimViewModel()
        {
            EtkilesilenIlaclarId = new List<int>();
            EtkilesilenIlaclar = new List<IlacViewModel>();
        }
        public IlacViewModel Ilac { get; set; }
        public ICollection<int> EtkilesilenIlaclarId { get; set; }
        public ICollection<IlacViewModel> EtkilesilenIlaclar { get; set; }
    }
}