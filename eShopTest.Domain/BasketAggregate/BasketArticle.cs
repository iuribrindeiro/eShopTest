using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.ArticleAggregate;

namespace eShopTest.Domain.BasketAggregate
{
    public class BasketArticle
    {
        protected BasketArticle() { }

        public BasketArticle(Article article, Basket basket, int quantity)
        {
            BasketId = basket.Id;
            ArticleId = article.Id;
            Basket = basket;
            Article = article;
            Quantity = quantity;
        }

        public void AddOne()
        {
            Quantity++;
        }

        public void RemoveOne()
        {
            Quantity--;
        }

        public Guid BasketId { get; private set; }
        public int Quantity { get; private set; }
        public Guid ArticleId { get; private set; }
        public Article Article { get; private set; }
        public Basket Basket { get; private set; }
    }
}
