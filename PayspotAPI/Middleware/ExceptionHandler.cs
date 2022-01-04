using System;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace PayspotAPI.Middleware;
public static class ExceptionHandler
{
    public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error => {
            error.Run(async context => {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeatures != null) {
                    Log.Error($"Something went wrong {contextFeatures.Error}");
                    await context.Response.WriteAsync(new Error {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error. Please try again later"
                    }.ToString());
                }
            });
        });
        return app;
    }
}