using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;

namespace eShopTest.ApplicationService.BasketAggregate.ViewModels
{
    public class BasketViewModel
    {
        public Guid Id { get; set; }
        public List<ArticleInBasketViewModel> Articles { get; set; }
        public decimal Total { get; set; }
        public decimal DeliveryFee { get; set; }
    }
}
