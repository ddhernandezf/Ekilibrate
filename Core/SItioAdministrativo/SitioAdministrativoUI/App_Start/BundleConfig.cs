using System.Web;
using System.Web.Optimization;

namespace SitioAdministrativoUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
              "~/assets/css/bootstrap.min.css"));

            


            bundles.Add(new StyleBundle("~/css/beyond").Include(
                "~/assets/css/beyond.min.css",
                "~/assets/css/demo.min.css",
                "~/assets/css/font-awesome.min.css",
                "~/assets/css/typicons.min.css",
                "~/assets/css/weather-icons.min.css",
                "~/assets/css/animate.min.css"
                ));

            bundles.Add(new StyleBundle("~/css/beyond-rtl").Include(
                "~/assets/css/beyond-rtl.min.css",
                "~/assets/css/demo.min.css",
                "~/assets/css/font-awesome.min.css",
                "~/assets/css/typicons.min.css",
                "~/assets/css/weather-icons.min.css",
                "~/assets/css/animate.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/skin").Include(
                "~/assets/js/skins.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //    "~/assets/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/assets/js/bootstrap.min.js",
                "~/assets/js/slimscroll/jquery.slimscroll.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/beyond").Include(
                "~/assets/js/beyond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/assets/js/jqueryval/jquery.validate*"));
        }
    }
}
