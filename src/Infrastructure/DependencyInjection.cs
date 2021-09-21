﻿namespace Exemplum.Infrastructure
{
    using Application.Common.DomainEvents;
    using Application.Persistence;
    using DateAndTime;
    using Domain.Common.DateAndTime;
    using DomainEvents;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Persistence.ExceptionHandling;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {
            if (configuration.UseInMemoryDatabase())
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("Exemplum"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options => 
                    options.UseSqlServer(configuration.GetDefaultConnection(),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
            services.AddScoped<IEventHandlerDbContext>(provider => provider.GetService<ApplicationDbContext>()!);

            services.AddTransient<IHandleDbExceptions, HandleDbExceptions>();
            services.AddTransient<IPublishDomainEvents, DomainEventsPublisher>();
            services.AddTransient<IClock, Clock>();
            
            return services;
        }
    }
}