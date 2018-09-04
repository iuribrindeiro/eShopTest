using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopTest.Domain.BasketAggregate;
using eShopTest.Domain.SeedWork.Exception;
using eShopTest.Domain.SeedWork.Pagination;
using eShopTest.Infra.Data.Context;
using eShopTest.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace eShopTest.Infra.Data.Repositories
{
    public class BasketsRepository : Repository<Basket>, IBasketRepository
    {
        public BasketsRepository(ApplicationContext context) : base(context)
        {
        }

        protected override IQueryable<Basket> QueryForGenericPagination(string valueOfAnyTextField)
        {
            return _context.Baskets;
        }

        public override Basket Find(Guid id)
        {
            var basket = _context.Baskets.FirstOrDefault(b => b.Id == id);
            if (basket == null)
                throw new EntityNotFoundException();

            _context.Entry(basket).Collection("_basketArticles").Load();
            //to load the articles from db, since ThenInclude from EF is not working as expected
            basket.BasketArticles.ToList().ForEach(ba => _context.Articles.Find(ba.ArticleId));

            return basket;
        }

        public Basket GetBasket()
        {
            var basket = _context.Baskets.FirstOrDefault();
            if (basket == null)
                throw new EntityNotFoundException();

            _context.Entry(basket).Collection("_basketArticles").Load();
            //to load the articles from db, since ThenInclude from EF is not working as expected
            basket.BasketArticles.ToList().ForEach(ba => _context.Articles.Find(ba.ArticleId));

            return basket;
        }

        public Pagination<Basket> SearchWithPagination(int pageSize = 10, int pageIndex = 1)
        {
            var query = _context.Baskets.Skip((pageIndex - 1) * pageSize).Take(pageSize).Include("_basketArticles");
            var baskets = query.ToList();

            //to load the articles from db, since ThenInclude from EF is not working as expected
            baskets.ForEach(b => b.BasketArticles.ToList().ForEach(ba => _context.Articles.Find(ba.ArticleId)));

            return new Pagination<Basket>(baskets,
                query.Count(), pageIndex, pageSize);
        }
    }
}
