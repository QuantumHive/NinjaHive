﻿using System.Web.Optimization;

namespace NinjaHive.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/extensions").Include(
                "~/Scripts/BootstrapExtensions/ListGroupExtensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/ninjahive").Include(
                "~/Scripts/NinjaHive/NinjaHive_Ajax.js",
                "~/Scripts/NinjaHive/NinjaHive_Common.js",
                "~/Scripts/NinjaHive/NinjaHive_GenericModal.js",
                "~/Scripts/NinjaHive/NinjaHive_DynamicObjectTemplate.js",
                "~/Scripts/NinjaHive/NinjaHive_EditableElementManager.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Win8Loader.css",
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}
