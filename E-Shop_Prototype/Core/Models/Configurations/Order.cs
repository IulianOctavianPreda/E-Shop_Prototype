using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Models.Configurations
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        ///     Configure the Product entity.
        /// </summary>
        /// <param name="builder">Entity configurator</param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.OrderDate)
                .IsRequired(true);

            builder.HasOne(e => e.User)
                .WithMany(m => m.Orders)
                .HasForeignKey(e => e.UserId)
                .IsRequired(true);

            builder.HasMany(e => e.OrderItems)
                .WithOne(i => i.Order)
                .IsRequired(true);
        }
    }
}
