using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;

namespace DataLayer.Configurations;

public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder
            .HasMany(e => e.Balances)
            .WithOne(e => e.Bank)
            .HasForeignKey(e => e.BankId)
            .OnDelete(DeleteBehavior.Restrict) // TODO learn more about this kind of configuration
            .IsRequired();
    }
}