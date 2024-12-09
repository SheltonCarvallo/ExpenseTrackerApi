﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(ExpenseTrackerDbContext))]
    partial class ExpenseTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("BalanceCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BalanceUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Balances");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                            AccountNumber = "BcoBoSXCJ1",
                            Amount = 3000m,
                            BalanceCreatedDate = new DateTime(2024, 12, 9, 16, 41, 40, 590, DateTimeKind.Local).AddTicks(7204),
                            BankId = 3,
                            StatusId = 1,
                            UserId = new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64")
                        },
                        new
                        {
                            Id = new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                            AccountNumber = "BcoPiIBRE1",
                            Amount = 3000m,
                            BalanceCreatedDate = new DateTime(2024, 12, 9, 16, 41, 40, 590, DateTimeKind.Local).AddTicks(7217),
                            BankId = 2,
                            StatusId = 1,
                            UserId = new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44")
                        },
                        new
                        {
                            Id = new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                            AccountNumber = "OwnSXCJ1",
                            Amount = 700m,
                            BalanceCreatedDate = new DateTime(2024, 12, 9, 16, 41, 40, 590, DateTimeKind.Local).AddTicks(7220),
                            BankId = 4,
                            StatusId = 1,
                            UserId = new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64")
                        });
                });

            modelBuilder.Entity("ModelLayer.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BankModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BankRegisterDate")
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

                    b.Property<DateTime>("CategoryDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CategoryDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<DateTime>("ExpenseRegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpenseUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ModelLayer.Models.FakeModels.ExpenseBetweenDatesSP", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseRegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseBetweenDatesSPs");
                });

            modelBuilder.Entity("ModelLayer.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("PaymentMethodModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentMethodRegisterDate")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UserRegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UserUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64"),
                            FirstName = "Shelton",
                            LastName = "Carvallo",
                            StatusId = 1,
                            UserRegisterDate = new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = ""
                        },
                        new
                        {
                            Id = new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44"),
                            FirstName = "Ivonne",
                            LastName = "Rubira",
                            StatusId = 1,
                            UserRegisterDate = new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = ""
                        });
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
