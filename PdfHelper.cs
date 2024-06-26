﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;


namespace Rotativaio.AspNetCore
{
    public class DummyPdfController : Controller { }

    public static class PdfHelper
    {
        /// <summary>
        /// Creates an instance of an MVC controller from scratch 
        /// when no existing ControllerContext is present       
        /// </summary>
        /// <typeparam name="T">Type of the controller to create</typeparam>
        /// <returns>Controller Context for T</returns>
        /// <exception cref="InvalidOperationException">thrown if HttpContext not available</exception>
        //public static T CreateController<T>(RouteData routeData = null)
        //            where T : Controller, new()
        //{
        //    // create a disconnected controller instance
        //    T controller = new T();

        //    //// get context wrapper from HttpContext if available
        //    //HttpContext wrapper = null;
        //    //if (HttpContext != null)
        //    //    wrapper = new HttpContext();
        //    //else
        //    //    throw new InvalidOperationException(
        //    //        "Can't create Controller Context if no active HttpContext instance is available.");

        //    if (routeData == null)
        //        routeData = new RouteData();

        //    // add the controller routing if not existing
        //    if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
        //        routeData.Values.Add("controller", controller.GetType().Name
        //                                                    .ToLower()
        //                                                    .Replace("controller", ""));

        //    controller.ControllerContext = new ControllerContext(); // wrapper, routeData, controller);
        //    return controller;
        //}

        //public static string GetPdfUrl(
        //    string view, object model = null, string filename = null, string switches = null)
        //{
        //    var pdfUri = GetPdfUrl(view, model, filename, switches, null, null);
        //    return pdfUri;
        //}

        public static async Task<string> GetPdfUrl(
            ControllerContext controllerContext, string view = null, object model = null, string filename = null, string switches = null, string headerView = null, string footerView = null)
        {
            var viewAsPdf = new ViewAsPdf(view, model)
            {
                CustomSwitches = switches ?? "",
                FileName = filename
            };

            if (string.IsNullOrEmpty(headerView) == false)
                viewAsPdf.HeaderView = headerView;

            if (string.IsNullOrEmpty(footerView) == false)
                viewAsPdf.FooterView = footerView;

            var pdfUri = await viewAsPdf.BuildPdf(controllerContext);
            return pdfUri;

        }

        //public static byte[] GetPdf(
        //    string view, object model = null, string filename = null, string switches = null)
        //{
        //    var pdfUri = GetPdfUrl(view, model, filename, switches);

        //    using (var client = new WebClient())
        //    {
        //        var pdf = client.DownloadData(pdfUri);
        //        return pdf;
        //    }
        //}

        public static async Task<byte[]> GetPdf(
            ControllerContext controllerContext, string view = null, object model = null, string filename = null, string switches = null,
            string headerView = null, string footerView = null)
        {
            var pdfUri = await GetPdfUrl(controllerContext, view, model, filename, switches, headerView, footerView);

            using (var client = new WebClient())
            {
                var pdf = await client.DownloadDataTaskAsync(pdfUri);
                return pdf;
            }
        }

    }
}
