using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilac_etkilesimleri.Data
{  
    public interface IEntity<T> 
   {
       T Id { get; set; }
   }
}
