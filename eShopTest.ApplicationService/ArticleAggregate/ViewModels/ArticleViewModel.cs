using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels.ValueObjects;

namespace eShopTest.ApplicationService.ArticleAggregate.ViewModels
{
    public class ArticleViewModel
    {
        [ReadOnly(true)] public Guid? Id { get; set; } = null;

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DiscountViewModel Discount { get; set; } = null;

        [ReadOnly(true)] public decimal? LiquidPrice { get; set; } = null;
    }
}
