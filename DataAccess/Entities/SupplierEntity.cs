public class SupplierEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public List<OfferEntity> Offers { get; set; } = []; // У одного поставщика может быть множество офферов
}