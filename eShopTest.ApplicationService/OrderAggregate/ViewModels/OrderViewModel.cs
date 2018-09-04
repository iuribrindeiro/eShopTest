using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.ApplicationService.BasketAggregate.ViewModels;

namespace eShopTest.ApplicationService.OrderAggregate.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public IList<ArticleViewModel> Items { get; set; }
        public decimal Total { get; set; }
    }
}
