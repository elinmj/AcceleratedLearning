﻿// <auto-generated />
using System;
using DemoWithOneProject3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoWithOneProject3.Migrations
{
    [DbContext(typeof(FruitContext))]
    partial class FruitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoWithOneProject3.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("DemoWithOneProject3.Fruit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<decimal?>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Fruits");
                });

            modelBuilder.Entity("DemoWithOneProject3.FruitCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("FruitCategories");
                });

            modelBuilder.Entity("DemoWithOneProject3.FruitInBasket", b =>
                {
                    b.Property<int>("FruitId");

                    b.Property<int>("BasketId");

                    b.HasKey("FruitId", "BasketId");

                    b.HasIndex("BasketId");

                    b.ToTable("FruitInBaskets");
                });

            modelBuilder.Entity("DemoWithOneProject3.Fruit", b =>
                {
                    b.HasOne("DemoWithOneProject3.FruitCategory", "Category")
                        .WithMany("Fruits")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("DemoWithOneProject3.FruitInBasket", b =>
                {
                    b.HasOne("DemoWithOneProject3.Basket", "Basket")
                        .WithMany("FruitInBaskets")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoWithOneProject3.Fruit", "Fruit")
                        .WithMany("FruitInBaskets")
                        .HasForeignKey("FruitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
