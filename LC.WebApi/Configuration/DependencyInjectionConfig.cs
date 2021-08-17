using LC.Data.Repository;
using LC.Manager.Implementation;
using LC.Manager.Interfaces.Repositories;
using LC.Manager.Interfaces.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace LC.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorManager, DoctorManager>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
        }
    }
}
