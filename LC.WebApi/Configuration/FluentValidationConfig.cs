using FluentValidation.AspNetCore;
using LC.Manager.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace LC.WebApi.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(p =>
             {
                 p.RegisterValidatorsFromAssemblyContaining<NewCustomerValidator>();
                 p.RegisterValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
             });
        }
    }
}
