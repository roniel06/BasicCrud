using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinessLayer.Services;
using BussinessLayer.Services.Contracts;
using DataLayer.Context;
using DataLayer.Mappings;
using DataLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrudApi.Configuration
{
    public static class StartupExtension
    {


        public static void ConfigureCors(this IServiceCollection srvc) => srvc.AddCors(x =>
        {
            x.AddPolicy("AllowOrigin", builder => builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials()
            );
        });


        public static void ConfigureAutoMapper(this IServiceCollection srvc)
        {
            srvc.AddAutoMapper(typeof(Startup));
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<Mappings>(); });
            var mapper = config.CreateMapper();
            srvc.AddSingleton(mapper);
        }

        public static void ConfigureInjections(this IServiceCollection srvc)
        {
            srvc.AddTransient<IArticleService, ArticlesService>();
            srvc.AddTransient<IPersonService, PersonService>();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Db>(options => { options.UseSqlServer(config.GetConnectionString("MyDb")); });
        }
    }
}

