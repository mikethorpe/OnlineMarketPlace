using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineMarketPlace.Api.Mapping;
using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Domain.Services;
using OnlineMarketPlace.Persistence.Contexts;
using OnlineMarketPlace.Persistence.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace OnlineMarketPlace
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add only core mvc services required for web api
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddApiExplorer();

            // Configure swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OnlineMarketPlace API",
                    Version = "v1",
                    Description = "A simple online market place API"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Configure the db connection
            services.AddDbContext<OnlineMarketPlaceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OnlineMarketPlaceDb")));

            // Register services for dependency injection
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDtoMapper, DtoMapper>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable swagger middleware
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineMarktPlace V1");
                });

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
