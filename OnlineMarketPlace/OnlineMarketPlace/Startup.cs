using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineMarketPlace.Api.Mapping;
using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Domain.Services.cs;
using OnlineMarketPlace.Persistence.Contexts;
using OnlineMarketPlace.Persistence.Repositories;

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
            services.AddMvcCore().AddJsonFormatters();

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
