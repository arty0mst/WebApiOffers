public interface ISuppliersRepository
{
    public Task<List<SupplierEntity>> Get();
}