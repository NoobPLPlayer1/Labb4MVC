﻿// <auto-generated />
using System;
using Labb4MVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4MVC.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20220515212218_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Labb4MVC.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BookTypeISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BookTypeISBN");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Labb4MVC.Models.BookType", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ISBN");

                    b.ToTable("BookTypes");
                });

            modelBuilder.Entity("Labb4MVC.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<long>("PostCode")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Labb4MVC.Models.LendPeriod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("HasBook")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("CustomerID");

                    b.ToTable("LendPeriods");
                });

            modelBuilder.Entity("Labb4MVC.Models.Book", b =>
                {
                    b.HasOne("Labb4MVC.Models.BookType", "BookType")
                        .WithMany("Books")
                        .HasForeignKey("BookTypeISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookType");
                });

            modelBuilder.Entity("Labb4MVC.Models.LendPeriod", b =>
                {
                    b.HasOne("Labb4MVC.Models.Book", "Book")
                        .WithMany("LentTo")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4MVC.Models.Customer", "Customer")
                        .WithMany("Lending")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Labb4MVC.Models.Book", b =>
                {
                    b.Navigation("LentTo");
                });

            modelBuilder.Entity("Labb4MVC.Models.BookType", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Labb4MVC.Models.Customer", b =>
                {
                    b.Navigation("Lending");
                });
#pragma warning restore 612, 618
        }
    }
}
