

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.Exceptions.Extentions;

public static class ProblemDetailsExtentions //problem details sınıfından türemiş json a dönüştürüp serileştiren bir extentiondır
{
    public static string AsJson<TProblemDetail>(this TProblemDetail problemDetail)
        where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(problemDetail);
} //problemDetails den türeyen her problem details sınıfını serileştirir.
