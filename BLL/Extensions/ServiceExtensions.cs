
using BLL.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BLL.Extensions;

public static class ServiceExtensions
{
    /// <summary>
    /// Додавання бізнес сервісів у контейнер впровадження залежностей.
    /// </summary>
    public static IServiceCollection AddBLLScopedServices(this IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var serviceInterfases = assembly.GetTypes()
            .Where(type => type.GetCustomAttribute<InterfaceForDI>() != null)
            .ToArray();

        foreach(var serviceInterfase in serviceInterfases)
        {
            var serviceClasses = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && serviceInterfase.IsAssignableFrom(type))
            .ToArray();

            if(serviceClasses.Length > 0)
            {
                foreach(var serviceClass in serviceClasses)
                {
                    serviceCollection.AddScoped(serviceInterfase, serviceClass);
                }
            }
        }

        return serviceCollection;
    }
}
