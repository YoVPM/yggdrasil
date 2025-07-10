using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YoVPM.Yggdrasil.Core.Data;

namespace YoVPM.Yggdrasil.Core.Extenstion;

public static class ServiceCollectionExtenstion
{
    public static IServiceCollection AddYggdrasilCore(this IServiceCollection services)
    {
        // services.AddDbContext<YggdrasilDbContext>(options =>
        // {
        //     options.UseNpgsql()
        // });

        return services;
    }
}
