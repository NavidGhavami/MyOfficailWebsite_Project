using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategory;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.PrimaryPicture).HasMaxLength(1000);
            builder.Property(x => x.SecondaryPicture).HasMaxLength(1000);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ParentId);

            



            //builder.HasMany(x => x.Products)
            //       .WithOne(x => x.Category)
            //       .HasForeignKey(x => x.CategoryId);
        }
    }
}
