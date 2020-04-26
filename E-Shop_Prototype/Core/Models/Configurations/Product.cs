using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Shop_Mini.Models.Configurations
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired(true)
                .HasMaxLength(5000);

            builder.Property(e => e.ImagePath)
                .IsRequired(true);

            builder.Property(e => e.SpecificationFilePath)
                .IsRequired(false);

            builder.Property(e => e.Price)
                .IsRequired(true);

            builder.HasOne(e => e.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(true);

            builder.HasMany(e => e.OrderItems)
                .WithOne(o => o.Product)
                .HasForeignKey(p => p.ProductId)
                .IsRequired(false);
        }
    }
}
