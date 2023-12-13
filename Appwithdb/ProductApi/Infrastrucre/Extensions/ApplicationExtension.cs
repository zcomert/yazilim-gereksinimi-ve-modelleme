using Entities.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ProductApi.Infrastrucre.Extensions;

public static class ApplicationExtension
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
                        Message = "Beklenmeyen bir hata oluştu!"
                    }.ToString());
                }

            });
        });
    }
}