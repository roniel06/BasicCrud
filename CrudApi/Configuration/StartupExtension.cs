﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessLayer.Services;
using BussinessLayer.Services.Contracts;
using DataLayer.Context;
using DataLayer.Mappings;
using DataLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
 

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


        public static void ConfigureJwt(this IServiceCollection service, IConfiguration config)
        {
            var key = Encoding.ASCII.GetBytes(config.GetValue<string>("SecretKey"));

            service.AddAuthentication(x =>
            {
                
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(tk =>
            {
                
                tk.RequireHttpsMetadata = false;
                tk.SaveToken = true;
                tk.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection srvc)
        {
            srvc.AddSwaggerGen(x =>
            {

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey

                });
                x.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Basic CRUD",
                    Version = "v1"
                });
                //x.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
              
                //});
                List<string> files = Directory.GetFiles(System.AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                files.ForEach(xml => x.IncludeXmlComments(xml));
            });
          
        }


        public static void ConfigureAutoMapper(this IServiceCollection srvc)
        {
            srvc.AddAutoMapper(typeof(Startup));
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<Mappings>(); });
            var mapper = config.CreateMapper();
            srvc.AddSingleton(mapper);
        }

        public static void ConfigureInjections(this IServiceCollection srvc)
        {
           
            srvc.AddTransient<IPersonService, PersonService>();
            srvc.AddTransient<IApiUsersService, ApiUsersService>();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Db>(options => { options.UseSqlServer(config.GetConnectionString("MyDb")); });
        }
    }
}

