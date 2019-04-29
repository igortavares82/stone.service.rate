using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Rate.ServiceProvider.Options;

namespace Stone.Rate.WebApi.Configurations
{
    public static class ConfigureService
    {
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceChargeOptions>(options => configuration.GetSection("ServiceChargeOptions").Bind(options));
            services.Configure<ServiceClientOptions>(options => configuration.GetSection("ServiceClientOptions").Bind(options));
        }
    }
}
