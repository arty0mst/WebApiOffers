public interface IOffersService
{
    public Task<int> CreateOffer(OffersRequest request);
    public Task<OffersSearchResponse> SearchOffers(string? brand, string? model, string? supplier);
}