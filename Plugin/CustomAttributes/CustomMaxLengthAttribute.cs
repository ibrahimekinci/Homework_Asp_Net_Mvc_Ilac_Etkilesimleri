using System.ComponentModel.DataAnnotations;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;

namespace ilac_etkilesimleri.Plugin.CustomAttributes
{
    public class CustomMaxLengthAttribute : MaxLengthAttribute
    {
        public CustomMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessageResourceType = typeof(Lang);
            ErrorMessageResourceName = "Warning_MaxLenght";
        }
    }
}
