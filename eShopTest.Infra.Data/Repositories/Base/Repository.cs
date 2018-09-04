using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopTest.Domain.SeedWork.Exception;
using eShopTest.Domain.SeedWork.Pagination;
using eShopTest.Domain.SeedWork.Repository;
using eShopTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace eShopTest.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class 
    {
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context) => _context = context;

        public void Save(T entity)
        {
            _context.Add<T>(entity);
        }

        public void Update(T entity)
        {
            var local = _context.Set<T>().Local.FirstOrDefault(entry => entry.Equals(entity));
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var entity = _context.Set<T>().Find(id);

            if (entity == null)
                throw new EntityNotFoundException();

            _context.Set<T>().Remove(entity);
        }

        public virtual T Find(Guid id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
                throw new EntityNotFoundException();

            return entity;
        }

        public Pagination<T> SearchWithPagination(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1)
        {
            var query = _context.Set<T>().AsQueryable<T>().Concat(QueryForGenericPagination(valueOfAnyTextField));
            return new Pagination<T>(query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                query.Count(), pageIndex, pageSize);
        }

        protected abstract IQueryable<T> QueryForGenericPagination(string valueOfAnyTextField);
    }
}
