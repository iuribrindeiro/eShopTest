using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Domain.BasketAggregate;

namespace eShopTest.ApplicationService.BasketAggregate.ViewModels.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketArticle, ArticleInBasketViewModel>()
                .ForMember(vm => vm.Article, map => map.MapFrom(ba => ba.Article))
                .ForMember(vm => vm.Quantity, map => map.MapFrom(ba => ba.Quantity));
            CreateMap<Basket, BasketViewModel>()
                .ForMember(vm => vm.Articles, map => map.MapFrom(b => b.BasketArticles));
        }
    }
}
