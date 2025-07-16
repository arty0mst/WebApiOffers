using Microsoft.EntityFrameworkCore;

public class OffersRepository : IOffersRepository
{
    private readonly OfferStoreDbContext _context;

    public OffersRepository(OfferStoreDbContext context)
    {
        _context = context;
    }

    public async Task<SupplierEntity?> GetSupplierById(int supplierId)
    {
        return await _context.Suppliers.FindAsync(supplierId);
    }

    public async Task<int> Create(Offer offer)
    {
        var offerEntity = new OfferEntity
        {
            Brand = offer.Brand,
            Model = offer.Model,
            RegistrationDate = offer.RegistrationDate,
            SupplierId = offer.Supplier!.Id,
        };

        _context.Offers.Add(offerEntity);
        await _context.SaveChangesAsync();

        return offerEntity.Id;
    }

    public async Task<OffersSearchResponse> Search(string? brand, string? model, string? supplier)
    {
        var query = _context.Offers
            .Include(o => o.Supplier)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(brand))
        {
            query = query.Where(o => o.Brand == brand);
        }

        if (!string.IsNullOrWhiteSpace(model))
        {
            query = query.Where(o => o.Model.Contains(model));
        }

        if (!string.IsNullOrWhiteSpace(supplier))
        {
            query = query.Where(o => o.Supplier!.Name.Contains(supplier));
        }

        var total = await query.CountAsync();

        var items = await query
            .Select(o => new OffersSearchResult
            (
                o.Id,
                o.Brand,
                o.Model,
                o.Supplier!.Name,
                o.RegistrationDate
            ))
            .ToListAsync();

        return new OffersSearchResponse
        (
            total,
            items
        );
    }
}