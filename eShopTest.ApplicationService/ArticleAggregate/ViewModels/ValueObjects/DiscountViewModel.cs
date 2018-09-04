using System.ComponentModel.DataAnnotations;

namespace eShopTest.ApplicationService.ArticleAggregate.ViewModels.ValueObjects
{
    public class DiscountViewModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool IsDiscountPercentage { get; set; }
    }
}
