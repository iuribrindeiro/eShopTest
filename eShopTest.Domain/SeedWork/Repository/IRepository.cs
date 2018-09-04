using eShopTest.Domain.SeedWork.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTest.Domain.SeedWork.Repository
{
    public interface IRepository<T> where T : class
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T Find(Guid id);
        Pagination<T> SearchWithPagination(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1);
    }
}
