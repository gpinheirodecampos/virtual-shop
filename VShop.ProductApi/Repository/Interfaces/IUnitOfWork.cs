namespace VShop.ProductApi.Repository.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }

    IProductRepository ProductRepository { get; }

    Task Commit();
}
