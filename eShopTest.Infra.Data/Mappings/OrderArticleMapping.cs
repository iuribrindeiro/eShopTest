using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopTest.Infra.Data.Mappings
{
    public class OrderArticleKeyMapping : IEntityTypeConfiguration<OrderArticle>
    {
        public void Configure(EntityTypeBuilder<OrderArticle> builder)
        {
            builder.HasKey(oa => new { oa.ArticleId, oa.OrderId });
            builder.Property(oa => oa.Quantity).IsRequired();
        }
    }

    public class OrderArticleOrderMapping : IEntityTypeConfiguration<OrderArticle>
    {
        public void Configure(EntityTypeBuilder<OrderArticle> builder)
        {
            builder.HasOne(oa => oa.Order)
                .WithMany("_ordersArticles")
                .HasForeignKey(oa => oa.OrderId);
        }
    }

    public class OrderArticleArticleMapping : IEntityTypeConfiguration<OrderArticle>
    {
        public void Configure(EntityTypeBuilder<OrderArticle> builder)
        {
            builder.HasOne(oa => oa.Article)
                .WithMany("_ordersArticles")
                .HasForeignKey(oa => oa.ArticleId);
        }
    }
}
