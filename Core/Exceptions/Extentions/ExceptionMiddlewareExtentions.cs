

using Microsoft.AspNetCore.Builder;

namespace Core.Exceptions.Extentions;

public static class ExceptionMiddlewareExtentions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>(); 
    //exceptionı http isteklerine ekleyecek
}
