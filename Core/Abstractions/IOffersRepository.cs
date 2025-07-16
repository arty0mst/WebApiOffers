public interface IOffersRepository
{
    public Task<SupplierEntity?> GetSupplierById(int supplierId);
    public Task<OffersSearchResponse> Search(string? brand, string? model, string? supplier);
    public Task<int> Create(Offer offer);
}