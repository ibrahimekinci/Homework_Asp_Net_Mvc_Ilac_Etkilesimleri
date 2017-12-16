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
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        [Display(ResourceType = typeof(Lang), Name = "LabelId"), CustomRequired]
        public virtual T Id { get; set; }


    }
}
