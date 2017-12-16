using System.ComponentModel.DataAnnotations;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;

namespace ilac_etkilesimleri.Plugin.CustomAttributes
{
    public class CustomMinLengthAttribute : MinLengthAttribute
    {
        public CustomMinLengthAttribute(int length) : base(length)
        {
            ErrorMessageResourceType = typeof(Lang);
            ErrorMessageResourceName = "Warning_MinLenght";
        }
    }
}
