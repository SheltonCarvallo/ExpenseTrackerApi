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
}