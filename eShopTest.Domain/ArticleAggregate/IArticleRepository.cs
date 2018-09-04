using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.SeedWork.Repository;

namespace eShopTest.Domain.ArticleAggregate
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}
