using LeadTask.Application.Interfaces;
using LeadTask.Application.Mapping.DomainToDto;
using LeadTask.Application.Mapping.DtoToDomain;
using LeadTask.Application.Services;
using LeadTask.Domain.Interfaces;
using LeadTask.Infra.Data.Context;
using LeadTask.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ITaskItemRespository, TaskItemRepository>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<ITaskItemService, TaskItemService>();

           services.AddAutoMapper(typeof(DomainToDtoMapper), typeof(DtoToDomainMapper));

            return services;
        }
    }
}
