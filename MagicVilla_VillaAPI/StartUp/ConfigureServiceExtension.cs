using MagicVilla.Core.Domain.RepositoriyContracts;
using MagicVilla.Core.ServiceContracts;
using MagicVilla.Core.Services;
using MagicVilla.Infrastructure.Data;
using MagicVilla.Infrastructure.Repostitories;
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
            Services.AddScoped<IVillasRespository, VillaRepostitory>();
            Services.AddScoped<IVillaService, VillaService>();
            
            return Services;
        }
    }
}
