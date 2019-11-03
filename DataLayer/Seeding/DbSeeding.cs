using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Context;
using DataLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Seeding
{
   public static  class  DbSeeding
    {

        public static void SeedDb(IApplicationBuilder builder)
        {
            using (var svcScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                Db context = svcScope.ServiceProvider.GetService<Db>();

                if (!context.ApiUsers.Any())
                {
                    context.ApiUsers.Add(new ApiUsers
                    {
                        ClientName = "Roniel Polanco",
                        UserName = "Rpolanco",
                        Password = Convert.ToBase64String(Encoding.ASCII.GetBytes("RP1234@!")),
                        CreatedBy = "DataSeed",
                        Email = "roniel06.rc@gmail.com"
                        
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
