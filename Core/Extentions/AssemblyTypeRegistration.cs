using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Core.Extentions;

public static class AssemblyTypeRegistration
{
    public static IServiceCollection RegistrationAssemblyTypes(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract); // nesne oluşturabilen classları al
        foreach (Type? type in types)
        {
            var interfaces = type.GetInterfaces(); //type ların arasında interface varsa onları al
            foreach ( var @interface in interfaces)
            {
                services.AddScoped(@interface, type);

            }
        }
        return services;
    }
}
