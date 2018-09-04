using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopTest.Domain.ArticleAggregate;
using eShopTest.Domain.BasketAggregate;
using eShopTest.Domain.OrderAggregate;
using eShopTest.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace eShopTest.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            modelBuilder.ApplyConfiguration(new BasketMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new OrderArticleKeyMapping());
            modelBuilder.ApplyConfiguration(new OrderArticleOrderMapping());
            modelBuilder.ApplyConfiguration(new OrderArticleArticleMapping());
            modelBuilder.ApplyConfiguration(new BasketArticleKeyMapping());
            modelBuilder.ApplyConfiguration(new BasketArticleBasketArticle());
            modelBuilder.ApplyConfiguration(new BasketArticleBasketMapping());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
