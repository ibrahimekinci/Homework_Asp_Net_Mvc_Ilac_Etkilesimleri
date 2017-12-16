using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using ilac_etkilesimleri.Plugin.Localization.Code;

namespace ilac_etkilesimleri.Plugin.Localization
{
    public class LocalizedActivator : IControllerActivator
    {
        public string UserDefaultLanguageBinaryCode = LocalizedInfo.DefaultLanguageBinaryCode;
        public LocalizedActivator(string userDefaultLanguageBinaryCode)
        {
            if (LocalizedInfo.SearchByBinaryCode(UserDefaultLanguageBinaryCode))
                UserDefaultLanguageBinaryCode = userDefaultLanguageBinaryCode;
            LocalizedInfo.Start();
        }
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            var lang = requestContext.RouteData.Values["lang"]?.ToString() ?? (UserDefaultLanguageBinaryCode);
            //string lang1 = (requestContext.RouteData.Values["lang"] != null) ? requestContext.RouteData.Values["lang"].ToString() : (UserDefaultLanguageBinaryCode);
            if (lang == LocalizedInfo.DefaultFileLanguageBinaryCode)
                return DependencyResolver.Current.GetService(controllerType) as IController;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}