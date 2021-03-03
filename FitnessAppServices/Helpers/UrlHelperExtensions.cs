using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppServices.Helpers
{
    public static class UrlHelperExtensions
    {
        private static IHttpContextAccessor HttpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public static string AbsoluteAction(
            this IUrlHelper url,
            string actionName,
            string controllerName,
            object routeValues = null)
        {
            string scheme = HttpContextAccessor.HttpContext.Request.Scheme;
            return url.Action(actionName, controllerName, routeValues, scheme);
        }


    }
}
