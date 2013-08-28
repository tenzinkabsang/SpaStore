﻿using System.Web;
using System.Web.Optimization;

namespace SpaStore
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/lib/jquery-{version}.js",
                "~/Scripts/lib/bootstrap.*",
                "~/Scripts/lib/toastr.*",
                "~/Scripts/lib/underscore.*",
                "~/Scripts/lib/holder.js",
                "~/Scripts/lib/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular/angular.*",
                "~/Scripts/angular/angular-resource.*",
                "~/angular/app/js/*.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap/bootstrap.*",
                "~/Content/bootstrap/bootstrap-theme*",
                "~/Content/bootstrap/carousel.*",
                "~/Content/toastr.css",
                "~/Content/app.css"
                ));

        }
    }
}