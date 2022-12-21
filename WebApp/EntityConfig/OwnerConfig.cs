using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.EntityConfig
{
    public class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(o => o.LastName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(o => o.Age)
                .IsRequired(false);

            builder.HasMany<Car>(o => o.Cars)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
