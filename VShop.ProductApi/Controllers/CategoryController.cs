using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{

    // GET /category
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await categoryService.Get();

        return Ok(categories);
    }

    // GET /category/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await categoryService.GetById(id);

        if (category == null)
        {
            return NotFound("Category not found.");
        }

        return Ok(category);
    }

    // POST /category
    [HttpPost]
    public async Task<IActionResult> Add(CategoryDTO dto)
    {
        if (dto == null)
        {
            return BadRequest("Invalid data.");
        }

        var category = await categoryService.Add(dto);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    // PUT /category
    [HttpPut]
    public async Task<IActionResult> Update(int id, CategoryDTO dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest("Invalid data.");
        }

        var category = await categoryService.GetById(id);

        if (category == null)
        {
            return NotFound("Category not found.");
        }

        await categoryService.Update(dto);

        return Ok("Category updated successfully.");
    }

    // DELETE /category
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await categoryService.GetById(id);

        if (category == null)
        {
            return NotFound("Category not found.");
        }

        await categoryService.Delete(category);

        return Ok("Category deleted successfully.");
    }
}
