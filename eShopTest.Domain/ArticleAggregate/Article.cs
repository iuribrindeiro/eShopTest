using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.BasketAggregate;
using eShopTest.Domain.OrderAggregate;

namespace eShopTest.Domain.ArticleAggregate
{
    public class Article
    {
        private IList<OrderArticle> _ordersArticles;
        private IList<BasketArticle> _basketArticles;

        protected Article() { }

        public Article(string name, decimal price, decimal? discountAmount, bool? isDiscountPercentage)
        {
            CreationDate = DateTime.Now;
            Name = name;
            TotalPrice = price;

            if (discountAmount != null)
                AddDiscount((decimal)discountAmount, isDiscountPercentage);
        }

        private Article AddDiscount(decimal discountAmount, bool? isDiscountPercentage)
        {
            DiscountAmount = discountAmount;
            IsDiscountPercentage = isDiscountPercentage;
            return this;
        }

        public Article Update(string name, decimal price, decimal? discountAmount, bool? isDiscountPercentage)
        {
            UpdateDate = DateTime.Now;
            Name = name;
            TotalPrice = price;

            if (discountAmount != null)
                AddDiscount((decimal)discountAmount, isDiscountPercentage);
            return this;
        }

        public string Name { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal? DiscountAmount { get; private set; }
        public bool? IsDiscountPercentage { get; private set; }

        public virtual decimal LiquidPrice
        {
            get
            {
                if (DiscountAmount == null)
                    return TotalPrice;

                if ((bool)IsDiscountPercentage)
                    return TotalPrice - TotalPrice * ((decimal)DiscountAmount / 100);

                return TotalPrice - (decimal)DiscountAmount;
            }
        }

        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
    }
}
