using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.EntityConfig
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Model)
               .IsRequired()
               .HasMaxLength(255);

            builder.Property(c => c.Color)
               .IsRequired()
               .HasMaxLength(255);

            builder.HasOne<Owner>(c => c.Owner)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OwnerId)
                .IsRequired(false);
        }
    }
}
