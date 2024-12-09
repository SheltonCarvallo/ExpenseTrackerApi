using ExpenseTrackerApi.Authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTrackerApi.Authentication;

public class AuthDbContext :IdentityDbContext<AppUserModel>
{
    private readonly IConfiguration _configuration;
    
    // Constructor that accepts DbContextOptions and IConfiguration
    public AuthDbContext(DbContextOptions<AuthDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    
    // OnModelCreating method for configuring the model
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    // OnConfiguring method for configuring the DbContext
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AuthConnection"));
    }
}