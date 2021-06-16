using FluentValidation.AspNetCore;
using LC.Data;
using LC.Data.Repository;
using LC.Manager.Implementation;
using LC.Manager.Interfaces;
using LC.Manager.Mappings;
using LC.Manager.Validator;
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
            services.AddControllers().AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<MvCustomerValidator>());

            services.AddAutoMapper(typeof(MvCustomerMappingProfile));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();

            services.AddDbContext<LCContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LCConnection")));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Consultório Legal", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "LC V1");
            });

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
