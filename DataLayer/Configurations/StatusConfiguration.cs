using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;

namespace DataLayer.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder
            .HasMany(e => e.Users)    
            .WithOne(e => e.Status)
            .HasForeignKey(e => e.StatusId)
            .IsRequired();
        
        builder
            .HasMany(e => e.PaymentMethods)    
            .WithOne(e => e.Status)
            .HasForeignKey(e => e.StatusId)
            .IsRequired();
        
        builder
            .HasMany(e => e.Balances)    
            .WithOne(e => e.Status)
            .HasForeignKey(e => e.StatusId)
            .IsRequired();
        
        builder
            .HasMany(e => e.Banks)    
            .WithOne(e => e.Status)
            .HasForeignKey(e => e.StatusId)
            .IsRequired();
        
        builder
            .HasMany(e => e.Categories)    
            .WithOne(e => e.Status)
            .HasForeignKey(e => e.StatusId)
            .IsRequired();
        
        builder
            .HasMany(e => e.Expenses)
            .WithOne(e => e.Status)
            .HasForeignKey(e => e.StatusId)
            .IsRequired();
    }
}