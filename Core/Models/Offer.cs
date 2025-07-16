public class Offer
{
    public int Id { get; }
    public string Brand { get; } = string.Empty;
    public string Model { get; } = string.Empty;
    public Supplier? Supplier { get; }
    public DateTime RegistrationDate { get; }

    private Offer(string brand, string model, Supplier supplier)
    {
        Brand = brand;
        Model = model;
        Supplier = supplier;
        RegistrationDate = new DateTime(2025, 7, 16, 12, 0, 0).ToUniversalTime();;
    }

    public static (Offer Offer, string Error) Create(string brand, string model, Supplier supplier)
    {
        string error = string.Empty;

        if (string.IsNullOrEmpty(brand))
        {
            error = "Empty brand";
        }

        Offer offer = new Offer(brand, model, supplier);

        return (offer, error);

    }
}