﻿// <auto-generated />
using System;
using CDExellentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CDExellentAPI.Migrations
{
    [DbContext(typeof(ManagementDbContext))]
    [Migration("20241223035653_Add_QLKhuVuc_ChucVu_NguoiDung")]
    partial class Add_QLKhuVuc_ChucVu_NguoiDung
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CDExellentAPI.Entities.Area", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Distributor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AreaId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("SalesId")
                        .HasColumnType("int");

                    b.Property<int>("SalesManagementId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AreaId");

                    b.HasIndex("SalesManagementId");

                    b.ToTable("Distributor");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AreaId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TitleId")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AreaId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("TitleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Distributor", b =>
                {
                    b.HasOne("CDExellentAPI.Entities.Area", "Area")
                        .WithMany("Distributors")
                        .HasForeignKey("AreaId");

                    b.HasOne("CDExellentAPI.Entities.User", "SalesManagement")
                        .WithMany("Distributors")
                        .HasForeignKey("SalesManagementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("SalesManagement");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Title", b =>
                {
                    b.HasOne("CDExellentAPI.Entities.Category", "Category")
                        .WithMany("Titles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.User", b =>
                {
                    b.HasOne("CDExellentAPI.Entities.Area", "Area")
                        .WithMany("Users")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDExellentAPI.Entities.User", "Manager")
                        .WithMany("Managers")
                        .HasForeignKey("ManagerId");

                    b.HasOne("CDExellentAPI.Entities.Title", "Title")
                        .WithMany("Users")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Manager");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Area", b =>
                {
                    b.Navigation("Distributors");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Category", b =>
                {
                    b.Navigation("Titles");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.Title", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CDExellentAPI.Entities.User", b =>
                {
                    b.Navigation("Distributors");

                    b.Navigation("Managers");
                });
#pragma warning restore 612, 618
        }
    }
}
