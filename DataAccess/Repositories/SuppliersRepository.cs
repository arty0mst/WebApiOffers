using Microsoft.EntityFrameworkCore;

public class SuppliersRepository : ISuppliersRepository
{
    private readonly OfferStoreDbContext _context;

    public SuppliersRepository(OfferStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<SupplierEntity>> Get()
    {
        // var supplierEntities = await _context.Suppliers
        //     .AsNoTracking()
        //     .ToListAsync();

        // var suppliers = supplierEntities
        //     .Select(s => Supplier.Create(s.Id, s.Name, s.CreationDate).Supplier)
        //     .ToList();

        // return suppliers;
        return await _context.Suppliers
             .AsNoTracking()
             .Include(s => s.Offers)
             .ToListAsync();
    }
}