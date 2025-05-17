

using Core.Exceptions.Extentions;
using Core.Exceptions.HttpProblemDetails;
using Core.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler //hata yapıları http response ile dönüyor.
{
    private HttpResponse? _response;
    // get ve set ile encapsulate hale getirilecek
    public HttpResponse Response
    { //httpresponse un instance oluşmasında: getle çağırırken instance oluşmadıysa aşağıdaki hatayı döndürecek
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }
    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode= StatusCodes.Status400BadRequest;
        string details =new BusinessProblemDetails(businessException.Message).AsJson(); //problemDetails sınıfını stringe çeviremediği için hata veriyor
        return Response.WriteAsync(details);

        // json dosyasına çevirebilmesi için ayrı bir exception oluşturmalıyız
    }

    protected override Task HandleException(Exception exception) //exception fırlatılması 500 kodunu döndürmeli
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new BusinessProblemDetails(exception.Message).AsJson(); //problemDetails sınıfını stringe çeviremediği için hata veriyor
        return Response.WriteAsync(details);
    }
}
