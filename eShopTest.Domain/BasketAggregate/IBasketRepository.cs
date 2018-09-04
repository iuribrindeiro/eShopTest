using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.SeedWork.Pagination;
using eShopTest.Domain.SeedWork.Repository;

namespace eShopTest.Domain.BasketAggregate
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Basket GetBasket();
        Pagination<Basket> SearchWithPagination(int pageSize = 10, int pageIndex = 1);
    }
}
