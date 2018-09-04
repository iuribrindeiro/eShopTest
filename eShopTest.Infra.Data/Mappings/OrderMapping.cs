using System;
using System.Collections.Generic;
using System.Text;
using eShopTest.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopTest.Infra.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreationDate).ValueGeneratedOnAdd();
            builder.Property(o => o.Total);
            builder.Ignore(o => o.Articles);
            builder.Ignore(o => o.OrderArticles);
        }
    }
}
