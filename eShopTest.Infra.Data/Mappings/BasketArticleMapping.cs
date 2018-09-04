using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopTest.Infra.Data.Mappings
{
    public class BasketArticleKeyMapping : IEntityTypeConfiguration<BasketArticle>
    {
        public void Configure(EntityTypeBuilder<BasketArticle> builder)
        {
            builder.HasKey(oa => new { oa.ArticleId, oa.BasketId });
            builder.Property(oa => oa.Quantity).IsRequired();
        }
    }

    public class BasketArticleBasketMapping : IEntityTypeConfiguration<BasketArticle>
    {
        public void Configure(EntityTypeBuilder<BasketArticle> builder)
        {
            builder.HasOne(oa => oa.Basket)
                .WithMany("_basketArticles")
                .HasForeignKey(oa => oa.BasketId);
        }
    }

    public class BasketArticleBasketArticle : IEntityTypeConfiguration<BasketArticle>
    {
        public void Configure(EntityTypeBuilder<BasketArticle> builder)
        {
            builder.HasOne(oa => oa.Article)
                .WithMany("_basketArticles")
                .HasForeignKey(oa => oa.ArticleId);
        }
    }
}
