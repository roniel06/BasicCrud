using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BussinessLayer.Services.Contracts;
using DataLayer.Context;
using DataLayer.Dtos;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Services
{
    public class PersonService: IPersonService
    {
        private readonly Db _db;
        private readonly IMapper _mapper;
        public PersonService(Db db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PersonDto> Create(Person entity)
        {
            try
            {
                _db.Persons.Add(entity);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<PersonDto>(entity);
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<PersonDto>> GetAll()
        {
           return await _db.Persons.ProjectTo<PersonDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PersonDto> GetById(Guid Id) => await _db.Persons
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(x => x.Id == Id);
       

        public async Task<PersonDto> Update(Person entity)
        {
            try
            {
                _db.Persons.Update(entity);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<PersonDto>(entity);
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }

        public async Task<bool> SoftDelete(Person entity)
        {
            entity.IsDeleted = true;
            _db.Update(entity);
            return await _db.SaveChangesAsync()>0;
        }

        public async Task<bool> SoftDelete(Guid entityId)
        {
            var entity = await _db.Persons.SingleOrDefaultAsync(X => X.Id == entityId);
            if (entity != null)
            {
                entity.IsDeleted = true;
                return await _db.SaveChangesAsync() > 0;
            }

            return false;



        }
    }
}
