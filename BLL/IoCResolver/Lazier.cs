using Microsoft.Extensions.DependencyInjection;

namespace BLL.IoCResolver;

internal class Lazier<T> : Lazy<T> where T : class
{
    public Lazier(IServiceProvider provider)
        : base(() => provider.GetRequiredService<T>()) 
    { }
}
