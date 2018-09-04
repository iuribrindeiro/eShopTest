using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Domain.ArticleAggregate.Exceptions;

namespace eShopTest.Domain.BasketAggregate
{
    public class Basket
    {
        protected Basket() { }

        private IList<BasketArticle> _basketArticles;

        public Basket(IList<Article> articles)
        {
            var distinctIds = articles.Select(a => a.Id).Distinct();
            _basketArticles = distinctIds.Select(id =>
            {
                var art = articles.First(a => a.Id == id);
                return new BasketArticle(art, this, articles.Count(a => a.Id == id));
            }).ToList();
            CalculateTotal();
            CalculateDeliveryFee();
            CreationDate = DateTime.Now;
        }

        public Basket AddArticle(Article article)
        {
            UpdateDate = DateTime.Now;
            if (_basketArticles.Any(a => a.ArticleId == article.Id))
                _basketArticles.First(ba => ba.ArticleId == article.Id).AddOne();
            else
                _basketArticles.Add(new BasketArticle(article, this, 1));
            CalculateTotal();
            CalculateDeliveryFee();
            return this;
        }

        public Basket RemoveArticle(Article article)
        {
            UpdateDate = DateTime.Now;
            var basketArticle = _basketArticles.FirstOrDefault(ba => ba.ArticleId == article.Id);
            if (basketArticle == null)
                throw new ArticleIsNotInBasketException();

            if (basketArticle.Quantity == 1)
                _basketArticles.Remove(basketArticle);
            else
                basketArticle.RemoveOne();

            CalculateTotal();
            CalculateDeliveryFee();
            return this;
        }

        private void CalculateTotal()
        {
            Total = BasketArticles.Sum(a => a.Article.LiquidPrice * a.Quantity);
        }

        private void CalculateDeliveryFee()
        {
            if (Total <= 1000)
            {
                DeliveryFee = 800;
                return;
            }

            if (Total > 1000 && Total <= 2000)
            {
                DeliveryFee = 400;
                return;
            }

            DeliveryFee = 0;
        }

        public virtual IReadOnlyCollection<BasketArticle> BasketArticles => new ReadOnlyCollection<BasketArticle>(_basketArticles);
        public decimal Total { get; private set; }
        public bool IsEmpty => BasketArticles.Count == 0;
        public decimal DeliveryFee { get; private set; }
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
    }
}
