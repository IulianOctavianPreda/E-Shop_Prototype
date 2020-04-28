using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Models.Configurations
{
    public class CartItemsMapping : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(e => new { e.CartId, e.ProductId });

            builder.HasOne(e => e.Cart)
                .WithMany(o => o.CartItems)
                .HasForeignKey(e => e.CartId)
                .IsRequired(true);

            builder.HasOne(e => e.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(e => e.ProductId)
                .IsRequired(true);

            builder.Property(p => p.Quantity)
                .IsRequired(true)
                .HasDefaultValue(1);
        }
    }
}
