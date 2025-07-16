using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OfferConfiguration : IEntityTypeConfiguration<OfferEntity>
{
    public void Configure(EntityTypeBuilder<OfferEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasOne(o => o.Supplier)
            .WithMany(s => s.Offers)
            .HasForeignKey(o => o.SupplierId);
    }
}