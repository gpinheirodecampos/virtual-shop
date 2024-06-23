using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class ProductController(IProductService productService) : ControllerBase
{
    // GET /product
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await productService.Get();

        return Ok(products);
    }

    // GET /product/{id}
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await productService.GetById(id);

        if (product == null)
        {
            return NotFound("Product not found.");
        }

        return Ok(product);
    }

    // POST /product
    [HttpPost]
    public async Task<IActionResult> Add(ProductDTO dto)
    {
        if (dto == null)
        {
            return BadRequest("Invalid data.");
        }

        var product = await productService.Add(dto);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // PUT /product
    [HttpPut]
    public async Task<IActionResult> Update(Guid id, ProductDTO dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest("Invalid data.");
        }

        var product = await productService.GetById(id);

        if (product == null)
        {
            return NotFound("Product not found.");
        }

        await productService.Update(dto);

        return Ok("Product updated successfully.");
    }

    // DELETE /product
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await productService.GetById(id);

        if (product == null)
        {
            return NotFound("Product not found.");
        }

        await productService.Delete(product);

        return Ok("Product deleted successfully.");
    }
}
