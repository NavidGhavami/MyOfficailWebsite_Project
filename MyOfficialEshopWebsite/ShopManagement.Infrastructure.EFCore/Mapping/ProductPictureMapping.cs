using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.Product;
using ShopManagement.Domain.ProductPicture;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPicture");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.ProductPictures)
                   .HasForeignKey(x=>x.ProductId);


        }
    }
}
