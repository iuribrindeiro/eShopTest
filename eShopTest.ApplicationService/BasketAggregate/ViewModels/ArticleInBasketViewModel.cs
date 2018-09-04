using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;

namespace eShopTest.ApplicationService.BasketAggregate.ViewModels
{
    public class ArticleInBasketViewModel
    {
        public ArticleViewModel Article { get; set; }
        public int Quantity { get; set; }
    }
}
