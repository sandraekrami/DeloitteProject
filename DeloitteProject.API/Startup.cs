using System;
using DeloitteProject.DataAccess;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using DeloitteProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DeloitteProject.API
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "https://deloittestoragesandra.z16.web.core.windows.net");
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Deloitte API",
                        Version = "v1",
                        Description = "API responsible of retrieving Deloitte Data"
                    });
            });
            services.AddSingleton<IGetAllHotelsQuery, GetAllHotelsQuery>();
            services.AddScoped<KeywordFilter>();
            services.AddScoped<NameFilter>();
            services.AddScoped<RatingFilter>();

            services.AddTransient<Func<FilterType, IFilterService>>(serviceProvider => filterType =>
            {
                switch (filterType)
                {
                    case FilterType.Keyword:
                        return serviceProvider.GetService<KeywordFilter>();

                    case FilterType.Rating:
                        return serviceProvider.GetService<RatingFilter>();

                    default:
                        return serviceProvider.GetService<NameFilter>();
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", "Deloitte API"); });

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
