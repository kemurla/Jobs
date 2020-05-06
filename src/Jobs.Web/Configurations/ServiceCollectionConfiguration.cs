using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Jobs.Data;
using Jobs.Business.Services;
using Jobs.Core.Abstractions.Services;

namespace Jobs.Web.Configurations
{
    public static class ServiceCollectionConfiguration
    {
        /// <summary>
        /// Registers the services into the DI container.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services)
        {
            ThrowIfNulLServices(services);

            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IRoomService, RoomService>();
        }

        /// <summary>
        /// Configures the EF DbContext with a given connection string.
        /// </summary>
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            ThrowIfNulLServices(services);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<DemoDbContext>(options =>
            {
                options.EnableDetailedErrors();
                options.UseSqlServer(connectionString);
            });
        }

        private static void ThrowIfNulLServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
        }
    }
}
