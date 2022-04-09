using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApiService.Interface;
using ShoppingApiService.Implementation;
using ShoppingApiRepository.Interface;
using ShoppingApiRepository.Implementation;
using ShoppingApiRepository.SqlEntity;
using ShoppingApiRepository;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ShoppingApiService;
using MongoDB.Driver;

namespace OnlineShoppingApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Shopping API",
                    Version = "v1"
                });
            });
            services.AddAutoMapper(typeof(Automapping));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISqlProductRepository, SqlProductRepository>();
            services.AddDbContext<SqlDbContext>(
                item => item.UseMySQL(Configuration.GetConnectionString("SqlDb"),
                sql => sql.MigrationsAssembly("ShoppingApiRepository")),
                ServiceLifetime.Transient
            );
            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(Configuration.GetConnectionString("MongoDb")));

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
