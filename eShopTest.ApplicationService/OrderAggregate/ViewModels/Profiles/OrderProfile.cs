using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Domain.BasketAggregate;
using eShopTest.Domain.OrderAggregate;

namespace eShopTest.ApplicationService.OrderAggregate.ViewModels.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(vm => vm.Items, map => map.MapFrom(o => o.Articles));
        }
    }
}
