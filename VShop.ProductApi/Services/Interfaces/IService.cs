namespace VShop.ProductApi.Services.Interfaces;

public interface IService<TId, TDto>
{
    Task<IEnumerable<TDto>> Get();
    Task<TDto> GetById(TId id);
    Task<TDto> Add(TDto dto);
    Task Update(TDto dto);
    Task Delete(TDto dto);
}
