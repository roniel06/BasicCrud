using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Context;
using DataLayer.Dtos;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Services
{
    public class ApiUsersService:IApiUsersService
    {
        private readonly Db _context;
        public ApiUsersService(Db context)
        {
            _context = context;
        }


        public async Task<bool> UserDidExist(ApiUsers entity) => await _context.ApiUsers.AnyAsync(x =>
            x.UserName == entity.UserName && x.Password == ConvertPassword(entity.Password));

        public string ConvertPassword(string pass)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(pass));
        }
    }
}
