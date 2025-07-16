using System.Security.Cryptography.X509Certificates;

public record OffersSearchResult(
    int Id,
    string Brand,
    string Model,
    string Supplier,
    DateTime RegistrationDate
);

public record OffersSearchResponse(
    int TotalCount,
    List<OffersSearchResult> Items
);