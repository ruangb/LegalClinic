using FluentValidation.AspNetCore;
using LC.Data;
using LC.Data.Repository;
using LC.Manager.Implementation;
using LC.Manager.Interfaces;
using LC.Manager.Mappings;
using LC.Manager.Validator;
using LC.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LC.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(p => 
            {
                p.RegisterValidatorsFromAssemblyContaining<NewCustomerValidator>();
                p.RegisterValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
            });


            services.AddDbContext<LCContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LCConnection")));

            services.AddDependencyInjectionConfiguration();

            services.AddSwaggerConfiguration();

            services.AddAutoMapperConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
