using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.SeedWork.Pagination;
using eShopTest.Domain.SeedWork.Repository;

namespace eShopTest.Domain.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Pagination<Order> SearchWithPagination(int pageSize = 10, int pageIndex = 1);
    }
}
