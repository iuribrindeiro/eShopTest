using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTest.Domain.SeedWork.UnitOfWork
{
    public interface IUnitOfWork
    {
        void CommitTransaction();
    }
}
