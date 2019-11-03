using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Dtos;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IApiUsersService
    {
        Task<bool> UserDidExist(ApiUsers entity);
    }
}
