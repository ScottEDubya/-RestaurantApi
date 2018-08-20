using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using RestaurantApi.Data;
using RestaurantApi.Reopsitories;

namespace RestaurantApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //set up db connection
            var connString = "Data Source=food.db";//Configuration["Data Source=food.db"];
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(connString);
            }, ServiceLifetime.Transient);
            services.AddScoped<IMealRepo, MealRepo>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AppDbContext appDbContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}

            //app.UseStatusCodePages();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
