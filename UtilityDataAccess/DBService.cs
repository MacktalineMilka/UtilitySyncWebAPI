using Microsoft.Extensions.DependencyInjection;
using UtilityDataAccess.IRepositories;
using UtilityDataAccess.Repositories;

namespace UtilityDataAccess
{
    public static class DBService
    {
        public static void AddDBServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountMeterReadingRepository, UserAccountMeterReadingRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        }
    }
}
