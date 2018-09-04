using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.SeedWork.Exception;

namespace eShopTest.Domain.ArticleAggregate.Exceptions
{
    public class ArticleIsNotInBasketException : AbstractException
    {
        public ArticleIsNotInBasketException() : base("The article you tried to remove is not in the basket")
        {
        }
    }
}
