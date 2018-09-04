using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.ArticleAggregate;

namespace eShopTest.Domain.OrderAggregate
{
    public class OrderArticle
    {
        protected OrderArticle() { }

        public OrderArticle(Article article, Order order, int quantity)
        {
            OrderId = order.Id;
            ArticleId = article.Id;
            Order = order;
            Article = article;
            Quantity = quantity;
        }

        public void AddOne()
        {
            Quantity++;
        }

        public Guid OrderId { get; private set; }
        public Guid ArticleId { get; private set; }
        public Article Article { get; private set; }
        public Order Order { get; private set; }
        public decimal Quantity { get; private set; }
    }
}
