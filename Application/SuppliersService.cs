public class SuppliersService : ISuppliersService
{
    private readonly ISuppliersRepository _suppliersRepository;

    public SuppliersService(ISuppliersRepository suppliersRepository)
    {
        _suppliersRepository = suppliersRepository;
    }

    public async Task<List<SuppliersTopResponse>> GetTop()
    {
        var suppliers = await _suppliersRepository.Get();

        return suppliers.Select(s => new SuppliersTopResponse
            (
                s.Name,
                s.Offers.Count
            ))
            .OrderByDescending(s => s.OfferCount)
            .Take(3)
            .ToList();
    }
}