using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repository.Interfaces;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi.Services;

public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    public async Task<IEnumerable<CategoryDTO>> Get()
    {
        var categories = await unitOfWork.CategoryRepository.Get().ToListAsync();
        return mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> GetById(int id)
    {
        var category = await unitOfWork.CategoryRepository.GetByProperty(c => c.Id == id);
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO> Add(CategoryDTO dto)
    {
        var category = mapper.Map<Category>(dto);
        unitOfWork.CategoryRepository.Add(category);
        await unitOfWork.Commit();
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task Update(CategoryDTO dto)
    {
        var category = mapper.Map<Category>(dto);
        unitOfWork.CategoryRepository.Update(category);
        await unitOfWork.Commit();
    }

    public async Task Delete(CategoryDTO dto)
    {
        var category = mapper.Map<Category>(dto);
        unitOfWork.CategoryRepository.Delete(category);
        await unitOfWork.Commit();
    }
}
