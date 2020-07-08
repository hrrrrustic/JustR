using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace JustR.DesktopGateway
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (Int32) HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (!(contextFeature is null)) await context.Response.WriteAsync(contextFeature.Error.ToString());
                });
            });
        }
    }
}