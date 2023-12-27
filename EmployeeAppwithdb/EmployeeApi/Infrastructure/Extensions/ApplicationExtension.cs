using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EmployeeApi.Infrastructure.Extensions;

public static class ApplicationExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature =
                    context.Features.Get<IExceptionHandlerFeature>();



                if (contextFeature is not null)
                {
                    // Hata var contextFeature referans aldı ve null değil!

                    // switch (contextFeature.Error)
                    // {
                    //     case NotFoundException:
                    //         context.Response.StatusCode = StatusCodes.Status404NotFound;
                    //         break;
                    //     default:
                    //         context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    //         break;
                    // }

                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(new ErrorDetail()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}