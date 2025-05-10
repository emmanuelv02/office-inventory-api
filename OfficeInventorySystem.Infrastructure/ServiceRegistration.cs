

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeInventorySystem.Application.Interfaces;
using OfficeInventorySystem.Application.Services;
using OfficeInventorySystem.Domain.Interfaces;
using OfficeInventorySystem.Persistence;
using OfficeInventorySystem.Persistence.Repositories;

namespace OfficeInventorySystem.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DBContext
            services.AddDbContext<DbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Services
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IMaintenanceTaskService, MaintenanceTaskService>();
            services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();


            // Repos
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
