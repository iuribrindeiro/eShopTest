using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Infra.Data.Context;
using eShopTest.Infra.Data.Repositories.Base;

namespace eShopTest.Infra.Data.Repositories
{
    public class ArticlesRepository : Repository<Article>, IArticleRepository
    {
        public ArticlesRepository(ApplicationContext context) : base(context) {}

        protected override IQueryable<Article> QueryForGenericPagination(string valueOfAnyTextField)
        {
            return _context.Articles.Where(a => a.Name.Contains(valueOfAnyTextField));
        }
    }
}
