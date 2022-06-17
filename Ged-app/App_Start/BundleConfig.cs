using System.Web;
using System.Web.Optimization;

namespace Ged_app
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js"

                      //"~/Content/vendors/js/vendor.bundle.base.js",
                      //"~/Content/js/off-canvas.js",
                      //"~/Content/js/hoverable-collapse.js",
                      //"~/Content/js/template.js",
                      //"~/Content/js/settings.js",
                      //"~/Content/js/todolist.js",
                      //"~/Content/vendors/progressbar.js/progressbar.min.js",
                      //"~/Content/vendors/chart.js/Chart.min.js",
                      //"~/Content/js/dashboard.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"

                      //"~/Content/vendors/typicons.font/font/typicons.css",
                      //"~/Content/vendors/css/vendor.bundle.base.css",
                      //"~/Content/css/vertical-layout-light/style.css"
                      ));
        }
    }
}
