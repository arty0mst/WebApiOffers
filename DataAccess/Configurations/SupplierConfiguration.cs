using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SupplierConfiguration : IEntityTypeConfiguration<SupplierEntity>
{
    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .HasMany(s => s.Offers)
            .WithOne(o => o.Supplier)
            .HasForeignKey(o => o.SupplierId);
    }
}