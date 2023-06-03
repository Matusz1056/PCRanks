using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PCRanks.Domain.Interfaces;
using PCRanks.Infrastructure.Persistence;
using PCRanks.Infrastructure.Repositories;
using PCRanks.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PCRanksDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("PCRanks")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<PCRanksDbContext>();

            services.AddScoped<PCRanksSeeder>();

            services.AddScoped<IPCRanksRepository, PCRanksRepository>();
        }
    }
}
