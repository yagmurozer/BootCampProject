
using Core.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;

namespace Core.Exceptions;

public class ExceptionMiddleware //middleware i api katmanında işlememiz lazım
{
    private readonly HttpExceptionHandler _handler;
    private readonly RequestDelegate _next; // add metotuna istek attıysak delegate gidip onun içine bakarak ona göre işlem uyguluyor.

    public ExceptionMiddleware(RequestDelegate next)
    {
        _handler = new HttpExceptionHandler();
        _next = next;
    }
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
         response.ContentType = "application/json";
        _handler.Response = response;
        return _handler.HandleExceptionAsync(exception);
    }
}
