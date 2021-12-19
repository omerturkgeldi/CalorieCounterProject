using CalorieCounterProject.API.Extensions;
using CalorieCounterProject.API.Filters;
using CalorieCounterProject.Core.Repositories;
using CalorieCounterProject.Core.Services;
using CalorieCounterProject.Core.UnitOfWorks;
using CalorieCounterProject.Data;
using CalorieCounterProject.Data.Repositories;
using CalorieCounterProject.Data.UnitOfWorks;
using CalorieCounterProject.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.API
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
            services.AddAutoMapper(typeof(Startup));
            //services.AddScoped<ProductNotFoundFilter>();
            //services.AddScoped<FoodNotFoundFilter>();
            //services.AddScoped<ActivityNotFoundFilter>();

            services.AddScoped(typeof(GenericNotFoundFilter<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Services
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IActivityService, ActivityService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"), o =>
                    {
                        o.MigrationsAssembly("CalorieCounterProject.Data");
                    });
                //Configuration["ConnectionStrings:SqlConStr"].ToString();
            });


            services.AddControllers(o =>
            {
                o.Filters.Add(new ValidationFilter());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalorieCounterProject.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalorieCounterProject.API v1"));
            }

            app.UseCustomException();

            app.UseCors(options =>
          options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());

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
