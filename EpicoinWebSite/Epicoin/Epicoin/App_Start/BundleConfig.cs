using System.Web;
using System.Web.Optimization;

namespace Epicoin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            // css
            bundles.Add(new StyleBundle("~/bundles/css").
                Include("~/Content/Site.css"));

            //js
            bundles.Add(new ScriptBundle("~/bundles/js").
                Include("~/Scripts/Script.js")
                );
            
            //modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").
                Include("~/Scripts/modernizr-2.6.2.js")
                );

            //jquery
            var jqueryCdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js";
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                jqueryCdnPath).Include(
                "~/Scripts/jquery-3.3.1.js")
                 );

            //materialyzecss
            
            

        }
    }
}