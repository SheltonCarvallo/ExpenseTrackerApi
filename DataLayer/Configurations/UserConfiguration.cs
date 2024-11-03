using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelLayer.Models;

namespace DataLayer.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(e => e.Balance)
            .WithOne(e => e.User)
            .HasForeignKey<Balance>(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}