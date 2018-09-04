using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AutoMapper;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.ApplicationService.BasketAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Domain.BasketAggregate;
using eShopTest.Domain.SeedWork.Exception;

namespace eShopTest.ApplicationService.BasketAggregate
{
    public class BasketApplicationService : IBasketApplicationService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public BasketApplicationService(IBasketRepository basketRepository, IArticleRepository articleRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public void AddArticle(Guid? basketId, Guid articleId)
        {
            Basket basket = null;
            var article = _articleRepository.Find(articleId);
            try
            {
                if (basketId == null)
                    basket = _basketRepository.GetBasket();
                else
                    basket = _basketRepository.Find((Guid)basketId);

                basket.AddArticle(article);
            }
            catch (EntityNotFoundException entity)
            {
                _basketRepository.Save(new Basket(new List<Article>() {article}));
            }
        }

        public void RemoveArticle(Guid basketId, Guid articleId)
        {
            var article = _articleRepository.Find(articleId);
            var basket = _basketRepository.Find(basketId);
            basket.RemoveArticle(article);

            if (basket.IsEmpty)
            {
                _basketRepository.Delete(basket.Id);
                return;
            }

            _basketRepository.Update(basket);
        }

        public BasketViewModel Get(Guid basketId)
        {
            return _mapper.Map<Basket, BasketViewModel>(_basketRepository.Find(basketId));
        }

        public PaginationViewModel<BasketViewModel> GetBaskts(int pageSize = 10, int pageIndex = 1)
        {
            return _mapper.Map<PaginationViewModel<BasketViewModel>>(
                _basketRepository.SearchWithPagination(pageSize, pageIndex));
        }
    }
}
