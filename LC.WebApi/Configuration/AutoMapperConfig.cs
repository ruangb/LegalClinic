using LC.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace LC.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NewCustomerMappingProfile), typeof(UpdateCustomerMappingProfile));
        }
    }
}
