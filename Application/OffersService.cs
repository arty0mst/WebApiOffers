public class OffersService : IOffersService
{
    private readonly IOffersRepository _offersRepository;

    public OffersService(IOffersRepository offersRepository)
    {
        _offersRepository = offersRepository;
    }

    public async Task<int> CreateOffer(OffersRequest request)
    {
        var supplierEntity = await _offersRepository.GetSupplierById(request.SupplierId);

        if (supplierEntity == null)
        {
            throw new ArgumentException("Supplier with this id was not found");
        }

        var supplier = Supplier.Create(supplierEntity.Id, supplierEntity.Name, supplierEntity.CreationDate).Supplier;

        var (offer, error) = Offer.Create(request.Brand, request.Model, supplier);

        if (!string.IsNullOrEmpty(error))
        {
            throw new ArgumentException(error);
        }

        return await _offersRepository.Create(offer);
    }

    public async Task<OffersSearchResponse> SearchOffers(string? brand, string? model, string? supplier)
    {
       return await _offersRepository.Search(brand, model, supplier);
    }
}