using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Core.Exceptions.HttpProblemDetails;

public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Business Rule Violation"; //dönen hatanın title ı
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "http://acunmedya.com/props/business";
        // API geliştiricileri veya frontend geliştiricileri bu hatayla ne yapmaları gerektiğini öğrenebilir.
    }
}
