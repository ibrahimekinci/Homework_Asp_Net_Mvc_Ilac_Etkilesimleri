using ilac_etkilesimleri.Plugin.CustomAttributes;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
