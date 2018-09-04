using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopTest.Infra.Data.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreationDate).IsRequired();
            builder.Property(e => e.UpdateDate).IsRequired(false);
            builder.Property(a => a.TotalPrice).IsRequired();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.DiscountAmount).IsRequired(false);
            builder.Property(a => a.IsDiscountPercentage).IsRequired(false);
        }
    }
}
