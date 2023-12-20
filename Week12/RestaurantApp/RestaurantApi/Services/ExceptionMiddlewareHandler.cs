using Entities;
using Microsoft.AspNetCore.Diagnostics;

namespace RestaurantApi.Services;

public static class ExceptionMiddlewareHandler
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature is not null) // bu durumda hata var!
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(new ErrorDetail()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error"
                    }.ToString());
                }

            });
        });
    }
}