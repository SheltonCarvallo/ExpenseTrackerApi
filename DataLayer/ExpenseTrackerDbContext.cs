using DataLayer.Configurations;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;

namespace DataLayer;

public class ExpenseTrackerDbContext : DbContext
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options)
    {
    }

    public ExpenseTrackerDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "data source=DESKTOP-REDKEOB;initial catalog=ExpenseTrackerDevelopment;user id= PortalApi;password=123456;TrustServerCertificate=True;MultipleActiveResultSets=true");

    public DbSet<Balance> Balances => Set<Balance>();
    public DbSet<Bank> Banks => Set<Bank>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Expense> Expenses => Set<Expense>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new BalanceConfiguration().Configure(modelBuilder.Entity<Balance>());
        new StatusConfiguration().Configure(modelBuilder.Entity<Status>());
        new BankConfiguration().Configure(modelBuilder.Entity<Bank>());
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new PaymentMethodConfiguration().Configure(modelBuilder.Entity<PaymentMethod>());
        new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        new ExpenseConfiguration().Configure(modelBuilder.Entity<Expense>());

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("E1A1E1C4-BF89-4B8F-B9E1-C4747DBD2A64"), // Fixed Guid
                FirstName = "Shelton",
                LastName = "Carvallo",
                UserRegisterDate = new DateTime(2024, 11, 02),
                StatusId = 1,
            },
            new User
            {
                Id = Guid.Parse("B0D1E1C4-DF87-4F4A-A4E4-D4747DBC1B44"), // Fixed Guid
                FirstName = "Ivonne",
                LastName = "Rubira",
                UserRegisterDate = new DateTime(2024, 11, 03),
                StatusId = 1,
            }
        );

        modelBuilder.Entity<Balance>().HasData(
            new Balance
            {
                Id = Guid.Parse("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                AccountNumber = "BcoBoSXCJ1",
                Amount = 3000,
                BalanceCreatedDate = DateTime.Now,
                BankId = 3,
                StatusId = 1,
                UserId =  Guid.Parse("E1A1E1C4-BF89-4B8F-B9E1-C4747DBD2A64")
            },
            new Balance
            {
                Id = Guid.Parse("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                AccountNumber = "BcoPiIBRE1",
                Amount = 3000,
                BalanceCreatedDate = DateTime.Now,
                BankId = 2,
                StatusId = 1,
                UserId =  Guid.Parse("B0D1E1C4-DF87-4F4A-A4E4-D4747DBC1B44")
            },
            new Balance
            {
                Id = Guid.Parse("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                AccountNumber = "OwnSXCJ1",
                Amount = 700,
                BalanceCreatedDate = DateTime.Now,
                BankId = 4,
                StatusId = 1,
                UserId =  Guid.Parse("E1A1E1C4-BF89-4B8F-B9E1-C4747DBD2A64")
            }
            );

    }
}