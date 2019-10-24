using System;
using System.Collections.Generic;
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
   public  class ArticlesService:IArticleService
    {

        private readonly Db _db;
        private readonly IMapper _mapper;
        public ArticlesService(Db db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ArticleDto> Create(Articles entity)
        {
            try
            {
                _db.Articles.Add(entity);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<ArticleDto>(entity);
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<ArticleDto>> GetAll()
        {
            return await _db.Persons.ProjectTo<ArticleDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ArticleDto> GetById(Guid Id) => await _db.Persons
            .ProjectTo<ArticleDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(x => x.Id == Id);


        public async Task<ArticleDto> Update(Articles entity)
        {
            try
            {
                _db.Articles.Update(entity);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<ArticleDto>(entity);
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> SoftDelete(Articles entity)
        {
            entity.IsDeleted = true;
            _db.Update(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftDelete(Guid entityId)
        {
            var entity = await _db.Articles.SingleOrDefaultAsync(X => X.Id == entityId);
            if (entity != null)
            {
                entity.IsDeleted = true;
                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
