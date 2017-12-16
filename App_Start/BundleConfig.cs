using System.Web;
using System.Web.Optimization;

namespace ilac_etkilesimleri
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/bower_components/jquery/dist/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/bower_components/jquery/dist/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
          "~/Assets/dist/css/AdminLTE.min.css",
          "~/Assets/dist/css/skins/skin-blue.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Assets/bower_components/jquery/dist/jquery.min.js",
                      "~/Assets/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/Assets/dist/js/adminlte.min.js"
                      ,"~/Assets/bower_components/jquery/dist/jquery.validate.min.js"
                      ));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));


        }
    }
}
