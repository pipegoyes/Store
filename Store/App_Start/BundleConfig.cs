using System.Web.Optimization;

namespace Store
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            AddJquery(bundle);
            //AddMaterialize(bundle);
            AddBoostrap(bundle);

            BundleTable.EnableOptimizations = true;
        }

        private static void AddJquery(BundleCollection bundle)
        {
            bundle.Add(new ScriptBundle("~/Scripts/jquery-1.9.1.js"));
        }

        private static void AddMaterialize(BundleCollection bundle)
        {
            bundle.Add(new ScriptBundle("~/Content/materialize-v0.97.5/js/materialize.js"));
            bundle.Add(new StyleBundle("~/Content/materialize-v0.97.5/css/materialize.css"));
        }

        private static void AddBoostrap(BundleCollection bundle)
        {
            bundle.Add(new ScriptBundle("~/Scripts/bootstrap.js"));
            bundle.Add(new StyleBundle("~/Content/bootstrap.css"));
        }
    }
}