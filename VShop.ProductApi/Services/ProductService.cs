using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repository.Interfaces;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi.Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    public async Task<IEnumerable<ProductDTO>> Get()
    {
        var products = await unitOfWork.ProductRepository.Get().ToListAsync();
        return mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetById(Guid id)
    {
        var product = await unitOfWork.ProductRepository.GetByProperty(p => p.Id == id);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> Add(ProductDTO dto)
    {
        var product = mapper.Map<Product>(dto);
        unitOfWork.ProductRepository.Add(product);
        await unitOfWork.Commit();
        return mapper.Map<ProductDTO>(product);
    }

    public async Task Update(ProductDTO dto)
    {
        var product = mapper.Map<Product>(dto);
        unitOfWork.ProductRepository.Update(product);
        await unitOfWork.Commit();
    }

    public async Task Delete(ProductDTO dto)
    {
        var product = mapper.Map<Product>(dto);
        unitOfWork.ProductRepository.Delete(product);
        await unitOfWork.Commit();
    }
}
