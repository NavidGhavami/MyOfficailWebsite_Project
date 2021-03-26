using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.Order;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IssueTrackingNo).HasMaxLength(10);

            builder.OwnsMany(x => x.Items, navigationBuilder =>
            {
                navigationBuilder.ToTable("OrderItems");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.WithOwner(x => x.Order).HasForeignKey(x => x.OrderId);
            });

            builder.OwnsOne(x => x.PersonalInfoItem, navigationBuilder =>
            {
                navigationBuilder.ToTable("PersonalInformation");
                navigationBuilder.HasKey(x => x.Id);

                navigationBuilder.Property(x => x.Name).HasMaxLength(150).IsRequired();
                navigationBuilder.Property(x => x.Family).HasMaxLength(250).IsRequired();
                navigationBuilder.Property(x => x.Company).HasMaxLength(350);
                navigationBuilder.Property(x => x.Country).HasMaxLength(150).IsRequired();
                navigationBuilder.Property(x => x.State).HasMaxLength(250).IsRequired();
                navigationBuilder.Property(x => x.City).HasMaxLength(250).IsRequired();
                navigationBuilder.Property(x => x.Street).HasMaxLength(1000).IsRequired();
                navigationBuilder.Property(x => x.PostalCode).HasMaxLength(100).IsRequired();
                navigationBuilder.Property(x => x.PlaqueNo).HasMaxLength(50);
                navigationBuilder.Property(x => x.Mobile).HasMaxLength(150).IsRequired();
                navigationBuilder.Property(x => x.Email).HasMaxLength(500);
                navigationBuilder.Property(x => x.Description).HasMaxLength(1000);

                navigationBuilder.WithOwner(x => x.Order).HasForeignKey(x => x.OrderId);
            });
        }
    }
}
