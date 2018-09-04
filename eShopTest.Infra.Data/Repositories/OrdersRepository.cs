using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopTest.Domain.OrderAggregate;
using eShopTest.Domain.SeedWork.Exception;
using eShopTest.Domain.SeedWork.Pagination;
using eShopTest.Infra.Data.Context;
using eShopTest.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace eShopTest.Infra.Data.Repositories
{
    public class OrdersRepository : Repository<Order>, IOrderRepository
    {
        public OrdersRepository(ApplicationContext context) : base(context)
        {
        }

        protected override IQueryable<Order> QueryForGenericPagination(string valueOfAnyTextField)
        {
            return _context.Orders;
        }

        public Pagination<Order> SearchWithPagination(int pageSize = 10, int pageIndex = 1)
        {
            var query = _context.Orders.Skip((pageIndex - 1) * pageSize).Take(pageSize).Include("_ordersArticles");
            var orders = query.ToList();
            //to load the articles from db, since ThenInclude from EF is not working as expected
            orders.ForEach(b => b.OrderArticles.ToList().ForEach(oa => _context.Articles.Find(oa.ArticleId)));

            return new Pagination<Order>(query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                query.Count(), pageIndex, pageSize);
        }

        public Order Find(Guid id)
        {
            var order = _context.Orders.Include("_ordersArticles").FirstOrDefault(o => o.Id == id);
            if (order == null)
                throw new EntityNotFoundException();

            order.OrderArticles.ToList().ForEach(oa => _context.Articles.Find(oa.ArticleId));

            return order;
        }
    }
}
