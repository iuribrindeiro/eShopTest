using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.ApplicationService.BasketAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;

namespace eShopTest.ApplicationService.BasketAggregate
{
    public interface IBasketApplicationService
    {
        void AddArticle(Guid? basketId, Guid articleId);
        void RemoveArticle(Guid basketId, Guid articleId);
        BasketViewModel Get(Guid basketId);
        PaginationViewModel<BasketViewModel> GetBaskts(int pageSize = 10, int pageIndex = 1);
    }
}
