using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopTest.Infra.Data.Mappings
{
    public class BasketMapping : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Baskets");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreationDate).IsRequired();
            builder.Property(e => e.UpdateDate).IsRequired(false);
            builder.Ignore(b => b.BasketArticles);
            builder.Property(b => b.DeliveryFee).IsRequired();
            builder.Property(b => b.Total).IsRequired();
        }
    }
}
