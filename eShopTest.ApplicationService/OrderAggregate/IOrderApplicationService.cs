using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.ApplicationService.OrderAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;

namespace eShopTest.ApplicationService.OrderAggregate
{
    public interface IOrderApplicationService
    {
        OrderViewModel Create(Guid basketId);
        PaginationViewModel<OrderViewModel> GetOrders(int pageSize = 10, int pageIndex = 1);
        OrderViewModel Get(Guid id);
    }
}
