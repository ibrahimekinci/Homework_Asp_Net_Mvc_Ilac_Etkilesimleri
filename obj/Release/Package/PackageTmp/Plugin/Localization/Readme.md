       
	   Global.asax -> Application_Start() 
	   
	   ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new ibrahimekinci.Plugin.Localization.LocalizedActivator("IT")));//çoklu dil
-------------------------------------------------------------------------

	   view içerisinde dile göre text çağırmak için 
	    <p>@ibrahimekinci.Plugin.Localization.LanguageResource.Lang.MenuHome</p>
-------------------------------------------------------------------------
		RouteConfig   -> RegisterRoutes içerisi

		  routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         
            #region ibrahiekinci.Plugin.Localization
            routes.MapRoute(
       name: "DefaultLocalized",
       url: "{lang}/{controller}/{action}/{id}",
         constraints: new { lang = @"(TR)|(EN)|(IT)" },
       //constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
       defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
   );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
-------------------------------------------------------------------------