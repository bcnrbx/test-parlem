using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Parlem.DAL
{
    public static class Bootstrap
    {
        public static void AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParlemDBContext>(options =>
                options.UseMySql(configuration.GetConnectionString("ParlemDB"),
                                    ServerVersion.AutoDetect(configuration.GetConnectionString("ParlemDB")),
                                    x => x.MigrationsAssembly("Parlem.DAL").EnableStringComparisonTranslations(true)));
        }
    }
}
