﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdnCategories.Models;

namespace ProdnCategories.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProdnCategories.Models.Association", b =>
                {
                    b.Property<int>("association_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("category_id");

                    b.Property<int>("product_id");

                    b.HasKey("association_id");

                    b.HasIndex("category_id");

                    b.HasIndex("product_id");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("ProdnCategories.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<DateTime>("updated_at");

                    b.HasKey("category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProdnCategories.Models.Product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<decimal>("price");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("product_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProdnCategories.Models.Association", b =>
                {
                    b.HasOne("ProdnCategories.Models.Category", "category")
                        .WithMany("Associations")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProdnCategories.Models.Product", "product")
                        .WithMany("Associations")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
