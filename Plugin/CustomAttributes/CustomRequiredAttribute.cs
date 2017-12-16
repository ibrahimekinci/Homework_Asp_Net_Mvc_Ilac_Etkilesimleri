using System.ComponentModel.DataAnnotations;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;

namespace ilac_etkilesimleri.Plugin.CustomAttributes
{
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public CustomRequiredAttribute()
        {
            ErrorMessageResourceType = typeof(Lang);
            ErrorMessageResourceName = "Warning_FieldRequired";
        }
    }
}
