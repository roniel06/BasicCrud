﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Dtos;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IPersonService:IBaseService<Person,PersonDto>
    {
      
    }
}