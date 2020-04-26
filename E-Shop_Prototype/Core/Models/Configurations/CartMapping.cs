using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Models.Configurations
{
    public class CartMapping : IEntityTypeConfiguration<Cart>
    {
        /// <summary>
        ///     Configure the Product entity.
        /// </summary>
        /// <param name="builder">Entity configurator</param>
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithOne(m => m.Cart)
                .IsRequired(true);

            builder.HasMany(e => e.CartItems)
                .WithOne(i => i.Cart)
                .IsRequired(true);
        }
    }
}
