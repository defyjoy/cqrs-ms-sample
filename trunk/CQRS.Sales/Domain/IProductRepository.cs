namespace CQRS.Sales.Domain
{
    public interface IProductRepository
    {
        Product Load(int id);
    }
}