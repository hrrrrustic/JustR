using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace JustR.DesktopGateway
{
    public static class ServiceConfigurations
    {
        public static String ProfileServiceUri { get; set; } = "http://localhost:5005/api/Profile";
        public static String DialogServiceUri { get; set; } = "http://localhost:5006/api/Dialog";
        public static String MessageServiceUri { get; set; } = "http://localhost:5007/api/Message";
        public static String FriendServiceUri { get; set; } = "http://localhost:5002/api/Friend";

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (Int32) HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync("Error");
                    }
                });
            });
        }
    }
}       