using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;

namespace DataLayer.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{

    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder
            .HasMany(e => e.Expenses)
            .WithOne(e => e.PaymentMethod)
            .HasForeignKey(e => e.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}