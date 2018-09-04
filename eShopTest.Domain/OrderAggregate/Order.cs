using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Domain.BasketAggregate;

namespace eShopTest.Domain.OrderAggregate
{
    public class Order
    {
        private IList<OrderArticle> _ordersArticles;

        protected Order() { }

        public Order(Basket basket)
        {
            CreationDate = DateTime.Now;
            _ordersArticles = basket.BasketArticles.Select(a => new OrderArticle(a.Article, this, a.Quantity)).ToList();
            Total = basket.Total + basket.DeliveryFee;
        }

        public virtual IReadOnlyCollection<Article> Articles => new ReadOnlyCollection<Article>(_ordersArticles.Select(a => a.Article).ToList());
        public virtual IReadOnlyCollection<OrderArticle> OrderArticles => new ReadOnlyCollection<OrderArticle>(_ordersArticles);
        public bool IsEmpty => Articles.Count == 0;
        public decimal Total { get; private set; }
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
