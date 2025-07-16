public class Supplier
{
    public int Id { get; }
    public string Name { get; } = string.Empty;
    public DateTime CreationDate { get; }

    private Supplier(int id, string name, DateTime creationDate)
    {
        Id = id;
        Name = name;
        CreationDate = creationDate;
    }

    public static (Supplier Supplier, string Error) Create(int id, string name, DateTime creationDate)
    {
        string error = string.Empty;

        if (string.IsNullOrEmpty(error))
        {
            error = "Empty name";
        }

        Supplier supplier = new Supplier(id, name, creationDate);

        return (supplier, error);
    }
}