using FluentValidation.AspNetCore;
using LC.Manager.Validator;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace LC.WebApi.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(p => 
                {
                    p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(p =>
                 {
                     p.RegisterValidatorsFromAssemblyContaining<NewCustomerValidator>();
                     p.RegisterValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
                     p.RegisterValidatorsFromAssemblyContaining<NewAddressValidator>();
                     p.RegisterValidatorsFromAssemblyContaining<NewPhoneValidator>();
                     p.RegisterValidatorsFromAssemblyContaining<NewDoctorValidator>();
                     p.RegisterValidatorsFromAssemblyContaining<UpdateDoctorValidator>();
                 });
        }
    }
}
