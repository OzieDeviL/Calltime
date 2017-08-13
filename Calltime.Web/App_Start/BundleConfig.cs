using System.Web;
using System.Web.Optimization;

namespace Calltime.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/assets/plugins/jquery/jquery-migrate.min.js",
                        "~/assets/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/js/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/oz.site.css",
                      "~/assets/css/style.css",
                      "~/assets/css/headers/header-v6.css",
                      "~/assets/css/headers/footer-v6.css",
                      "~/assets/plugins/animate.css",
                      "~/assets/plugins/line-icons/line-icons.css",
                      "~/assets/plugins/font-awesome/css/font-awesome.css",
                      "~/assets/css/theme-colors/blue.css",
                      "~/assets/css/custom.css",
                      "~/assets/plugins/sliding-panel/style.css",
                      "~/assets/plugins/sliding-panel/styleMessenger.css",
                      "~/assets/plugins/parallax-slider/css/parallax-slider.css"
                      ));
           
            //Unify Theme Global JS Implementing Plugins
            bundles.Add(new ScriptBundle("~/bundles/js/globalPlugins").Include(
                "~/assets/plugins/back-to-top.js",
                "~/assets/plugins/smoothScroll.js",
                "~/assets/plugins/sliding-panel/jquery.sliding-panel.js",
                "~/assets/plugins/sliding-panel/jquery.sliding-messengerPanel.js",
                "~/assets/js/plugins/parallax-slider.js",
                "~/assets/plugins/parallax-slider/js/modernizr.js",
                "~/assets/plugins/parallax-slider/js/jquery.cslider.js",
                 "~/assets/plugins/jquery.parallax.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/ng").Include(
                "~/Scripts/angular.js",
                //"~/Scripts/angular.min.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-animate.min.js"
                //"~/bower_components/angular-formly/dist/formly.js"
                //"~/bower_components/angular-formly/dist/formly.min.js"
                ));

            //Angular App Modules
            bundles.Add(new ScriptBundle("~/bundles/js/ng/app").Include(
                "~/ScriptsApp/app.module.js"));

            //Angular CRUD
            bundles.Add(new ScriptBundle("~/bundles/js/ng/crud").Include(
            "~/ScriptsApp/*.js",
            "~/ScriptsApp/modules/*.js",
            "~/ScriptsApp/modules/crud/*.js",
            "~/ScriptsApp/modules/crud/controllers/*.js",
            "~/ScriptsApp/modules/crud/directives/*.js",
            "~/ScriptsApp/modules/crud/services/*.js",
            "~/ScriptsApp/modules/crud/templates/*.js"));
        }

    }
}
