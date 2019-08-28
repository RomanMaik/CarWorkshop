using Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    public interface IBaseRepository<T> where T : class,new()
    {
        StatusDto Add(T model);
        void Update(T model);
        void Delete(T model);
        List<T> GetAll();
        T Get(Func<T, bool> predicate);
    }
}
