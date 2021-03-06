﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Models.Configurations
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(e => e.Password)
                .IsRequired(true);

            builder.HasMany(m => m.Orders)
                .WithOne(p => p.User)
                .IsRequired(true);

            builder.HasOne(m => m.Cart)
                .WithOne(p => p.User)
                .IsRequired(true);
        }
    }
}
