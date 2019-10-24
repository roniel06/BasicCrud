using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
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

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Db>(options => { options.UseSqlServer(config.GetConnectionString("MyDb")); });
        }
    }
}

