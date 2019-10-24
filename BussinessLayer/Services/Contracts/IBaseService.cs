using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Contracts
{
    public interface IBaseService<TIn,TOut> where TIn: class where TOut: class
    {
        Task<TOut> Create(TIn entity);


        Task<List<TOut>> GetAll();

        Task<TOut> GetById(Guid Id);

        Task<TOut> Update(TIn entity);

        Task<bool> SoftDelete(TIn entity);

        Task<bool> SoftDelete(Guid entityId);

    }
}