using Microsoft.Extensions.DependencyInjection;
using System;
using UtilityBLL.IServices;
using UtilityBLL.Services;

namespace UtilityBLL
{
    public static class UtilityService
    {
        public static void AddUtilityServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IUserAccountMeterReadingService, UserAccountMeterReadingService>();
        } 
         
    }
}
