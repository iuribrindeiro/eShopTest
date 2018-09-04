using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;

namespace eShopTest.ApplicationService.ArticleAggregate
{
    public interface IArticleApplicationService
    {
        ArticleViewModel Update(Guid id, ArticleViewModel articleViewModel);
        ArticleViewModel Create(ArticleViewModel articleViewModel);
        ArticleViewModel Get(Guid id);
        PaginationViewModel<ArticleViewModel> GetArticles(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1);
    }
}
