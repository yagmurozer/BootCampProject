
using Business.Rules;
using Core.Extentions;
using Core.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services) // bu şekilde IServiceCollectionı genişletmiş oluyoruz
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.RegistrationAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.ServiceType.Name.EndsWith("Manager"));

        //business rulesları register etmeliyiz. sürekli addScoped yazmamak için AssemblyTypeRegistrationa yeni metotu burada çağırdık
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        return services;   
    }

}
