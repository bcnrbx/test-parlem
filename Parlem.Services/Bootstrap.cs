using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using Parlem.Services.Customer;
using Parlem.Services.Health;

namespace Parlem.Services
{
    public static class Bootstrap
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddTransient<IHealthService, HealthService>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<HttpClient>();
            services.AddLogging();
            services.AddSingleton(typeof(ILogger), _logger);

            services.AddMemoryCache();
        }
    }
}
