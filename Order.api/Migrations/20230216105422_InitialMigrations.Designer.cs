﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order.api.Context;

#nullable disable

namespace Order.api.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230216105422_InitialMigrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Order.Models.Entity.SalesOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SalesOrders");
                });

            modelBuilder.Entity("Order.Models.Entity.SubElement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int?>("WindowID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WindowID");

                    b.ToTable("SubElements");
                });

            modelBuilder.Entity("Order.Models.Entity.Window", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityOfWindows")
                        .HasColumnType("int");

                    b.Property<int?>("SalesOrderID")
                        .HasColumnType("int");

                    b.Property<int>("TotalSubElements")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SalesOrderID");

                    b.ToTable("Windows");
                });

            modelBuilder.Entity("Order.Models.Entity.SubElement", b =>
                {
                    b.HasOne("Order.Models.Entity.Window", "WindowItem")
                        .WithMany()
                        .HasForeignKey("WindowID");

                    b.Navigation("WindowItem");
                });

            modelBuilder.Entity("Order.Models.Entity.Window", b =>
                {
                    b.HasOne("Order.Models.Entity.SalesOrder", "SalesOrderItem")
                        .WithMany()
                        .HasForeignKey("SalesOrderID");

                    b.Navigation("SalesOrderItem");
                });
#pragma warning restore 612, 618
        }
    }
}