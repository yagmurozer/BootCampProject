using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Exceptions.HttpProblemDetails;

public class InternalServalErrorProblem : ProblemDetails //sistemle alakalı hatalar için
{
    public InternalServalErrorProblem(string detail)
    {
        Title = "Internal Server Error"; //dönen hatanın title ı
        Detail = detail;
        Status = StatusCodes.Status500InternalServerError;
        Type = "http://acunmedya.com/props/internal";
    }
}
