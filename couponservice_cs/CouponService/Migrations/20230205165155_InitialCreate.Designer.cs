﻿// <auto-generated />
using System;
using CouponService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CouponService.Migrations
{
    [DbContext(typeof(CServiceContext))]
    [Migration("20230205165155_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CouponService.Models.Cupon", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("delete")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("discount")
                        .HasColumnType("int");

                    b.Property<bool>("issued")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("minPrice")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("type")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Cupons");
                });

            modelBuilder.Entity("CouponService.Models.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CouponService.Models.UserCupon", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("Cuponid")
                        .HasColumnType("bigint");

                    b.Property<long?>("Userid")
                        .HasColumnType("bigint");

                    b.Property<bool>("used")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.HasIndex("Cuponid");

                    b.HasIndex("Userid");

                    b.ToTable("userCupon");
                });

            modelBuilder.Entity("CouponService.Models.UserCupon", b =>
                {
                    b.HasOne("CouponService.Models.Cupon", null)
                        .WithMany("userCupons")
                        .HasForeignKey("Cuponid");

                    b.HasOne("CouponService.Models.User", null)
                        .WithMany("userCupons")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("CouponService.Models.Cupon", b =>
                {
                    b.Navigation("userCupons");
                });

            modelBuilder.Entity("CouponService.Models.User", b =>
                {
                    b.Navigation("userCupons");
                });
#pragma warning restore 612, 618
        }
    }
}
