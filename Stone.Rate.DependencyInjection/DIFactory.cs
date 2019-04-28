using Microsoft.Extensions.DependencyInjection;
using Stone.Framework.Http.Abstractions;
using Stone.Framework.Http.Concretes;
using Stone.Rate.Domain.Abstractions.TaskService;
using Stone.Rate.Domain.Concretes.TaskService;
using Stone.Rate.ServiceProvider.Abstractions;
using Stone.Rate.ServiceProvider.Concretes;

namespace Stone.Rate.DependencyInjection
{
    public static class DIFactory
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IRatingTaskService, RatingTaskService>();
            services.AddScoped<IClientServiceProvider, ClientServiceProvider>();
            services.AddScoped<IChargingServiceProvider, ChargingServiceProvider>();
            services.AddScoped<IHttpConnector, HttpConnector>();
        }
    }
}
