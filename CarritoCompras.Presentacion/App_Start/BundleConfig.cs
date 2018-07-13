using System.Web;
using System.Web.Optimization;

namespace CarritoCompras.Presentacion
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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

            bundles.Add(new ScriptBundle("~/bundles/script-layaout").Include(
                      "~/Scripts/Controladores/functions.js",
                      "~/Scripts/Controladores/ajax-mvc.js"));

            //Home
            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                                  "~/Scripts/Controladores/Home/home-controller.js"));

            //Compra
            bundles.Add(new ScriptBundle("~/bundles/compra").Include(
                                  "~/Scripts/Controladores/Compra/compra-controller.js"));

            //Administracion
            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                                  "~/Scripts/Controladores/Admin/admin-controller.js"));


        }
    }
}
