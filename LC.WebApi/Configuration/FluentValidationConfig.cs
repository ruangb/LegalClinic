using FluentValidation.AspNetCore;
using LC.Manager.Validator;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LC.WebApi.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(p =>
             {
                 p.RegisterValidatorsFromAssemblyContaining<NewCustomerValidator>();
                 p.RegisterValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
                 p.RegisterValidatorsFromAssemblyContaining<NewAddressValidator>();
                 p.RegisterValidatorsFromAssemblyContaining<NewPhoneValidator>();
             });
        }
    }
}
