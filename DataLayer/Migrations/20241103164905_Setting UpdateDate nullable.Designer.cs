﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(ExpenseTrackerDbContext))]
    [Migration("20241103164905_Setting UpdateDate nullable")]
    partial class SettingUpdateDatenullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModelLayer.Models.Balance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasMaxLength(10)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("ModelLayer.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("ModelLayer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ModelLayer.Models.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ModelLayer.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("ModelLayer.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ModelLayer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ModelLayer.Models.Balance", b =>
                {
                    b.HasOne("ModelLayer.Models.Bank", "Bank")
                        .WithMany("Balances")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.Status", "Status")
                        .WithMany("Balances")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.User", "User")
                        .WithMany("Balances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModelLayer.Models.Bank", b =>
                {
                    b.HasOne("ModelLayer.Models.Status", "Status")
                        .WithMany("Banks")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ModelLayer.Models.Category", b =>
                {
                    b.HasOne("ModelLayer.Models.Status", "Status")
                        .WithMany("Categories")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ModelLayer.Models.Expense", b =>
                {
                    b.HasOne("ModelLayer.Models.Bank", "Bank")
                        .WithMany("Expenses")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.Category", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Expenses")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.Status", "Status")
                        .WithMany("Expenses")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.User", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Category");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModelLayer.Models.PaymentMethod", b =>
                {
                    b.HasOne("ModelLayer.Models.Status", "Status")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ModelLayer.Models.User", b =>
                {
                    b.HasOne("ModelLayer.Models.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ModelLayer.Models.Bank", b =>
                {
                    b.Navigation("Balances");

                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("ModelLayer.Models.Category", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("ModelLayer.Models.PaymentMethod", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("ModelLayer.Models.Status", b =>
                {
                    b.Navigation("Balances");

                    b.Navigation("Banks");

                    b.Navigation("Categories");

                    b.Navigation("Expenses");

                    b.Navigation("PaymentMethods");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ModelLayer.Models.User", b =>
                {
                    b.Navigation("Balances");

                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
