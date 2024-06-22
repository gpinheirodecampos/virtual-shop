using VShop.ProductApi.Context;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repository.Interfaces;

namespace VShop.ProductApi.Repository;

public class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
{
}