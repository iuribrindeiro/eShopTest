using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels.ValueObjects;
using eShopTest.Domain.ArticleAggregate;

namespace eShopTest.ApplicationService.ArticleAggregate.ViewModels.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleViewModel>()
                .ForMember(a => a.Id, map => map.MapFrom(a => a.Id))
                .ForMember(a => a.Price, map => map.MapFrom(a => a.TotalPrice))
                .ForMember(a => a.Discount, map => map.Condition(a => a.DiscountAmount != null))
                .ForMember(a => a.Discount, map => map.MapFrom(a => new { Amount = a.DiscountAmount, IsDiscountPercentage = a.IsDiscountPercentage }));
            CreateMap<ArticleViewModel, Article>()
                .ConstructUsing(vm =>
                    {
                        return new Article(vm.Name, vm.Price, vm?.Discount?.Amount, vm?.Discount?.IsDiscountPercentage);
                    })
                .AfterMap((src, dest) =>
                    {
                        if (dest.Id != Guid.Empty)
                            dest.Update(src.Name, src.Price, src?.Discount?.Amount, src?.Discount?.IsDiscountPercentage);
                    })
                .ForAllMembers(opt => opt.Ignore());
        }
    }
}
