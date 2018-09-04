using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.SeedWork.UnitOfWork;
using eShopTest.Infra.Data.Context;

namespace eShopTest.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void CommitTransaction()
        {
            _applicationContext.SaveChanges();
        }
    }
}
