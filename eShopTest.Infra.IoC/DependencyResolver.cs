using System;
using AutoMapper;
using eShopTest.ApplicationService.ArticleAggregate;
using eShopTest.ApplicationService.BasketAggregate;
using eShopTest.ApplicationService.OrderAggregate;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Domain.BasketAggregate;
using eShopTest.Domain.OrderAggregate;
using eShopTest.Domain.SeedWork.UnitOfWork;
using eShopTest.Infra.Data.Context;
using eShopTest.Infra.Data.Repositories;
using eShopTest.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopTest.Infra.IoC
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper();
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(configuration.GetSection("ConnectionString").Value))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IArticleRepository, ArticlesRepository>()
                .AddScoped<IOrderRepository, OrdersRepository>()
                .AddScoped<IBasketRepository, BasketsRepository>()
                .AddTransient<IArticleApplicationService, ArticleApplicationService>()
                .AddTransient<IOrderApplicationService, OrderApplicationService>()
                .AddTransient<IBasketApplicationService, BasketApplicationService>();
        }
    }
}
