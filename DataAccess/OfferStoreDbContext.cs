using Microsoft.EntityFrameworkCore;

public class OfferStoreDbContext : DbContext
{
    public OfferStoreDbContext(DbContextOptions<OfferStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<OfferEntity> Offers { get; set; }
    public DbSet<SupplierEntity> Suppliers { get; set;  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OfferConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());

        base.OnModelCreating(modelBuilder);

        // Начальные значения в БД

        var creationDate = new DateTime(2025, 7, 16, 12, 0, 0, DateTimeKind.Utc);

        SupplierEntity germanCarsSupplier = new SupplierEntity { Id = 1, Name = "GermanCarsGroup", CreationDate = creationDate };
        SupplierEntity usaCarsSupplier = new SupplierEntity { Id = 2, Name = "UsaCarsGroup", CreationDate = creationDate };
        SupplierEntity ukCarsSupplier = new SupplierEntity { Id = 3, Name = "UkCarsGroup", CreationDate = creationDate };
        SupplierEntity japanCarsSupplier = new SupplierEntity { Id = 4, Name = "JapanCarsGroup", CreationDate = creationDate };
        SupplierEntity chinaCarsSupplier = new SupplierEntity { Id = 5, Name = "RuCarsGroup", CreationDate = creationDate };

        OfferEntity bmwFiveSeriesOffer = new OfferEntity { Id = 1, Brand = "BMW", Model = "530d", RegistrationDate = creationDate, SupplierId = 1};
        OfferEntity bmwThreeSeriesOffer = new OfferEntity { Id = 2, Brand = "BMW", Model = "320i", RegistrationDate = creationDate, SupplierId = 1};
        OfferEntity bmwTwoSeriesOffer = new OfferEntity { Id = 3, Brand = "BMW", Model = "M2", RegistrationDate = creationDate, SupplierId = 1};
        OfferEntity bmwSixSeriesOffer = new OfferEntity { Id = 4, Brand = "BMW", Model = "640i", RegistrationDate = creationDate, SupplierId = 1};
        OfferEntity bmwSevenSeriesOffer = new OfferEntity { Id = 5, Brand = "BMW", Model = "750Ld", RegistrationDate = creationDate, SupplierId = 1};
        OfferEntity porschePanameraOffer = new OfferEntity { Id = 6, Brand = "Porsche", Model = "Panamera", RegistrationDate = creationDate, SupplierId = 1};
        OfferEntity porscheCayenneOffer = new OfferEntity { Id = 7, Brand = "Porsche", Model = "Cayenne", RegistrationDate = creationDate, SupplierId = 1};
        OfferEntity fordMustangOffer = new OfferEntity { Id = 8, Brand = "Ford", Model = "Mustang", RegistrationDate = creationDate, SupplierId = 2};
        OfferEntity dodgeChallengerOffer = new OfferEntity { Id = 9, Brand = "Dodge", Model = "Challenger", RegistrationDate = creationDate, SupplierId = 2};
        OfferEntity dodgeChargerOffer = new OfferEntity { Id = 10, Brand = "Dodge", Model = "Charger", RegistrationDate = creationDate, SupplierId = 2};
        OfferEntity rangeroverVelarOffer = new OfferEntity { Id = 11, Brand = "Land Rover", Model = "Range Rover Velar", RegistrationDate = creationDate, SupplierId = 3};
        OfferEntity rangeroverSportOffer = new OfferEntity { Id = 12, Brand = "Land Rover", Model = "Range Rove Sport", RegistrationDate = creationDate, SupplierId = 3};
        OfferEntity toyotaLandCruiserOffer = new OfferEntity { Id = 13, Brand = "Toyota", Model = "Land Cruiser 300", RegistrationDate = creationDate, SupplierId = 4};
        OfferEntity liNineOffer = new OfferEntity { Id = 14, Brand = "LiXiang", Model = "L9", RegistrationDate = creationDate, SupplierId = 5};
        OfferEntity liSevenOffer = new OfferEntity { Id = 15, Brand = "LiXiang", Model = "L7", RegistrationDate = creationDate, SupplierId = 5};

        modelBuilder.Entity<SupplierEntity>().HasData(
            germanCarsSupplier,
            usaCarsSupplier,
            ukCarsSupplier,
            japanCarsSupplier,
            chinaCarsSupplier
            );

        modelBuilder.Entity<OfferEntity>().HasData(
            bmwFiveSeriesOffer,
            bmwThreeSeriesOffer,
            bmwTwoSeriesOffer,
            bmwSixSeriesOffer,
            bmwSevenSeriesOffer,
            porschePanameraOffer,
            porscheCayenneOffer,
            fordMustangOffer,
            dodgeChallengerOffer,
            dodgeChargerOffer,
            rangeroverVelarOffer,
            rangeroverSportOffer,
            toyotaLandCruiserOffer,
            liNineOffer,
            liSevenOffer
            );
    }
    
    
}