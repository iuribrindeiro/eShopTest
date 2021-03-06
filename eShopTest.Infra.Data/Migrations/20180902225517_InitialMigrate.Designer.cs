﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShopTest.Infra.Data.Context;

namespace eShopTest.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180902225517_InitialMigrate")]
    partial class InitialMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eShopTest.Domain.ArticleAggregate.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<decimal?>("DiscountAmount");

                    b.Property<bool?>("IsDiscountPercentage");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("TotalPrice");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("eShopTest.Domain.BasketAggregate.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<decimal>("DeliveryFee");

                    b.Property<decimal>("Total");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("eShopTest.Domain.BasketAggregate.BasketArticle", b =>
                {
                    b.Property<Guid>("ArticleId");

                    b.Property<Guid>("BasketId");

                    b.Property<int>("Quantity");

                    b.HasKey("ArticleId", "BasketId");

                    b.HasIndex("BasketId");

                    b.ToTable("BasketArticle");
                });

            modelBuilder.Entity("eShopTest.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eShopTest.Domain.OrderAggregate.OrderArticle", b =>
                {
                    b.Property<Guid>("ArticleId");

                    b.Property<Guid>("OrderId");

                    b.Property<decimal>("Quantity");

                    b.HasKey("ArticleId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderArticle");
                });

            modelBuilder.Entity("eShopTest.Domain.BasketAggregate.BasketArticle", b =>
                {
                    b.HasOne("eShopTest.Domain.ArticleAggregate.Article", "Article")
                        .WithMany("_basketArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eShopTest.Domain.BasketAggregate.Basket", "Basket")
                        .WithMany("_basketArticles")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eShopTest.Domain.OrderAggregate.OrderArticle", b =>
                {
                    b.HasOne("eShopTest.Domain.ArticleAggregate.Article", "Article")
                        .WithMany("_ordersArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eShopTest.Domain.OrderAggregate.Order", "Order")
                        .WithMany("_ordersArticles")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
