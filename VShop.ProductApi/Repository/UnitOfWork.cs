using VShop.ProductApi.Context;
using VShop.ProductApi.Repository.Interfaces;

namespace VShop.ProductApi.Repository;

public class UnitOfWork(AppDbContext contexto) : IUnitOfWork
{
    private ProductRepository? _productRepo;

    private CategoryRepository? _categoryRepo;

    public AppDbContext _context = contexto;

    public IProductRepository ProductRepository
    {
        get
        {
            return _productRepo ??= new ProductRepository(_context);
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            return _categoryRepo ??= new CategoryRepository(_context);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
