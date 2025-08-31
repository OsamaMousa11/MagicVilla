using MagicVilla.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace MagicVilla_Villa.API.StartUp
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection ServiceConfiguration(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("connstr"));
            });
            return Services;
        }
    }
}
