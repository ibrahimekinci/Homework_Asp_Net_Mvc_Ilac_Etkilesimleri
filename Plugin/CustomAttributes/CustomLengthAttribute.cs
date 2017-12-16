
using System.ComponentModel.DataAnnotations;
using ilac_etkilesimleri.Plugin.Localization.LanguageResource;

namespace ilac_etkilesimleri.Plugin.CustomAttributes
{
    public class CustomLengthAttribute : StringLengthAttribute
    {
        public CustomLengthAttribute(int length) : base(length)
        {
            //Length varsayılan olarak max length eşittir.
            MinimumLength = MaximumLength;
            ErrorMessageResourceType = typeof(Lang);
            ErrorMessageResourceName = "Warning_LenghtLimit";
        }
        public CustomLengthAttribute(int minimumLength, int maximumLength) : base(maximumLength)
        {
            MinimumLength = minimumLength;
            ErrorMessageResourceType = typeof(Lang);
            ErrorMessageResourceName = "Warning_Interval";
        }
    }
}
