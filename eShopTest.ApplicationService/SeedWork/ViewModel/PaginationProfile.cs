using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using eShopTest.Domain.SeedWork.Pagination;

namespace eShopTest.ApplicationService.SeedWork.ViewModel
{
    public class PaginationProfile : Profile
    {
        public PaginationProfile()
        {
            CreateMap(typeof(Pagination<>), typeof(PaginationViewModel<>)).ForMember("Items", opt =>
            {
                opt.MapFrom(s => s);
            });
        }
    }
}
