using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;
using eShopTest.Domain.ArticleAggregate;

namespace eShopTest.ApplicationService.ArticleAggregate
{
    public class ArticleApplicationService : IArticleApplicationService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleApplicationService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public ArticleViewModel Update(Guid id, ArticleViewModel articleViewModel)
        {
            var article = _articleRepository.Find(id);
            _mapper.Map(articleViewModel, article);
            _articleRepository.Update(article);
            return _mapper.Map<Article, ArticleViewModel>(article);
        }

        public ArticleViewModel Create(ArticleViewModel articleViewModel)
        {
            var article = _mapper.Map<ArticleViewModel, Article>(articleViewModel);
            _articleRepository.Save(article);
            return _mapper.Map<Article, ArticleViewModel>(article);
        }

        public ArticleViewModel Get(Guid id)
        {
            return _mapper.Map<Article, ArticleViewModel>(_articleRepository.Find(id));
        }

        public PaginationViewModel<ArticleViewModel> GetArticles(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1)
        {
            return _mapper.Map<PaginationViewModel<ArticleViewModel>>(
                _articleRepository.SearchWithPagination(valueOfAnyTextField, pageSize, pageIndex));
        }
    }
}
