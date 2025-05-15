
using Core.Extentions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services) // bu şekilde IServiceCollectionı genişletmiş oluyoruz
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.RegistrationAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.ServiceType.Name.EndsWith("Manager"));
        return services;   
    }

}
