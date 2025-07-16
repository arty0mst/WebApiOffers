public class OfferEntity
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public int SupplierId { get; set; }
    public SupplierEntity? Supplier { get; set; }
}