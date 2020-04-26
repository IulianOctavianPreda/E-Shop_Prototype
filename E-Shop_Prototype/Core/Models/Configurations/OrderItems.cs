using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Models.Configurations
{
    public class OrderItemsMapping : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.ProductId });

            builder.HasOne(e => e.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(e => e.OrderId)
                .IsRequired(true);


            builder.HasOne(e => e.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(e => e.ProductId)
                .IsRequired(true);

            builder.Property(p => p.Quantity)
                .IsRequired(true)
                .HasDefaultValue(1);
        }
    }
}
